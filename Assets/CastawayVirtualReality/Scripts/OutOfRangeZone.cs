using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    public class OutOfRangeZone : MonoBehaviour
    {
        [SerializeField]
        private GameEvent DisplayDisconnected;
        [SerializeField]
        private GameEvent DisplayConnected;

        private void OnTriggerEnter(Collider other)
        {
            DisplayDisconnected.TriggerEvent();
            //Debug.Log("in zone");
        }

        private void OnTriggerExit(Collider other)
        {
            DisplayConnected.TriggerEvent();
            //Debug.Log("not in zone");
        }
    }
}
