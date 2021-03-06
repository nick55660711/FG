﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_call : Call_P
{
    public static bool OnTrigger;
    public bool MultipleTrigger;
    public SpriteRenderer[] SP2;

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
                    if(MultipleTrigger)

                        foreach (var item in SP2)
                        {
                            item.sprite = Down_S;
                        }
                }
                else
                {
                    SP.sprite = UP_S;
                    if(MultipleTrigger)
                        foreach (var item in SP2)
                        {
                            item.sprite = UP_S;
                        }
                }
                StartCoroutine(trigerON());
            }


        }

    }



    public IEnumerator retun()
    {
        if (Open)
        {
            Open = !Open;
            foreach (var item in Door)
            {
                yield return new WaitUntil(() => { return item.GetComponent<Moveplate_P>().Goal; }); ;
            }
            OnTriger = true;


            {
                SP.sprite = UP_S;
                if (MultipleTrigger)
                    foreach (var item in SP2)
                    {
                        item.sprite = UP_S;
                    }
            }
            StartCoroutine(trigerON());
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
