﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Call_Uni : Call_P
{
    public int HitOn_1;
    public int OnThing;
    public GameObject[] Steps;

    static AudioSource instance;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if ((collision.CompareTag("Player") || collision.CompareTag("Box")))
        {

            SP.sprite = Down_S;
            OnThing++;
            if (!OnTriger)
            {
                instance.PlayOneShot(StepSound,1);
                OnTriger = true;
                foreach (var item in Steps)
                {

                item.SetActive(!item.activeSelf);
                }

            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("Box")))
        {
            OnThing--;

            if (OnThing == 0)
            {
                instance.PlayOneShot(StepSound,1);
                SP.sprite = UP_S;
                OnTriger = false;
                foreach (var item in Steps)
                {

                    item.SetActive(!item.activeSelf);
                }
            }
        }


    }

    public AudioClip StepSound;
    protected override void Start()
    {
        SP = GetComponent<SpriteRenderer>();
        instance = FindObjectOfType<AudioSource>();
    }
}
