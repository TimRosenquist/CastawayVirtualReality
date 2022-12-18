using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Inventory
{
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
        // Sets the inventory status to "disabled" at start
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
        // Toggles the inventory
        InventoryActive = !InventoryActive;

        // Places the inventory on the hand anchor when the inventory gets activated and rotates it upward
        if (InventoryActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.SetParent(Anchor.transform);
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
        // Removes the inventory from the hand anchor when the inventory gets deactivated
        else
        {
            Inventory.transform.position = HideAnchor.transform.position;
            Inventory.transform.SetParent(null);
        }
    }
}
}