using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DemonMaskBehaviour : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    public Animator AnimDoor;
    public bool DoorCheck;

    [Header("Position")]
    [SerializeField] private Transform hallPosition;
    [SerializeField] private Transform doorPosition;
    [SerializeField] private Transform roomPosition;

    private bool chasePlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        hallPosition = GameObject.FindWithTag("Pos/Hall").transform;
        doorPosition = GameObject.FindWithTag("Pos/Door").transform;
        roomPosition = GameObject.FindWithTag("Pos/Room").transform;

        chasePlayer = false;
        agent.SetDestination(hallPosition.position);
        StartCoroutine(GoToDoor());
    }

    IEnumerator GoToDoor()
    {
        yield return new WaitForSeconds(20);
        agent.SetDestination(doorPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, doorPosition.transform.position));
        DoorCheck = AnimDoor.GetBool("DoorBool");

        if (agent != null)
        {
            if (Vector3.Distance(transform.position, doorPosition.transform.position) < 30 )
            {
                //e�er kap� a��k de�ilse
                if (DoorCheck)
                {
                    StartCoroutine(GoToRoom());
                }
                else
                {
                   
                }
            }

            if (Vector3.Distance(transform.position, roomPosition.transform.position) < 1)
            {
                //player dolapta de�ilse
                if(!GameObject.Find("Kapak").GetComponent<WardrobeScript>().isPlayerInside)
                {
                    chasePlayer = true;
                }
                else if(GameObject.Find("Kapak").GetComponent<WardrobeScript>().isPlayerInside && chasePlayer == false)
                {
                    StartCoroutine(GoBack());
                }
            }

            if(chasePlayer)
            {
                agent.SetDestination(player.transform.position);
                if (Vector3.Distance(transform.position, player.transform.position) < 1)
                {
                    //oyunu bitir
                }
            }
        }
    }

    IEnumerator GoToRoom()
    {
        yield return new WaitForSeconds(1);
        agent.SetDestination(roomPosition.position);
    }

    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(1);
        agent.SetDestination(hallPosition.position);
        if(agent != null)
        {
            Destroy(gameObject, 10f);
        }
    }

}
