using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public static AudioClip soundCoins, soundEnemyDeath, soundEnemyHit, soundLevelGeschafft, soundPlayerJump;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayerJump = Resources.Load<AudioClip>("SoundPlayerJump");
        //soundEnemyDeath = Resources.Load<AudioClip>("SoundEnemyDeath");
        soundEnemyHit = Resources.Load<AudioClip>("SoundEnemyHit");
        //soundLevelGeschafft = Resources.Load<AudioClip>("SoundLevelGeschafft");
        soundCoins = Resources.Load<AudioClip>("SoundCoins");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string clip)
    {
        //Debug.Log("Playing sound " + clip);
        switch (clip)
        {
            case "jump":
                audioSource.PlayOneShot(soundPlayerJump);
                break;
            case "hit":
                audioSource.PlayOneShot(soundEnemyHit);
                break;
            case "coins":
                audioSource.PlayOneShot(soundCoins);
                break;
        }
    }
}
