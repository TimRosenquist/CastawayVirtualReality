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

    private XRIDefaultInputActions inputActions;
    private InputAction inventoryButton;

    private void Start()
    {
        InventoryActive = false;
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