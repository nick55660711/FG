using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTriger : MonoBehaviour
{
    public GameObject Door;
    public GameObject Draba1;
    public GameObject Draba2;
    bool Open;
   
    SpriteRenderer SP;
    public Sprite UP_S;
    public Sprite Down_S;
    public bool draba , re;

    private void Start()
    {
      SP =  GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!Open)
        {
            StartCoroutine(Door.GetComponent<Trigger>().Move());
            if (draba) {
            Destroy(Draba1);
            Destroy(Draba2);
            }
            SP.sprite = Down_S;
        }
        Open = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& re)
        {
            SP.sprite = UP_S;
        }

    }



}
