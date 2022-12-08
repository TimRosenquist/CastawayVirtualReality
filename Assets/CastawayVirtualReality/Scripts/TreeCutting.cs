using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace ChoppingTrees
{
    public class TreeCutting : MonoBehaviour
    {
        [SerializeField] public GameObject tree; // the tree
        [SerializeField] public GameObject axe; // the axe
        [SerializeField] public GameObject log; // the log
        [SerializeField] public float swingSpeed; // the minimum required swingspeed of the axe
        public int cutCount; // the number of times the tree has been hit
        public AudioClip ChopSound; // the sound to play when the axe hits the tree

        AudioSource audioSource;

        void Start()
        {
            // get the audio source component on the axe
            audioSource = axe.GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            // check if the axe is colliding with the tree
            if (collision.gameObject.tag == "Axe")
                {
                // check if the axe is being swung fast enough
                if (axe.GetComponent<Rigidbody>().velocity.magnitude >= swingSpeed)
                {
                    // play the chop sound
                    audioSource.PlayOneShot(ChopSound);

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

        void CutDownTree()
        {
            Instantiate(log, tree.transform.position, tree.transform.rotation);
            Destroy(tree);
        }
    }
}