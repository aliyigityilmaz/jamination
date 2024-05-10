using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Instantiate i�in 
    public GameObject canavarPrefab;
    public Transform spawnNoktas�;
    public float spawnGecikmesi = 3f;
    void Start()
    {
        // E�er spawn noktas� belirtilmemi�se, bu script �al��may� sonland�r.
        if (spawnNoktas� == null)
        {
            Debug.LogError("Spawn noktas� belirtilmedi!");
            return;
        }

        // Belirtilen s�re sonunda canavar� spawnlamak i�in Invoke fonksiyonunu kullan�n
        Invoke("CanavarSpawnla", spawnGecikmesi);
    }
    void CanavarSpawnla()
    {
        // Canavar� spawn
        Instantiate(canavarPrefab, spawnNoktas�.position, spawnNoktas�.rotation);
    }


    public virtual void Awake()
    {
        gameObject.layer = 9;
    }
    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
}
