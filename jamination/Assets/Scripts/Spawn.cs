using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Instantiate i�in 
    public GameObject canavarPrefab;
    public Transform spawnNoktas�;
    public float spawnGecikmesi = 3f; //spawn s�resi 

    //Transform i�in
    public Transform PlayerTransform;
    public AImain canavar;
    void Start()
    {
        //canavar�n karakteri bulmas� i�in
        canavar.Following = PlayerTransform;

        // E�er spawn noktas� belirtilmemi�se, bu script �al��may� sonland�r.
        if (spawnNoktas� == null)
        {
            Debug.LogError("Spawn noktas� belirtilmedi!");
            return;
        }

        // Belirtilen s�re sonunda canavar� spawnlamak i�in 
        Invoke("CanavarSpawnla", spawnGecikmesi);
    }
    void CanavarSpawnla()
    {
        Instantiate(canavarPrefab, spawnNoktas�.position, spawnNoktas�.rotation);
    }

}
