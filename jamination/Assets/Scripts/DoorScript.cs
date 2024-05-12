using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public Animator DoorAnim;
    

    public override void Update()
    {
        

    }

    IEnumerator KapýSure()
    {
      yield return new WaitForSeconds(3);
       DoorAnim.SetBool("DoorBool", false);
    }

    public override void OnFocus()
    {
    
    }

    public override void OnHoldInteract()
    {
     
    }

    public override void OnInteract()
    {
        Debug.Log("kapýokokok");
        DoorAnim.SetBool("DoorBool", true);
        StartCoroutine("KapýSure");

    }

    public override void OnLoseFocus()
    {
     
    }

 
}
