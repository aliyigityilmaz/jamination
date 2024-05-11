using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Instantiate i�in 
    public GameObject demonMaskPrefab;
    public Transform spawnPos;

    public bool spawned;
    private GameObject instanceObject;
    //Transform i�in
    void Start()
    {
        //canavar�n karakteri bulmas� i�in

        // E�er spawn noktas� belirtilmemi�se, bu script �al��may� sonland�r.
        if (spawnPos == null)
        {
            Debug.LogError("Spawn noktas� belirtilmedi!");
            return;
        }

    }
    void CanavarSpawnla()
    {
        instanceObject = Instantiate(demonMaskPrefab, spawnPos.position, spawnPos.rotation);
    }

    private void Update()
    {
        if (!spawned)
        {
            spawned = true;
            CanavarSpawnla();
        }
        if (spawned && instanceObject == null)
        {
            spawned = false;
        }
    }

}
