using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParticleAudio
{
    public class WaterDripParticleAudio : MonoBehaviour
    {
        private int _currentNumberOfParticles = 0;

        private ParticleSystem _particleSystem;
        private AudioSource _impactSource;

        void Start()
        {
            // Gets the particle system and audiosource from the attached object
            _particleSystem = GetComponent<ParticleSystem>();
            _impactSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            // Checks if a particle has collided with ground by checking if the current amount of particles in has decreased
            if (_particleSystem.particleCount < _currentNumberOfParticles)
            {
                _impactSource.Play();
            }

            // Sets _currentNumberOfParticles value to the actual number of particles that currently exist
            _currentNumberOfParticles = _particleSystem.particleCount;
        }
    }
}

