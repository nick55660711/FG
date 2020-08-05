using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Door;
    //public float Hor;
    public float Ver;
   // public float Dis;
    public float speed;
    [Header("1 = 觸發移動 2=持續移動")]
    public int ID;

    IEnumerator Move()
    {
        float dis = 0;
        while (dis<Ver)
        {
            Door.transform.Translate(Vector2.up * Time.deltaTime *speed);
            dis += Time.deltaTime *speed;
            yield return null;
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (ID)
            {
                case 1:
            StartCoroutine(Move());
                    break;
            }


        }
    }

}
