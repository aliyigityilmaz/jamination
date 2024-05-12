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
    
    
    public AudioSource demonSound;
    public AudioSource hallSound;
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
            goingToDoor = true; goingToHall = false; goingToRoom = false;
            GetReadyToEnter();
        }
        else if(AnimDoor.GetBool("DoorBool") == false && goingToDoor == false)
        {
            goingToHall = true; goingToDoor = false; goingToRoom = false;
            door.GetComponent<DoorScript>().isOpened = false;
        }

        if (AnimDoor.GetBool("DoorBool") == false && goingToDoor == true)
        {
            if (Vector3.Distance(this.gameObject.transform.position, doorPosition.transform.position) < 2)
            {
                
                door.GetComponent<DoorScript>().openSound.Play();
                door.GetComponent<DoorScript>().isOpened = true;
            }
        }

        if (Vector3.Distance(transform.position, roomPosition.transform.position) < 2 && goingToRoom)
        {
           timer = 0;
            //player dolapta deðilse
            if (!GameObject.Find("Kapak").GetComponent<WardrobeScript>().isPlayerInside)
            {
                demonSound.Play();
                chasePlayer = true; goingToRoom = false; goingToDoor = false; goingToHall = false;
            }
            else if (GameObject.Find("Kapak").GetComponent<WardrobeScript>().isPlayerInside && chasePlayer == false)
            {
                StartCoroutine(GoBack());
                hallSound.Play();
                door.GetComponent<DoorScript>().isOpened = false;
                door.GetComponent<DoorScript>().closeSound.Play();
            }
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
        {
            Menüler.instance.playerLost = true;
        }

        if (Vector3.Distance(transform.position, hallPosition.transform.position) < 2)
        {
            goingToRoom = false; goingToDoor = true; goingToHall = false;
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
            timer = 0;
        }
        if (chasePlayer)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void GetReadyToEnter()
    {
        if (Vector3.Distance(this.gameObject.transform.position, doorPosition.transform.position) < 3)
        {

            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= 5)
            {
                goingToRoom = true; goingToDoor = false; goingToHall = false;
                Debug.Log("Entered");

            }
        }
    }

    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(1);
        goingToHall = true; goingToDoor = false; goingToRoom = false;
    }

}
