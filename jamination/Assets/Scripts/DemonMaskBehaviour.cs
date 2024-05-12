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
    public GameObject door;

    [Header("Position")]
    [SerializeField] private Transform hallPosition;
    [SerializeField] private Transform doorPosition;
    [SerializeField] private Transform roomPosition;

    private bool chasePlayer;

    private float timer = 0;

    [Header("Bools")]
    public bool goingToRoom;
    public bool goingToDoor;
    public bool goingToHall;
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

        door = GameObject.FindWithTag("Kapý");

        if (door != null)
        {
            AnimDoor = door.GetComponent<Animator>();
            
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        if (AnimDoor.GetBool("DoorBool") == true)
        {
            agent.SetDestination(doorPosition.position);
            if (Vector3.Distance(this.gameObject.transform.position, doorPosition.transform.position) < 3)
            {
                timer += Time.deltaTime;
                Debug.Log(timer);
                if (timer > 5)
                {
                    agent.SetDestination(roomPosition.position);
                    
                }
            }
        }
        else
        {
            timer = 0;
            agent.SetDestination(hallPosition.position);
            door.GetComponent<DoorScript>().isOpened = false;
        }

        if (Vector3.Distance(transform.position, roomPosition.transform.position) < 2)
        {
            timer = 0;
            //player dolapta deðilse
            if (!GameObject.Find("Kapak").GetComponent<WardrobeScript>().isPlayerInside)
            {
                chasePlayer = true;
            }
            else if (GameObject.Find("Kapak").GetComponent<WardrobeScript>().isPlayerInside && chasePlayer == false)
            {
                StartCoroutine(GoBack());
                door.GetComponent<DoorScript>().isOpened = false;
            }
        }
        if (chasePlayer)
        {
            agent.SetDestination(player.transform.position);
            if (Vector3.Distance(transform.position, player.transform.position) < 1)
            {
                //oyunu bitir
            }
        }

        if (goingToDoor)
        {
            agent.SetDestination(doorPosition.position);
        }
        if (goingToRoom)
        {
            agent.SetDestination(roomPosition.position);
        }
        if (goingToHall)
        {
            agent.SetDestination(hallPosition.position);
        }
    }

    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(1);
        agent.SetDestination(hallPosition.position);
    }

}
