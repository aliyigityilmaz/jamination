using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AImain : MonoBehaviour
{
    //Trigger için
    public Transform Following;
    public static bool FollowCheck= true;
    public float speed = 5f;

    public NavMeshAgent agent;

    private void Update()
    {
        if (FollowCheck && Following != null)
        {

            agent.SetDestination(Following.position);

            //Vector3 dogruvektor = Following.position - transform.position;

            //Vector3 hýzvektor = dogruvektor.normalized * speed * Time.deltaTime;

            //transform.position += hýzvektor;
        }
    }

    


}
