using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    public class OutOfRangeZone : MonoBehaviour
    {
        // Game events for when the maptablet enters and exits the "out of reach zone"
        [SerializeField]
        private GameEvent DisplayDisconnected;
        [SerializeField]
        private GameEvent DisplayConnected;

        private void OnTriggerEnter(Collider other)
        {
            // Disconnects the map from the drone when the map enters the cave
            if (other.gameObject.name == "MapTablet") DisplayDisconnected.TriggerEvent();
        }

        private void OnTriggerExit(Collider other)
        {
            // Connects the map to the drone when the map exits the cave
            if (other.gameObject.name == "MapTablet") DisplayConnected.TriggerEvent();
        }
    }
}