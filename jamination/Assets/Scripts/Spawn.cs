using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Instantiate için 
    public GameObject demonMaskPrefab;
    public Transform spawnPos;

    public bool spawned;
    private GameObject instanceObject;
    //Transform için
    void Start()
    {
        //canavarýn karakteri bulmasý için

        // Eðer spawn noktasý belirtilmemiþse, bu script çalýþmayý sonlandýr.
        if (spawnPos == null)
        {
            Debug.LogError("Spawn noktasý belirtilmedi!");
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
