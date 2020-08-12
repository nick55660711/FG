using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Call_Uni : Call_P
{
    public int HitOn_1;
    public int OnThing;
    public GameObject Step;

    static AudioSource instance;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if ((collision.CompareTag("Player") || collision.CompareTag("Box")))
        {

            SP.sprite = Down_S;
            OnThing++;
            if (!OnTriger)
            {
                instance.PlayOneShot(StepSound,0.8f);
                OnTriger = true;
                Step.SetActive(OnTriger);

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
                instance.PlayOneShot(StepSound,0.8f);
                SP.sprite = UP_S;
                OnTriger = false;
                Step.SetActive(OnTriger);
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
