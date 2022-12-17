using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace GameEventSystem
{
    public class InventorySlot : MonoBehaviour
    {
        XRSocketInteractor socket;
        IXRSelectInteractable objInSocket;
        GameObject obj;

        public GameEvent logCountIncrease;
        public GameEvent logCountDecrease;
        public GameEvent RopeCountIncrease;
        public GameEvent RopeCountDecrease;

        private int logCount;

        void Start()
        {
            socket = GetComponentInParent<XRSocketInteractor>();
        }

        public void OnSelectEntered()
        {
            // Gets the object placed in the socket
            objInSocket = socket.GetOldestInteractableSelected();
            // Gets the object as a gameObject in order to manipulate it
            obj = objInSocket.transform.gameObject;

            // Makes the object into a child to the socket so that it follows the inventory when it gets deactivated
            obj.transform.SetParent(transform);

            // Changes the objects so that it will fit the inventory slot
            transform.localPosition = obj.GetComponent<Item>().slotPosition;
            transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
            transform.localScale = obj.GetComponent<Item>().slotScale;

            // Increases a counter if the object that entered the socket is a log
            if (obj.GetComponent<Item>().isLog == true)
            {
                logCountIncrease.TriggerEvent();
            }

            // Increases a counter if the object that entered the socket is a rope
            if (obj.GetComponent<Item>().isRope == true)
            {
                RopeCountIncrease.TriggerEvent();
            }
        }

        public void OnSelectExited()
        {
            obj = objInSocket.transform.gameObject;

            // Unchilds the object from the socket when it gets removed from it
            obj.transform.SetParent(null);

            // Returns the object into it's original scale
            obj.transform.localScale = obj.GetComponent<Item>().originalScale;

            // Decreases a counter if the object that entered the socket is a log
            if (obj.GetComponent<Item>().isLog == true)
            {
                logCountDecrease.TriggerEvent();
            }

            // Decreases a counter if the object that entered the socket is a rope
            if (obj.GetComponent<Item>().isRope == true)
            {
                RopeCountDecrease.TriggerEvent();
            }
        }
    }
}