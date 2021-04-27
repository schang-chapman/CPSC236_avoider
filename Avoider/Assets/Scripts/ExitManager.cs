using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public GameObject victoryText;
    public GameObject player;

    void Start()
    {
        victoryText.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            victoryText.SetActive(true);
            player.SetActive(false);
            Application.Quit();
            Debug.Log("Endscreen Quitting");
        }
    }
}
