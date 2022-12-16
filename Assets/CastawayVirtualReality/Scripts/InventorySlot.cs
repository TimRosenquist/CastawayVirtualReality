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

        [SerializeField]
        private GameObject MaterialsEventManager;

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
            objInSocket = socket.GetOldestInteractableSelected();

            obj = objInSocket.transform.gameObject;

            obj.transform.SetParent(transform);

            transform.localPosition = obj.GetComponent<Item>().slotPosition;
            transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
            transform.localScale = obj.GetComponent<Item>().slotScale;
        
            if (obj.GetComponent<Item>().isLog == true)
            {
                logCountIncrease.TriggerEvent();
            } 
            
            if (obj.GetComponent<Item>().isRope == true)
            {
                RopeCountIncrease.TriggerEvent();
            }
        }

        public void OnSelectExited()
        {
            obj = objInSocket.transform.gameObject;

            obj.transform.SetParent(null);

            obj.transform.localScale = obj.GetComponent<Item>().originalScale;

            if (obj.GetComponent<Item>().isLog == true)
            {
                logCountDecrease.TriggerEvent();
            }
            
            if (obj.GetComponent<Item>().isRope == true)
            {
                RopeCountDecrease.TriggerEvent();
            }
        }
    }
}

