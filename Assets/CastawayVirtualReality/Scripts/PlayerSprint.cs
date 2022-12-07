using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

namespace CastawayVirtualReality
{
public class PlayerSprint : MonoBehaviour
{
        //Access continous move script
        ActionBasedContinuousMoveProvider moveProvider;
        private float initialMoveSpeed;
        //Access input action
        [SerializeField] InputActionAsset inputAction;
        private InputAction sprintAction;

        private float timeElapsed;
        [SerializeField]
        private float lerpDuration;
        [SerializeField]
        
        private float endValue = 8;
        private float valueToLerp;

        // Start is called before the first frame update
        void Start()
        {
            moveProvider = GetComponent<ActionBasedContinuousMoveProvider>();
            initialMoveSpeed = moveProvider.moveSpeed;
            sprintAction = inputAction.FindAction("Sprint");
            sprintAction.performed += SprintAction_performed;
            sprintAction.canceled += SprintAction_canceled;
        }

        private void Update()
        {
            if (timeElapsed < lerpDuration)
            {
                valueToLerp = Mathf.Lerp(moveProvider.moveSpeed, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }
            else valueToLerp = endValue;
        }
        private void SprintAction_performed(InputAction.CallbackContext obj)
        {
            moveProvider.moveSpeed = valueToLerp;
            
        }
        private void SprintAction_canceled(InputAction.CallbackContext obj)
        {
            moveProvider.moveSpeed = initialMoveSpeed;
        }


    }
}
