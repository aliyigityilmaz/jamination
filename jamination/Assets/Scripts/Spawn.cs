using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Instantiate için 
    public GameObject canavarPrefab;
    public Transform spawnNoktasý;
    public float spawnGecikmesi = 3f; //spawn süresi 

    //Transform için
    public Transform PlayerTransform;
    public AImain canavar;
    void Start()
    {
        //canavarýn karakteri bulmasý için
        canavar.Following = PlayerTransform;

        // Eðer spawn noktasý belirtilmemiþse, bu script çalýþmayý sonlandýr.
        if (spawnNoktasý == null)
        {
            Debug.LogError("Spawn noktasý belirtilmedi!");
            return;
        }

        // Belirtilen süre sonunda canavarý spawnlamak için 
        Invoke("CanavarSpawnla", spawnGecikmesi);
    }
    void CanavarSpawnla()
    {
        Instantiate(canavarPrefab, spawnNoktasý.position, spawnNoktasý.rotation);
    }

}
