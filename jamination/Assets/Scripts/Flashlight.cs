using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    [Header("Battery")]
    public float maxBatteryLevel = 100f;
    public float batteryDrainRate = 0.5f; // Birim: birim/saniye
    private float currentBatteryLevel;

    public Image batteryIndicator;

    void Start()
    {
        isOff = true;
        flashlight.SetActive(false);

        currentBatteryLevel = maxBatteryLevel;
        UpdateBatteryIndicator();

    }

    void Update()
    {
        if (isOff && Input.GetKeyDown(KeyCode.F) && currentBatteryLevel > 0)
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
        if (isOn && currentBatteryLevel > 0)
        {
            currentBatteryLevel -= batteryDrainRate * Time.deltaTime;
            UpdateBatteryIndicator();

            if (currentBatteryLevel <= 0)
            {
                flashlight.SetActive(false);
                isOn = false;
                isOff = true;
            }
        }
    }
    void UpdateBatteryIndicator()
    {
        float fillAmount = currentBatteryLevel / maxBatteryLevel;
        batteryIndicator.fillAmount = fillAmount;
    }
}
