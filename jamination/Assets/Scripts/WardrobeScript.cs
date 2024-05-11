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

        if(Kapak == true)
        {
            OpenAnim.SetBool("DolapBool", false);
        }

    }

    public override void OnInteract()
    {
        OpenAnim.SetBool("DolapBool", true);
        Kapak = true;
        player.isStatic = true;
        player.transform.position = InWardrob;

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

    }

    public override void OnHoldInteract()
    {
 
    }

    public override void OnLoseFocus()
    {

    }
}
