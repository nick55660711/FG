using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float Ver;
    // public float Dis;
    public float speed;

    public IEnumerator Move()
    {
        float dis = 0;
        while (dis < Ver)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
            dis += Time.deltaTime * Mathf.Abs( speed);
            yield return null;
        }

        

    }

    
}
