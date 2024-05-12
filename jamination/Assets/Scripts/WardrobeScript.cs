using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeScript : Interactable
{

    public Animator OpenAnim;
    private bool Kapak = false;
    public GameObject player;
    public Vector3 InWardrob;

    public bool isPlayerInside;

    void Start()
    {
        
    }
    void Update()
    {

    }

    public override void OnInteract()
    {
        player.transform.position = InWardrob;
        //player.isStatic = true;
        

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInside = false;
        }
    }

    public override void OnFocus()
    {
        OpenAnim.SetBool("DolapBool", true);
        Kapak = true;
    }

    public override void OnHoldInteract()
    {
 
    }

    public override void OnLoseFocus()
    {
        if (Kapak == true)
        {
            OpenAnim.SetBool("DolapBool", false);
        }

    }
}
