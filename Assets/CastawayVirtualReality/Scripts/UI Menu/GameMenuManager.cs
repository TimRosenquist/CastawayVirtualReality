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

        public Transform VRCamera;
        public float menuSpawnDistance = 2f;
        public GameObject menu;
        public InputActionProperty showMenuButton;

        void Update()
        {
            ShowMenu();  
        }

        public void ShowMenu()
        {
            // Gör så att Game Menu dyker upp framför spelaren vid knapptryck
            if (showMenuButton.action.WasPressedThisFrame())
            {
                menu.SetActive(!menu.activeSelf);  // Annat sätt att skriva kod för att aktivera/deaktivera ett objekt.

                menu.transform.position = VRCamera.position + new Vector3(VRCamera.forward.x, 0f, VRCamera.forward.z).normalized * menuSpawnDistance; // Specifierar vilket avstånd Game Menu ska dyka upp på
            }

            menu.transform.LookAt(new Vector3(VRCamera.position.x, VRCamera.position.y, VRCamera.position.z));
            menu.transform.forward *= -1;
        }

        public void QuitToMainMenuBtn()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

