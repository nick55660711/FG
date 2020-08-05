using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOff : MonoBehaviour
{
    public AudioSource SoundManager;
    private void Start()
    {
        SoundManager = FindObjectOfType<AudioSource>();
    }

    IEnumerator BGMON()
    {

        while (SoundManager.volume < 0.5f)
        {

            SoundManager.volume += 0.7f * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator BGMOFF()
    {


        while (SoundManager.volume > 0)
        {

            SoundManager.volume -= 0.3f * Time.deltaTime;
            yield return null;
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(BGMOFF());

            //SoundManager.Stop();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(BGMON());

        }
    }

}
