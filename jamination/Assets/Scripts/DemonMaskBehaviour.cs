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

    [Header("Position")]
    [SerializeField] private Transform hallPosition;
    [SerializeField] private Transform doorPosition;
    [SerializeField] private Transform roomPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        agent.SetDestination(hallPosition.position);
        StartCoroutine(GoToDoor());
    }

    IEnumerator GoToDoor()
    {
        yield return new WaitForSeconds(15);
        agent.SetDestination(doorPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent != null)
        {
            if (Vector3.Distance(transform.position, doorPosition.transform.position) < 1)
            {
                //eðer kapý açýk deðilse
                if (true)
                {
                    StartCoroutine(GoToRoom());
                }
                else
                {
                    Destroy(gameObject, 3f);
                }
            }

            if (Vector3.Distance(transform.position, roomPosition.transform.position) < 1)
            {
                //player dolapta deðilse
                if(true)
                {
                    agent.SetDestination(player.transform.position);
                    if (Vector3.Distance(transform.position, player.transform.position) < 1)
                    {
                        //oyunu bitir
                    }
                }
                else
                {
                    StartCoroutine(GoBack());
                }
            }
        }
    }

    IEnumerator GoToRoom()
    {
        yield return new WaitForSeconds(10);
        agent.SetDestination(roomPosition.position);
    }

    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(5);
        agent.SetDestination(hallPosition.position);
        if(agent != null)
        {
            Destroy(gameObject, 10f);
        }
    }

}
