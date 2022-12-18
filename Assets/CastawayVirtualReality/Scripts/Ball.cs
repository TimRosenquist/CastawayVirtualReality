using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    //Add Components Audiosource and Rigidbody to gameobject
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        //Call upon audiosource and audioclip
        private AudioSource audioSource;
        [SerializeField]
        private AudioClip audioClip;
        // Start is called before the first frame update
        void Start()
        {
            //Enable audiosource component in script
            audioSource = GetComponent<AudioSource>();
        }
        //Audio will play when object collide
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == true)
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
