using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] public int m_Life = 3;

    

    public static GameMaster gm;
    public static Text livesText;

    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    public Transform playerPrefab;
    public Transform spawnPoint;

    public static void CheckPoint(Transform checkpoint)
    {
        gm.spawnPoint = checkpoint;
    }

    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public static void KillPlayer(GameObject player)
    {
        Destroy(player.gameObject);
        gm.m_Life -= 1;
        Debug.Log("Er hat " + gm.m_Life);
        livesText = GameObject.Find("LivesText").GetComponent<Text>();  //Anzeige die Anzahl der Leben;
        livesText.text = "Lives: " + gm.m_Life;                         // Ein Leben weg;

        if (gm.m_Life == 0)
        {
            Debug.Log("GameOver");                                      // Fangen wir das Spiel von vorne;
            SceneManager.LoadScene("GameOver");
        }
        gm.RespawnPlayer();

    }
}

