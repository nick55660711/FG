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
   




    public IEnumerator Move()
    {
        Goal = false;
        float dis = 0;
        if (horiz)
        {

            while (dis < Hor)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                dis += Time.deltaTime * Mathf.Abs(speed);
                yield return null;
            }
        }

        if (vertic)
        {

            while (dis < Ver)
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
                dis += Time.deltaTime * Mathf.Abs(speed);
                yield return null;
            }
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

    private void Start()
    {
        if (AutoStart)
        {
            StartCoroutine(Move());
        }
    }

     













}
