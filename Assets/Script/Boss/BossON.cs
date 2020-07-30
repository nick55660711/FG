using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossON : MonoBehaviour
{
    public GameObject boss;
    public AudioClip BossBGM;
    public AudioSource SoundManager;
    private void Start()
    {
        SoundManager = FindObjectOfType<AudioSource>();
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.GetComponent<Boss>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            SoundManager.clip = BossBGM;
            SoundManager.Play();
        }
    }

}
