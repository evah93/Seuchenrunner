using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    
    public Transform spawnposition;
    // Start is called before the first frame update
    private void Awake()
    {
        spawnposition = GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Checkpoint erreicht");
            GameMaster.CheckPoint(spawnposition);

        }
    }
}
