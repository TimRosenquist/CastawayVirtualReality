using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    public class LogMaterialChange : MonoBehaviour
    {
        [SerializeField]
        private Material[] _logMaterial;

        private Renderer _logRenderer;

        void Start()
        {
            _logRenderer = GetComponent<Renderer>();
            _logRenderer.enabled = true;
            _logRenderer.sharedMaterial = _logMaterial[0];
        }
        
        public void ChangeMaterial()
        {
            _logRenderer.sharedMaterial = _logMaterial[1];
        }
    }
}

