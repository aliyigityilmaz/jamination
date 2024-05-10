using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Instantiate için 
    public GameObject canavarPrefab;
    public Transform spawnNoktasý;
    public float spawnGecikmesi = 3f;
    void Start()
    {
        // Eðer spawn noktasý belirtilmemiþse, bu script çalýþmayý sonlandýr.
        if (spawnNoktasý == null)
        {
            Debug.LogError("Spawn noktasý belirtilmedi!");
            return;
        }

        // Belirtilen süre sonunda canavarý spawnlamak için Invoke fonksiyonunu kullanýn
        Invoke("CanavarSpawnla", spawnGecikmesi);
    }
    void CanavarSpawnla()
    {
        // Canavarý spawn
        Instantiate(canavarPrefab, spawnNoktasý.position, spawnNoktasý.rotation);
    }


    public virtual void Awake()
    {
        gameObject.layer = 9;
    }
    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
}
