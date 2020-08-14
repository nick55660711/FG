using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Call : Call_P
{
    public static int HitOn;
    public  int HitOn_1;
    public int OnThing;
    public bool MultipleTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if ((collision.CompareTag("Player") || collision.CompareTag("Box")))
        {
            SP.sprite = Down_S;
            OnThing++;
            if (!OnTriger&& OnThing==1)
            {

                OnTriger = true;

                if (MultipleTrigger)
                {
                HitOn += 1;
                HitOn_1 = HitOn; 

                StartCoroutine(trigerON(HitOn));
                }

                else
                StartCoroutine(trigerON());
            }
        } 
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("Box")) )
        {
            OnThing--;
            if(OnThing == 0)
            {
                if (MultipleTrigger)
                {

                    HitOn -= 1;
                    HitOn_1 = HitOn;
                }
            SP.sprite = UP_S;
            }
        }  


    }

    protected override void Start()
    {
        base.Start();
        HitOn = 0;
    }



}
