using SCI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomDirectInteractor : XRDirectInteractor
{
    public DB db;

    public enum HandType { LEFT, RIGHT };
    public HandType e_HandType = HandType.LEFT;

    void Start()
    {
        selectEntered.AddListener(OnGrabEvent);
        selectExited.AddListener(OnReleaseEvent);
    }

    public void OnGrabEvent(SelectEnterEventArgs args)
    {
        if (e_HandType == HandType.LEFT)
        {
            db.leftWeapon = args.interactableObject.transform.name;
        }
        else
        {
            db.rightWeapon = args.interactableObject.transform.name;
        }
    }

    public void OnReleaseEvent(SelectExitEventArgs args)
    {
        if (e_HandType == HandType.LEFT)
        {
            db.leftWeapon = "";
        }
        else
        {
            db.rightWeapon = "";
        }

    }

}
