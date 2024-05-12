using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Interactable
{
    public override void OnFocus()
    {
    }

    public override void OnHoldInteract()
    {
        Debug.Log("Battery is charging");
        Flashlight.instance.ChargeBattery(0.05f);
    }

    public override void OnInteract()
    {
    }

    public override void OnLoseFocus()
    {
    }
}
