using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace ChoppingTrees
{
    public class TreeCutting : MonoBehaviour
    {
        [SerializeField] private GameObject tree; // the tree
        [SerializeField] private GameObject log; // the log
        [SerializeField] public GameObject axe; // the axe
        [SerializeField] public float swingSpeed; // the minimum required swingspeed of the axe
        public float axeVelocity;
        private int cutCount; // the number of times the tree has been hit
        public AudioClip ChopSound; // the sound to play when the axe hits the tree
        private Rigidbody rigidBody;
        AudioSource audioSource;

        void Start()
        {
            // get the audio source component on the axe
            audioSource = GetComponent<AudioSource>();
            rigidBody = axe.GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            // check if the axe is colliding with the tree
            if (collision.gameObject.tag == "Axe")
            {
                // check if the axe is being swung fast enough
                if (axeVelocity >= swingSpeed)
                {
                    // play the chop sound
                    audioSource.PlayOneShot(ChopSound);

                    Debug.Log("Hit!");
                    // increase the cut count
                    cutCount++;

                    // check if the tree has been hit enough times to be cut down
                    if (cutCount >= 4)
                    {
                        // cut down the tree
                        CutDownTree();
                    }
                }
            }
        }

        //Continous read of the axes velocity
        private void Update()
        {
            axeVelocity = rigidBody.velocity.magnitude;
        }

        void CutDownTree()
        {
            tree.SetActive(false); //The static tree is inactivated
            log.SetActive(true); //The log is activated
        }
    }
}