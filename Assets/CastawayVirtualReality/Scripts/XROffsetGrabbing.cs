using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Player
{
    //Inherent the class XRGrabInteractable
public class XROffsetGrabbing : XRGrabInteractable
{
    
    // Start is called before the first frame update
    void Start()
    {
        //Create attach point if non exist
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grab Pivot");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        } 
    }

    //Transform and rotate object attach point to controller position
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        attachTransform.position = args.interactorObject.transform.position;
        attachTransform.rotation = args.interactorObject.transform.rotation;
    }

}
}
