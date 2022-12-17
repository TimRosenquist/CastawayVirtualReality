using UnityEngine;

namespace GameEventSystem
{
    public class Item : MonoBehaviour
    {
        // Stores the objects scaling, rotation and position data for the object to be properly positioned within the inventory, values need to be manually assigned
        public Vector3 slotPosition, slotRotation, slotScale, originalScale;

        // Optional markers for object that are criticall for completing the game
        public bool isLog;
        public bool isRope;

        private void Start()
        {
            // Automatically gets the original scale of the object this script is attached to for rescaling the object when it's removed from the inventory
            originalScale = transform.localScale;
        }
    }
}
