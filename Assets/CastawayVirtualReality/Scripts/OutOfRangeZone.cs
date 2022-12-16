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
            if (other.gameObject.name == "MapTablet v.2") DisplayDisconnected.TriggerEvent();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == "MapTablet v.2") DisplayConnected.TriggerEvent();
        }
    }
}