using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplate2 : MonoBehaviour
{
    //public float Hor;
    public float Ver;
    // public float Dis;
    public float speed;

    WaitForSeconds WAS2 = new WaitForSeconds(2);
    IEnumerator Move()
    {
        float dis = 0;
        while (dis < Ver)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            dis += Time.deltaTime * Mathf.Abs(speed);
            yield return null;
        }

        yield return WAS2;

            speed *= -1;
        StartCoroutine(Move());
        
    }

    private void Start()
    {
        
    StartCoroutine(Move());
    }




}
