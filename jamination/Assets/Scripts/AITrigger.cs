using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AImain.FollowCheck = false;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AImain.FollowCheck = true;
        }
    }
}
