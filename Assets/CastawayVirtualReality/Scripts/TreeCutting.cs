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
        private int cutCount; // the number of times the tree has been hit
        public AudioClip ChopSound; // the sound to play when the axe hits the tree
        AudioSource audioSource; // the source the audioclip will originate from

        void Start()
        {
            // get the audio source component on the axe
            audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            // check if the axe is colliding with the tree
            if (collision.gameObject.tag == "Axe")
            {                    
                // play the chop sound
                audioSource.PlayOneShot(ChopSound);

                // increase the cut count
                cutCount++;

                    // check if the tree has been hit enough times to be cut down
                    if (cutCount >= 6)
                    {
                        // cut down the tree
                        CutDownTree();
                    }                
            }
        }

        void CutDownTree()
        {
            tree.SetActive(false); //The static tree is inactivated
            log.SetActive(true); //The log is activated
        }
    }
}