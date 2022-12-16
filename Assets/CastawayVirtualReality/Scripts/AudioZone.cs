using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CastawayVirtualReality
{
public class AudioZone : MonoBehaviour
{
        private AudioSource AudioSource;
        [SerializeField] private AudioClip AudioClip;
        private float fade;
    // Start is called before the first frame update
    void Start()
    {
            AudioSource = GetComponent<AudioSource>();
    }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                AudioSource.Play();
                AudioSource.loop = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                AudioSource.Stop();
                AudioSource.loop = false;
            }
        }
    }
}
