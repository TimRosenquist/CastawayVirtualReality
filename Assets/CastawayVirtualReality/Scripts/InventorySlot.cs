using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InventorySlot : MonoBehaviour
{
    XRSocketInteractor socket;
    IXRSelectInteractable objInSocket;
    GameObject obj;
    bool hasParent;
    //bool active;

    //[SerializeField]
    //private GameObject checkIfActive;

    void Start()
    {
        socket = GetComponentInParent<XRSocketInteractor>();
        //active = GetComponent<InventoryVR>().isActive;
        hasParent = false;
    }

    public void SlotCheck()
    {
        objInSocket = socket.GetOldestInteractableSelected();

        obj = objInSocket.transform.gameObject;

        //active = checkIfActive.GetComponent<InventoryVR>().isActive;
        //&& active == true
        //if (hasParent == false)
        //{
            obj.transform.SetParent(transform);
        //    hasParent = true;
        //}

        transform.localPosition = obj.GetComponent<Item>().slotPosition;
        transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
        transform.localScale = obj.GetComponent<Item>().slotScale;

        //Debug.Log(obj.transform.name);
    }

    public void OnExit()
    {
        obj = objInSocket.transform.gameObject;

        //active = checkIfActive.GetComponent<InventoryVR>().isActive;
        //if (hasParent == true)
        //{
            obj.transform.SetParent(null);
        //    hasParent = false;
        //}

        //transform.localScale = new Vector3(1, 1, 1);

        obj.transform.localScale = obj.GetComponent<Item>().originalScale;

        //Debug.Log("exit");
    }
}