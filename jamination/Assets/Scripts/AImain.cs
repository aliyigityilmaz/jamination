using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImain : MonoBehaviour
{
    //Trigger için
    public Transform Following;
    public static bool FollowCheck= true;
    public float speed = 5f;

    

    

    private void Update()
    {
        if (FollowCheck && Following != null)
        {
            Vector3 dogruvektor = Following.position - transform.position;

            Vector3 hýzvektor = dogruvektor.normalized * speed * Time.deltaTime;

            transform.position += hýzvektor;
        }
    }

    


}
