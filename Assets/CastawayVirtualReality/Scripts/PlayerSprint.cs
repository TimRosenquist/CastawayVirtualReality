using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace CastawayVirtualReality
{
public class PlayerSprint : MonoBehaviour
{
        ActionBasedContinuousMoveProvider moveProvider;

    // Start is called before the first frame update
    void Start()
    {
            moveProvider = GetComponent<ActionBasedContinuousMoveProvider>();
            
    }

   
       


    }
}
