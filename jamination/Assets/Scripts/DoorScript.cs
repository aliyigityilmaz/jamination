using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public Animator DoorAnim;

    public bool isOpened;

    public AudioSource openSound;
    public AudioSource closeSound;
    private void Start()
    {
        DoorAnim = GetComponent<Animator>();
        isOpened = false;
        DoorAnim.SetBool("DoorBool", false);
    }

    public override void Update()
    {
        if (isOpened)
        {
            DoorAnim.SetBool("DoorBool", true);
            isOpened = true;
        }
        else
        {
            DoorAnim.SetBool("DoorBool", false);
            isOpened = false;
            
        }

    }

    public override void OnFocus()
    {
    
    }

    public override void OnHoldInteract()
    {
     
    }

    public override void OnInteract()
    {
        isOpened = !isOpened;
        if (isOpened)
        {
            openSound.Play();
        }
        else
        {
            closeSound.Play();
        }
    }

    public override void OnLoseFocus()
    {
     
    }

 
}
