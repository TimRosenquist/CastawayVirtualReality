using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace UIMenu
{
    public class SetTurnType : MonoBehaviour
    {
        public ActionBasedSnapTurnProvider snapTurn; // Gives you access to the Snap Turn function for the VR and gives it a variable for later use in the code
        public ActionBasedContinuousTurnProvider continousTurn; // Gives you access to the Continous Turn function for the VR and gives it a variable for later use in the code

        // In this function we use the earlier declared variables to be able to switch between the two rotating types, depending if the player 
        // wants to make a snap turn or a continous turn based on index numbers 0 and 1
        public void SetTypeFromIndex (int index)
        {
            if (index == 0)
            {
                snapTurn.enabled = false;
                continousTurn.enabled = true;
            }
            else if (index == 1)
            {
                snapTurn.enabled = true;
                continousTurn.enabled = false;
            }
        }
    }
}

