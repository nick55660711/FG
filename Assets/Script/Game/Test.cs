using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Respwan;
    void Update()
    {
        if (Input.GetKeyDown("r")) { transform.position = Respwan.transform.position; }
    }
}
