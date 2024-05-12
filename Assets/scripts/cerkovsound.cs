using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerkovsound : MonoBehaviour
{
    
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioSource _audioSource2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>() != null)
        {

            Destroy(gameObject);
            _audioSource.Play();
            _audioSource2.Play();

        }
    }
}

