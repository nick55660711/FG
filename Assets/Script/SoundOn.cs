using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOn : MonoBehaviour
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

            SoundManager.volume += 0.1f * Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            //SoundManager.Stop();
            StartCoroutine(BGMON());

        }
    }
}
