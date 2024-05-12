using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookScript : Interactable
{
    [SerializeField]
    private Image progressBar;

    [SerializeField]
    private GameObject particle;

    private GameObject particleInstance;

    public override void Awake()
    {
        base.Awake();
        progressBar = GameObject.FindWithTag("UI/ProgressBar").GetComponent<Image>();
        progressBar.fillAmount = 0;
        
    }
    public override void OnFocus()
    {
        if (particleInstance != null) return;
        particleInstance = Instantiate(particle, transform.position, Quaternion.LookRotation(particle.transform.forward));
    }

    public override void OnInteract()
    {
        
    }

    public override void OnHoldInteract()
    {
        progressBar.fillAmount += 0.05f * Time.deltaTime;
        if (progressBar.fillAmount >= 1)
        {
            Menüler.instance.playerWin = true;
            Debug.Log("Book is read");
        }
    }

    public override void OnLoseFocus()
    {
        Destroy(particleInstance, 0.5f);
    }
}
