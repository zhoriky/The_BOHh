using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Death : MonoBehaviour
{
    public GameObject gameOver;
    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemyai>() != null)
        {
            PlayerisDead();
            gameOver.SetActive(true);
            gameOver.GetComponent<VideoPlayer>().Play();
        }

    }
    private void PlayerisDead()
    {
        GetComponent<FirstPersonMovement>().enabled = false;
        GetComponentInChildren<FirstPersonLook>().enabled = false;
        AudioListener.volume = 0f;
    }
}
