using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapCamera
{
    public class MapCamera : MonoBehaviour
    {
        [SerializeField]
        private Transform _followPoint;

        private float _startHight;

        void Start()
        {
            // gets the starting height of the drone
            _startHight = transform.position.y;
        }

        void Update()
        {
            // updates the drones position to be above the player
            transform.position = (new Vector3(_followPoint.position.x, _startHight, _followPoint.position.z));
        }
    }
}