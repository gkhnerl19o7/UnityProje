using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    GameObject nesne;
    void Start()
    {
        nesne = new GameObject();
        nesne.transform.position = GameObject.Find("Top").transform.position;
        transform.parent = nesne.transform;
    }


    void Update()
    {
        nesne.transform.position = GameObject.Find("Top").transform.position;
        float yon = Input.GetAxis("Horizontal");
        nesne.transform.eulerAngles = new Vector3(nesne.transform.eulerAngles.x, nesne.transform.eulerAngles.y + yon, nesne.transform.eulerAngles.z);
    }
}
