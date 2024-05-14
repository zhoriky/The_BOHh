using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    
    [SerializeField] AudioSource _audioSource;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>() != null)
        {
            
            Destroy(gameObject);
            _audioSource.Play();
            

        }
    }
}
