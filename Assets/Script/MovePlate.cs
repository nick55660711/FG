using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject Door;
    //public float Hor;
    public float Ver;
    // public float Dis;
    public float speed;

    WaitForSeconds WAS2 = new WaitForSeconds(3);
    IEnumerator Move()
    {
        float dis = 0;
        while (dis < Ver)
        {
            Door.transform.Translate(Vector2.up * Time.deltaTime * speed);
            dis += Time.deltaTime * Mathf.Abs( speed);
            yield return null;
        }
            yield return WAS2;

        if (speed > 0) { 
        speed *= -4;
        GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            GetComponent<BoxCollider2D>().enabled = false;
                    StartCoroutine(Move());


        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            StopAllCoroutines();


        }
    }*/

}
