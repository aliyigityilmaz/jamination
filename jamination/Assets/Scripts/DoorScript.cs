using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public Animator DoorAnim;
    private bool Kapý;

    public override void OnFocus()
    {
    
    }

    public override void OnHoldInteract()
    {
     
    }

    public override void OnInteract()
    {
        DoorAnim.SetBool("DoorBool", true);
        //Kapý = false;
        //if (Kapý == false)
        //{
        //    DoorAnim.SetBool("DoorBool", true);
        //}

        
        //Kapý= true;
        //if (Kapý == true)
        //{
        //    DoorAnim.SetBool("DoorBool", false);
        //}
    }

    public override void OnLoseFocus()
    {
     
    }

 
}
