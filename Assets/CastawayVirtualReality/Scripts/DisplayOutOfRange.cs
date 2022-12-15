using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    public class DisplayOutOfRange : MonoBehaviour
    {
        [SerializeField]
        private Material[] _material;

        private Renderer _renderer;

        void Start()
        {
            _renderer = GetComponent<Renderer>();
            _renderer.enabled = true;
            _renderer.sharedMaterial = _material[0];
        }

        public void OutOfRange()
        {
            _renderer.sharedMaterial = _material[1];
        }

        public void InToRange()
        {
            _renderer.sharedMaterial = _material[0];
        }
    }
}