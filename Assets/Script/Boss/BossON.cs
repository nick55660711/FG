using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossON : MonoBehaviour
{
    public GameObject boss;
    public GameObject SoundOn_E;
    public GameObject SoundOff_E;
    public AudioClip BossBGM;
    public AudioSource SoundManager;
    private void Start()
    {
        SoundManager = FindObjectOfType<AudioSource>();
    }
   
    IEnumerator BGMON()
    {


        SoundManager.volume = 0.15f;
            SoundManager.Play();
        while (SoundManager.volume < 0.5f)
        {

            SoundManager.volume += 0.1f * Time.deltaTime;
            yield return null;
        }
      //  Destroy(SoundOn_E);
        Destroy(SoundOff_E);
    }

          

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.Stop();
            boss.GetComponent<Boss>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            SoundManager.clip = BossBGM;
            StartCoroutine(BGMON());
            

        }
    }

}
