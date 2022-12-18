using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class SpawnPlayer : MonoBehaviour
    {
        [SerializeField]
        private GameObject refToSpawnedObject;

        // Start is called before the first frame update
        // Spawn player to this objects position
        void Start()
        {
            refToSpawnedObject.transform.position = transform.position;
        }

   
    }
}


