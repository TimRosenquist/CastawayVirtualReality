using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIMenu
{
    public class GameMenuManager : MonoBehaviour
    {

        public Transform VRCamera; // A public variable to make the in game menu transform it's position/rotation based on where your headset is.
        public float menuSpawnDistance = 1.5f; // Public variable to choose how far away the Menu should be from the Camera.
        public GameObject menu; // Lets us choose what Menu we wan't to show
        public InputActionProperty showMenuButton; // Gives us access to choose what pbutton we should press to show the in game menu

        void Update()
        {
            ShowMenu();  // Calls the function ShowMenu()
        }

        public void ShowMenu()
        {
            // This if statement is checking if you have pressed the given key, chosen by the variable showMenuButton
            if (showMenuButton.action.WasPressedThisFrame())
            {
                menu.SetActive(!menu.activeSelf);  // Same code as creating a bool value. But it checks if the bool value are true/false for us instead.

                menu.transform.position = VRCamera.position + new Vector3(VRCamera.forward.x, 0f, VRCamera.forward.z).normalized * menuSpawnDistance; // Specifies the position for the in game menu canvas
            }

            menu.transform.LookAt(new Vector3(VRCamera.position.x, VRCamera.position.y, VRCamera.position.z)); // This code make sure that the in game menu canvas are pointing at the right direction
            menu.transform.forward *= -1; // so it is facing towards the camera and not away from it
        }

        // This code is used by the Quit to menu Button in the in game menu canvas to load the scene Main Menu
        // which gets triggered only when you press the button in the game.
        public void QuitToMainMenuBtn()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

