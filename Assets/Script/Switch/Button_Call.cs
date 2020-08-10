using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Call : Call_P
{
    public static int HitOn;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        SP.sprite = Down_S;

        if ((collision.CompareTag("Player") || collision.CompareTag("Box")) && !OnTriger)
        {
            OnTriger = true;
            if (!Open && !switch1)
            {
                Open = true;
                StartCoroutine(trigerON());

                HitOn += 1;
            }


        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("Box")) && Autore)
        {
            HitOn -= 1;
            SP.sprite = UP_S;
        }  


    }





}
