using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

namespace Player
{
public class PlayerSprint : MonoBehaviour
{
        //Access continous move script
        ActionBasedContinuousMoveProvider moveProvider;
        private float initialMoveSpeed;
        //Access input action
        [SerializeField] InputActionAsset inputAction;
        private InputAction sprintAction;

        // Start is called before the first frame update
        void Start()
        {
            moveProvider = GetComponent<ActionBasedContinuousMoveProvider>();
            initialMoveSpeed = moveProvider.moveSpeed;
            sprintAction = inputAction.FindAction("Sprint");
            sprintAction.performed += SprintAction_performed;
            sprintAction.canceled += SprintAction_canceled;
        }
        //Perfermend when button is pushed
        private void SprintAction_performed(InputAction.CallbackContext obj)
        {
            moveProvider.moveSpeed = 6f;
        }
        //Performed when button is released
        private void SprintAction_canceled(InputAction.CallbackContext obj)
        {
            moveProvider.moveSpeed = initialMoveSpeed;
        }
    }
}
