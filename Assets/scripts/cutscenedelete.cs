using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscenedelete : MonoBehaviour
{
    //public GameObject KATSCENA;
    bool active = true;
    public GameObject Cam;
    //private void Update()
    //{
    //    if (active == false )
    //    {
    //        KATSCENA.SetActive(false);
            
            
    //    }
    //}
    void Start()
    {
        //Cam.transform.position = new Vector3(0, 2.522f, 0);
        Cam.SetActive(false);
    }
}
