using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menüler : MonoBehaviour
{
    public static Menüler instance;

    public bool playerLost;
    public bool playerWin;

    public GameObject loseMenu;
    public GameObject winMenu;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLost)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            loseMenu.SetActive(true);
        }
        if(playerWin)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
               winMenu.SetActive(true);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
