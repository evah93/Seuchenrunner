using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneVertical: MonoBehaviour
{
    //Zeug, das man für die Levels braucht
    //public LevelManager levelManager;

    //Positionen
    private Vector3 startPos;
    private Vector3 newPos;
    private Vector3 tempPos;

    public float speed;
    public float patrolrange;

    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        //levelManager = FindObjectOfType<LevelManager>();

        //aktuelle Position auslesen
        startPos = transform.position;

        //zufällige Geschwindigkeit
        speed = Random.Range(5f, 10f);

        tempPos = startPos;

        sr = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Drone patroulliert
        newPos = startPos;
        newPos.y = newPos.y + Mathf.PingPong(Time.time * speed, patrolrange);
        transform.position = newPos;

        //aktuelle Position abspeichern
        tempPos = newPos;
    }

    /*void OnCollisionEnter2D(Collision2D other)
    {
        //bei Berührung mit Player Neustart (des aktuellen Levels)
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }*/
}
