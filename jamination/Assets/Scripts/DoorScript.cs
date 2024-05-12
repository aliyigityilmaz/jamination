using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public Animator DoorAnim;
    public static bool Kapý = true;

    public override void Update()
    {
        
        if (Kapý == false)
        {
            KapýSure();
            Kapý = true;
        }
    }

    IEnumerator KapýSure()
    {
      yield return new WaitForSeconds(3);
    }

    public override void OnFocus()
    {
    
    }

    public override void OnHoldInteract()
    {
     
    }

    public override void OnInteract()
    {

        DoorAnim.SetBool("DoorBool", true);
        Kapý = false;
        if (Kapý == false)
        {
            KapýSure();
            DoorAnim.SetBool("DoorBool", false);
        }

        
    }

    public override void OnLoseFocus()
    {
     
    }

 
}
