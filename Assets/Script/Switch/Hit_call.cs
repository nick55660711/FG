﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_call : Call_P
{
   
   



    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.CompareTag("Arrow")|| collision.collider.CompareTag("Sword")) && !OnTriger)
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
  

  






}
