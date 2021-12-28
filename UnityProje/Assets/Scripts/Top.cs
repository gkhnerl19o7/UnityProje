using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{

    public AudioClip[] sesler;


    void OnCollisionEnter(Collision nesne) 
    {
        if (nesne.gameObject.tag=="direk")
        {
            GetComponent<AudioSource>().PlayOneShot(sesler[1]);
        }
    }
   

}
