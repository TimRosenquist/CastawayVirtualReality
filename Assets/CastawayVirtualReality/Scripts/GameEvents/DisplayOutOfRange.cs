using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    public class DisplayOutOfRange : MonoBehaviour
    {
        // Allows for storing multiple materials on object
        [SerializeField]
        private Material[] _material;

        private Renderer _renderer;

        void Start()
        {
            // Gets renderer from object
            _renderer = GetComponent<Renderer>();
            _renderer.enabled = true;
            // Sets the map screen to the drone camera at start
            _renderer.sharedMaterial = _material[0];
        }

        public void OutOfRange()
        {
            // Sets the map screen to "not in service" when the right condition is fulfilled
            _renderer.sharedMaterial = _material[1];
        }

        public void InToRange()
        {
            // Sets the map screen to the drone camera when the right condition is fullfilled
            _renderer.sharedMaterial = _material[0];
        }
    }
}