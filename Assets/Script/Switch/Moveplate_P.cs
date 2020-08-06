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
    public bool remove;
    public bool revserse;
    public bool Auto;
    public bool Goal;
    WaitForSeconds WAS2 = new WaitForSeconds(2);
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
        if(remove) speed *= ReSpeed ;
        

        if (revserse)
        {
            speed *= ReSpeed;
        yield return WAS2;
            StartCoroutine(Move());
        }

    }

    private void Start()
    {
        if (Auto)
        {
            StartCoroutine(Move());
        }
    }















}
