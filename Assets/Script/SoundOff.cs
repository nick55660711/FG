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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            SoundManager.Stop();
        }
    }

}
