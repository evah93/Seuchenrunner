using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Screen : MonoBehaviour
{
    public GameObject Endscrn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Endscrn.gameObject.SetActive(true);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("BaseCityGame");

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
