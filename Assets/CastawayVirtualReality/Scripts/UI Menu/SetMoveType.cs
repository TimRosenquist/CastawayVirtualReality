using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace UIMenu
{
    public class SetMoveType : MonoBehaviour
    {
        public ActionBasedContinuousMoveProvider continuesMove; // Gives you access to the Continous Movement function for the VR and gives it a variable for later use in the code
        public TeleportationProvider teleportMove; // Gives you access to the Teleportation function for the VR and gives it a variable for later use in the code

        // In this function we use the earlier declared variables to be able to switch between the two movement types, depending if the player 
        // wants to move around with Continous Movement or by using Teleportation based on index numbers 0 and 1
        public void SetTypeFromIndex(int index)
        {
            if (index == 0)
            {
                teleportMove.enabled = false;
                continuesMove.enabled = true;
            }
            else if (index == 1)
            {
                teleportMove.enabled = true;
                continuesMove.enabled = false;
            }
        }
    }
}

