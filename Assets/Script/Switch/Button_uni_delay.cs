using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_uni_delay : Call_P
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
                instance.PlayOneShot(StepSound, 1);
                OnTriger = true;
                foreach (var item in Steps)
                {

                    item.SetActive(!item.activeSelf);
                }

            }
        }
    }

    public void HitOff(){
        instance.PlayOneShot(StepSound, 1);
        SP.sprite = UP_S;
        OnTriger = false;
        foreach (var item in Steps)
        {

            item.SetActive(!item.activeSelf);
        }
        hold = false;
        if (OnThing > 0)
        {
            SP.sprite = Down_S;
            if (!OnTriger)
            {
                instance.PlayOneShot(StepSound, 1);
                OnTriger = true;
                foreach (var item in Steps)
                {

                    item.SetActive(!item.activeSelf);
                }

            }

        }

    }

    bool hold;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("Box")))
        {
            OnThing--;

            if (OnThing == 0&& !hold)
            {
                hold = true;
                Invoke("HitOff", 0.5f);
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
