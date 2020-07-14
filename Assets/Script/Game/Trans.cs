using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trans : MonoBehaviour
{
    public Player player1 ;
    [Header("傳送位置")]
    public GameObject Trans1 ;
    public bool Enter;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player")) 
        {
            Enter = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Enter = false;
        }
    }

    

    

    private void Start()
    {
        player1 = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Enter  && Input.GetKeyDown("up"))
        {
            player1.transform.position = Trans1.transform.position;

        }
    }


}
