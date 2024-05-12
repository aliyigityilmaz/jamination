using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AkilSagligi : MonoBehaviour
{
    public static AkilSagligi instance;
    public GameObject door;

    public Image akilSagligiBar;
    // Start is called before the first frame update
    void Start()
    {
            instance = this;
        door = GameObject.FindWithTag("Kapý");
    }

    // Update is called once per frame
    void Update()
    {
        if (door != null)
        {
               if (door.GetComponent<DoorScript>().isOpened)
            {
                akilSagligiBar.fillAmount += 0.04f * Time.deltaTime;
            }
               else
            {
                   akilSagligiBar.fillAmount -= 0.03f * Time.deltaTime;
            }

               if (akilSagligiBar.fillAmount <= 0)
            {
                Menüler.instance.playerLost = true;
            }
        }
    }
}
