using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(Rigidbody))]
    public class AIMovementBigSpider : MonoBehaviour
    {
        [SerializeField]
        private Animator _animationController;

        [SerializeField]
        private float _movementSpeed = 20f;

        [SerializeField]
        private float _rotationSpeed = 100f;


        private bool _isMoving;
        private bool _isRotatingLeft;
        private bool _isRotatingRight;
        private bool _isWandering;

        Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }


        void Update()
        {
            if (_isWandering == false)
            {
                _animationController.SetFloat("Blend", 0);
                StartCoroutine(Wander());
                
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

