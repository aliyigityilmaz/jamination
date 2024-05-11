using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    [Header("Audio")]
    public AudioSource turnOn;
    public AudioSource turnOff;

    [Header("Flashlight Parameters")]
    [SerializeField]
    private bool isOn;
    [SerializeField]
    private bool isOff;
    
    void Start()
    {
        isOff = true;
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOff && Input.GetKeyDown(KeyCode.F))
        {
               flashlight.SetActive(true);
            turnOn.Play();
            isOn = true;
            isOff = false;
        }
        else if (isOn && Input.GetKeyDown(KeyCode.F))
        {
            turnOff.Play();
            isOn = false;
            isOff = true;
            flashlight.SetActive(false);
        }
    }
}
