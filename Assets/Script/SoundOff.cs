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

    IEnumerator BGMOFF()
    {


        while (SoundManager.volume > 0)
        {

            SoundManager.volume -= 0.1f * Time.deltaTime;
            yield return null;
        }


     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            //SoundManager.Stop();
            StartCoroutine(BGMOFF());

        }
    }

}
