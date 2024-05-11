using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeScript : MonoBehaviour
{
    public bool isPlayerInside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
