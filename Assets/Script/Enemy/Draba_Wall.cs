using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draba_Wall : MonoBehaviour
{
    WaitForSeconds WAS3 = new WaitForSeconds(0.0025f);
    WaitForSeconds WAS2 = new WaitForSeconds(2);
    SpriteRenderer[] SP;

    public void HIT()
    {
        StartCoroutine(Grow_G_Fall());
    }

    BoxCollider2D BC;
    
    IEnumerator Grow_G_Fall()
    {
        while (SP[0].size.y > -2)
        {

            BC.size -= new Vector2(0, 1) * 0.1f;
            BC.offset -= new Vector2(0, 1) * 0.05f;
            for (int i = 0; i < transform.childCount; i++)
            {
                SP[i].size -= new Vector2(0, 1) * 0.1f;
            }
            yield return WAS3;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            HIT();
        }
    }

    private void Start()
    {
         SP = new SpriteRenderer[transform.childCount] ;
        

        for (int i = 0; i < transform.childCount; i++)
        {
            SP[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();

        }

        BC = transform.parent.GetComponent<BoxCollider2D>();
       
    }
}
