using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public Animator DoorAnim;
    private bool Kap�;

    public override void OnFocus()
    {
    
    }

    public override void OnHoldInteract()
    {
     
    }

    public override void OnInteract()
    {
        DoorAnim.SetBool("DoorBool", true);
        //Kap� = false;
        //if (Kap� == false)
        //{
        //    DoorAnim.SetBool("DoorBool", true);
        //}

        
        //Kap�= true;
        //if (Kap� == true)
        //{
        //    DoorAnim.SetBool("DoorBool", false);
        //}
    }

    public override void OnLoseFocus()
    {
     
    }

 
}
