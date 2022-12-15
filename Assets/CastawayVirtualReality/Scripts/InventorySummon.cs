// Script name: InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.
// This script is a property of Realary, Inc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InventorySummon : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    public GameObject HideAnchor;
    bool InventoryActive;
    //public bool isActive;

    //public InputActionReference inventoryReference = null;
    private XRIDefaultInputActions inputActions;
    private InputAction inventoryButton;

    private void Start()
    {
        //Inventory.SetActive(false);
        InventoryActive = false;
        //Inventory.transform.position = TempAnchor.transform.position;
        //isActive = false;
    }

    private void OnEnable()
    {
        inputActions = new XRIDefaultInputActions();

        inventoryButton = inputActions.Inventory.InventoryButton;
        inventoryButton.Enable();
        inventoryButton.started += InventoryToggle;
    }

    private void OnDisable()
    {
        inventoryButton.started -= InventoryToggle;
        inventoryButton.Disable();
    }

    private void InventoryToggle(InputAction.CallbackContext context)
    {
        InventoryActive = !InventoryActive;
        //Inventory.SetActive(UIActive);

        //isActive = !isActive;

        if (InventoryActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.SetParent(Anchor.transform);
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
        else
        {
            Inventory.transform.position = HideAnchor.transform.position;
            Inventory.transform.SetParent(null);
        }
    }
}