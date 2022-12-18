using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(Rigidbody))] // This line of code is like a failsafe code to make sure the gameobject has a RigidBody
    public class AIMovementBigSpider : MonoBehaviour
    {
        [SerializeField]
        private Animator _animationController; // Lets you choose what animation controller you wanna use for the specific animal

        [SerializeField]
        private float _movementSpeed = 20f; // Defines the movement speed for the animal that you can change in the inspector window

        [SerializeField]
        private float _rotationSpeed = 100f; // Defines the rotation speed for the animal that you can change in the inspector window

        // Defining some bool values that we are gonna check wether they are true or not alter on in the code
        private bool _isMoving;
        private bool _isRotatingLeft;
        private bool _isRotatingRight;
        private bool _isWandering;

        Rigidbody rb; // Creates a RigidBody vairable called rb

        void Start()
        {
            rb = GetComponent<Rigidbody>(); 
        }

        // In Update we check wether one of the booleans values are true or false. If they are true, they will return a specific movement type
        // and the specific animation chosen in the inspector window, switching it's float value from a blend tree in the animation controller
        // between 0 and 1.
        void Update()
        {
            if (_isWandering == false)
            {
                _animationController.SetFloat("Blend", 0);
                StartCoroutine(Wander()); // If the animal stands still this code will call a function called Wander.
                
            }

            if (_isRotatingRight == true)
            {
                _animationController.SetFloat("Blend", 0);
                transform.Rotate(transform.up * Time.deltaTime * _rotationSpeed);
                _animationController.SetFloat("Blend", 1);
            }

            if (_isRotatingLeft == true)
            {
                _animationController.SetFloat("Blend", 0);
                transform.Rotate(transform.up * Time.deltaTime * -_rotationSpeed);
                _animationController.SetFloat("Blend", 1);
            }

            if (_isMoving == true)
            {
                rb.AddForce(transform.forward * _movementSpeed);
                _animationController.SetFloat("Blend", 1);
            }
        }


        // The wander function is a IEnumerator where we define some int variables with  a random number between 1-3 and 1-2 for a more
        // random/more natural movement of the gameobject. Which we later on send to Update.
        IEnumerator Wander()
        {
            int rotationTime = Random.Range(1, 3);
            int rotateWait = Random.Range(1, 3);
            int rotateDirection = Random.Range(1, 2);
            int walkWait = Random.Range(1, 3);
            int walkTime = Random.Range(1, 3);

            _isWandering = true;
            yield return new WaitForSeconds(walkWait);

            _isMoving = true;
            yield return new WaitForSeconds(walkTime);

            _isMoving = false;
            yield return new WaitForSeconds(rotateWait);

            if (rotateDirection == 2)
            {
                _isRotatingLeft = true;
                yield return new WaitForSeconds(rotationTime);
                _isRotatingLeft = false;
            }
            
            if (rotateDirection == 1)
            {
                _isRotatingRight = true;
                yield return new WaitForSeconds(rotationTime);
                _isRotatingRight = false;
            }

            _isWandering = false;
        }
    }
}

