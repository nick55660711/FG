using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtest : MonoBehaviour
{
    AudioSource SM;
    void Start()
    {
        SM = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        print(SM.time);
        SM.time +=Input.GetAxis("Horizontal")*Time.deltaTime ;
    }
}
