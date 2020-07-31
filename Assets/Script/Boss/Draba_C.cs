using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draba_C : MonoBehaviour
{
    WaitForSeconds WAS3 = new WaitForSeconds(0.01f);
    WaitForSeconds WAS2 = new WaitForSeconds(2);
    SpriteRenderer SP;
    public float SPEEDV;
    BoxCollider2D BC;
    IEnumerator Grow_G()
    {
        /*
        while (T < 100)
        {
            if (transform.GetChild(0).localPosition.x > 0.1f) V = -1;
            if (transform.GetChild(0).localPosition.x < -0.4f) V = 1;
            transform.GetChild(0).Translate(new Vector2(1, 0) * 0.1f * SPEEDV * V);
            T++;
            yield return WAS3;
        }
        */
        while (SP.size.y < 8f)
        {
            /*
            if (transform.GetChild(0).localPosition.x > 0.1f) V = -1;
            if (transform.GetChild(0).localPosition.x < -0.4f) V = 1;
            transform.GetChild(0).Translate(new Vector2(1, 0) * 0.1f * SPEEDV * V);
            transform.GetChild(0).Translate(new Vector2(0, 1) * 0.1f);
            */
            BC.size += new Vector2(0, 1) * 0.1f;
            BC.offset += new Vector2(0, 1) * 0.05f;
            SP.size += new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }
    }

    IEnumerator Grow_G_Fall()
    {
        while (SP.size.y > 0.1f)
        {   /*
            if (transform.GetChild(0).localPosition.x > 0.1f) V = -1;
            if (transform.GetChild(0).localPosition.x < -0.4f) V = 1;
            transform.GetChild(0).Translate(new Vector2(1, 0) * 0.1f * SPEEDV * V);
            transform.GetChild(0).Translate(new Vector2(0, 1) * -0.1f);
             */
            BC.size -= new Vector2(0, 1) * 0.1f;
            BC.offset -= new Vector2(0, 1) * 0.05f;
            SP.size -= new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }

        Destroy(gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Torch")
        {
        StopAllCoroutines();
        collision.GetComponent<Torch>().HitDown();
        StartCoroutine(Grow_G_Fall());
        }

    }

    private void Start()
    {
        SP = GetComponent<SpriteRenderer>();
        BC = GetComponent<BoxCollider2D>();
        StartCoroutine(Grow_G());
    }

}
