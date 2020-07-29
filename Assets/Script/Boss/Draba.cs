using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draba : Draba_G
{
    WaitForSeconds WAS3 = new WaitForSeconds(0.001f);
    WaitForSeconds WAS2 = new WaitForSeconds(2);
    SpriteRenderer SP;
    public float SPEEDV;
    BoxCollider2D BC;
    IEnumerator Grow_G()
    {

            int V = -1;
        while (SP.size.y < 13f)
        {
            
            if (transform.GetChild(0).localPosition.x> 0.1f) V = -1;
            if (transform.GetChild(0).localPosition.x < -0.4f) V = 1;
            transform.GetChild(0).Translate(new Vector2(1, 0) * SPEEDV * V);
            transform.GetChild(0).Translate(new Vector2(0, 1) * 0.1f);
            BC.size += new Vector2(0, 1) * 0.1f;
            BC.offset += new Vector2(0, 1) * 0.05f;
            SP.size += new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }
        StartCoroutine(Grow_G_Fall());
    }
    IEnumerator Grow_G_Fall()
    {
        int V = -1;
        yield return WAS2;
        while (SP.size.y > 0.1f)
        {
            if (transform.GetChild(0).localPosition.x > 0.1f) V = -1;
            if (transform.GetChild(0).localPosition.x < -0.4f) V = 1;
            transform.GetChild(0).Translate(new Vector2(1, 0) * SPEEDV * V);
            transform.GetChild(0).Translate(new Vector2(0, 1) * -0.1f);
            BC.size -= new Vector2(0, 1) * 0.1f;
            BC.offset -= new Vector2(0, 1) * 0.05f;
            SP.size -= new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }

        Destroy(gameObject);
    }

    public void HIT()
    {
        StopAllCoroutines();
        WAS2 = new WaitForSeconds(0.1f);
        StartCoroutine(Grow_G_Fall());
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
        SP = GetComponent<SpriteRenderer>();
        BC = GetComponent<BoxCollider2D>();
        
        StartCoroutine(Grow_G());
    }
}
