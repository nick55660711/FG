using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_call : Call_P
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !OnTriger)
        {
            OnTriger = true;
            if (!Open && !switch1)
            {
                SP.sprite = Down_S;
                Open = true;
                StartCoroutine(trigerON());

            }

            if (switch1)
            {
                Open = !Open;
                if (Open)
                {
                    SP.sprite = Down_S;
                }
                else
                {
                    SP.sprite = UP_S;
                }
                StartCoroutine(trigerON());

            }


        }


    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Autore)
        {
            Open = false;
            SP.sprite = UP_S;
        }

    }
}
