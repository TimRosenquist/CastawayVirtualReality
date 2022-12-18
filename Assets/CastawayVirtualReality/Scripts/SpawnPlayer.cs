using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class SpawnPlayer : MonoBehaviour
    {
        //Reference field for player object
        [SerializeField]
        private GameObject refToSpawnedObject;

        // Spawn player to this objects position
        void Start()
        {
            refToSpawnedObject.transform.position = transform.position;
        }

   
    }
}


