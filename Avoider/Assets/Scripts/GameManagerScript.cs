using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playButton;
    public GameObject quitButton;

    void Start()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playButton.SetActive(true);
            quitButton.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ContinueGame(bool cont)
    {
        if (cont)
        {
            Time.timeScale = 1;
            playButton.SetActive(false);
            quitButton.SetActive(false);
        }
        else
        {
            Application.Quit();
            Debug.Log("Quitting from Menu");
        }
    }
}
