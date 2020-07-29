using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossON : MonoBehaviour
{
    public GameObject boss;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.GetComponent<Boss>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }

}
