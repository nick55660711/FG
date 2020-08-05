using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTriger : MonoBehaviour
{
    public GameObject Door;
    public GameObject Draba1;
    public GameObject Draba2;
    bool Open;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!Open)
        {
            StartCoroutine(Door.GetComponent<Trigger>().Move());
            Destroy(Draba1);
            Destroy(Draba2);
        }

        Open = true;
    }



}
