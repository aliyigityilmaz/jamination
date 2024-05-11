using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Instantiate i�in 
    public GameObject demonMaskPrefab;
    public Transform spawnPos;
    public float spawnGecikmesi = 3f; //spawn s�resi 

    public bool spawned;

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
        Instantiate(demonMaskPrefab, spawnPos.position, spawnPos.rotation);
    }

    private void Update()
    {
        if (!spawned)
        {
            spawned = true;
            Invoke("CanavarSpawnla", spawnGecikmesi);
        }
    }

}
