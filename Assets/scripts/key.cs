using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    bool active = false;
    public GameObject CAnvas;
    public GameObject KATSCENA;
    public GameObject Cam;
    private void Update()
    {
        if (active == true && Input.GetKeyDown(KeyCode.E))
        {
            KATSCENA.SetActive(true);
            gameObject.SetActive(false);
            Cam.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>() != null)
        {

            CAnvas.SetActive(true);

            active = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonMovement>() != null)
        {

            CAnvas.SetActive(false);

            active = false;

        }
    }
}
