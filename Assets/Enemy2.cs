using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{
    public float speed;
    public Vector3[] positions;
    public GameObject enemyExplosion;

    private int currentPos;
    private bool m_FacingRight = true;  // For determining which way the go is currently facing.


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameMaster.KillPlayer(collision.gameObject);     //Leben abziehen
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("Gegner ist getötet");      //Bekommt Punkte???
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentPos], speed);
        if (transform.position == positions[currentPos])
        {
            if (currentPos < positions.Length - 1)
            {
                currentPos++;
            }
            else
            {
                currentPos = 0;
            }
        }

    /*private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }*/

}
}
