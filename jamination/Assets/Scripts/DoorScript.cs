using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public Animator DoorAnim;
    public static bool Kap� = true;

    public override void Update()
    {
        
        if (Kap� == false)
        {
            Kap�Sure();
            Kap� = true;
        }
    }

    IEnumerator Kap�Sure()
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
        Kap� = false;
        if (Kap� == false)
        {
            Kap�Sure();
            DoorAnim.SetBool("DoorBool", false);
        }

        
    }

    public override void OnLoseFocus()
    {
     
    }

 
}
