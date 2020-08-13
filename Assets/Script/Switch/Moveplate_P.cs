using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplate_P : MonoBehaviour
{

    public float Hor;
    public float Ver;
    //public float Dis;
    public float speed;
    public float ReSpeed;

    public bool horiz;
    public bool vertic;

    [Header("反向移動")]
    public bool remove;
    [Header("自動反向移動")]
    public bool revserse;
    public bool AutoStart;
    public bool Goal = true;
    public bool detect;
    //public AudioSource SoundManager;
    public AudioClip MoveSound;
    public float volume;
    [Header("自動恢復")]
    public bool AutoReset;
    
    WaitForSeconds WAS2 = new WaitForSeconds(2);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && detect&&Goal)
        {
        StartCoroutine(Move());
        }
    }

    public bool Open;
    [Header("需要按下的複數開關數量")]
    public int OpenNO;

    static AudioSource instance;
   

    
    public IEnumerator Move(int TriggerNO)
    {
       

        if (TriggerNO == OpenNO && !Open)
        {
            Open = true;
            Goal = false;
            float dis = 0;
            if (horiz)
            {
                instance.Play();

                while (dis < Hor)
                {
                    transform.Translate(Vector2.right * Time.deltaTime * speed);
                    dis += Time.deltaTime * Mathf.Abs(speed);
                   yield return null;
                }
                instance.Stop();

            }

            if (vertic)
            {
                instance.Play();
                while (dis < Ver)
                {
                    transform.Translate(Vector2.up * Time.deltaTime * speed);
                    dis += Time.deltaTime * Mathf.Abs(speed);
                    yield return null;
                }
                instance.Stop();
            }

            Goal = true;

        }

    }




    public IEnumerator Move()
    {


        if (Goal)
        {

        Goal = false;
        float dis = 0;
        if (horiz)
        {
            instance.Play();
            while (dis < Hor)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                dis += Time.deltaTime * Mathf.Abs(speed);
                yield return null;
            }
            instance.Stop();
        }

        if (vertic)
        {
            instance.Play();
            while (dis < Ver)
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
                dis += Time.deltaTime * Mathf.Abs(speed);
                yield return null;
            }
            instance.Stop();
        }

        Goal = true;
        if(remove)
            speed *= ReSpeed ;

        


        if (revserse)
        {
            speed *= ReSpeed;
        yield return WAS2;
            StartCoroutine(Move());
        }
        }

    }

    private void Start()
    {
       // SoundManager = FindObjectOfType<AudioSource>();
        if (instance == null)
        {
            GameObject tmp = new GameObject("SoundEffect");
            instance = tmp.AddComponent<AudioSource>();
            instance.clip = MoveSound;
            instance.loop = true;
        }

        print(gameObject.name);

        if (AutoStart)
        {
            StartCoroutine(Move());
        }
    }

     













}
