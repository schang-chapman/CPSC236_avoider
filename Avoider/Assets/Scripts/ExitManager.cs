using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public GameObject victoryText;

    void Start()
    {
        victoryText.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            victoryText.SetActive(true);
            Application.Quit();
            Debug.Log("Endscreen Quitting");
        }
    }
}
