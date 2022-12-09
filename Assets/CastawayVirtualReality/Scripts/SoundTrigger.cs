using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundTriggers
{
    public class SoundTrigger : MonoBehaviour
{
    //Field that asks for defined Sound-file
    [SerializeField] AudioClip clip;

    //Field that asks for defined source of played sound
    [SerializeField] AudioSource source;

    //String that defines objects Tag
    public string targetTag;

    //Game Object that trigger the sound
    //[SerializeField] GameObject soundTriggerObject;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    //Plays the sound-clip when object enters the gameobject that has the script on it
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            source.PlayOneShot(clip);
            //soundTriggerObject.SetActive(false);
        }
    }
}
}