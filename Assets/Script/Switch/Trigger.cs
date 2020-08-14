using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float Ver;
    // public float Dis;
    public float speed;
    public AudioClip MoveSound;
    static AudioSource instance;
    public IEnumerator Move()
    {
        float dis = 0;
        instance.Play();
        while (dis < Ver)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
            dis += Time.deltaTime * Mathf.Abs( speed);
            yield return null;
        }
        instance.Stop();


    }

    private void Start()
    {
        if (instance == null)
        {
            instance = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
            if(instance == null)
            {

            GameObject tmp = new GameObject("SoundEffect");
            instance = tmp.AddComponent<AudioSource>();
            instance.clip = MoveSound;
            instance.loop = true;
            }
        }
    }
}
