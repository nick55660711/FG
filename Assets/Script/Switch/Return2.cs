using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return2 : MonoBehaviour
{
    public Switch_call swith;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           StartCoroutine( swith.retun());
        }
    }
}
