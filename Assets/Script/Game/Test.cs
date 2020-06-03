using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Respwan;
    void Update()
    {
        if (Input.GetKeyDown("r")) { transform.position = Respwan.transform.position; }


        if (transform.localPosition.y < -10)
        {
            transform.localPosition = new Vector3(-5, 2, 0);
        }
    }



}
