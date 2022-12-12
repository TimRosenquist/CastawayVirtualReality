using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace UIMenu
{
    public class SetMoveType : MonoBehaviour
    {
        public ActionBasedContinuousMoveProvider continuesMove;
        public TeleportationProvider teleportMove;

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

