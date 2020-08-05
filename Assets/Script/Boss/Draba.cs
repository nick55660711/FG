using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draba : Draba_G
{
    WaitForSeconds WAS3 = new WaitForSeconds(0.0005f);
    WaitForSeconds WAS2 = new WaitForSeconds(2);
    SpriteRenderer SP;
    public float SPEEDV;
    BoxCollider2D BC;
    public BoxCollider2D parent;
    IEnumerator Grow_G()
    {

        int V = 1;
        while (SP.size.y < 13f)
        {
            if (transform.GetChild(0).localPosition.x > 0.186f) V = -1;
            if (transform.GetChild(0).localPosition.x < -0.358f) V = 1;
            transform.GetChild(0).Translate(new Vector2(1, 0) * 0.1f * SPEEDV * V);
            transform.GetChild(0).Translate(new Vector2(0, 1) * 0.1f);
            BC.size += new Vector2(0, 1) * 0.1f;
            BC.offset += new Vector2(0, 1) * 0.05f;
            parent.size = BC.size;
            parent.offset = BC.offset;
            SP.size += new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }
        transform.GetChild(0).localPosition = new Vector2(0.186f,14.315f);
        StartCoroutine(Grow_G_Fall());
    }

    IEnumerator Grow_G_Fall()
    {
        int V = -1;
        yield return WAS2;
        while (SP.size.y > 0.1f)
        {
            if (transform.GetChild(0).localPosition.x > 0.186f) V = -1;
            if (transform.GetChild(0).localPosition.x < -0.358f) V = 1;
            transform.GetChild(0).Translate(new Vector2(1, 0) * 0.1f * SPEEDV * V);
            transform.GetChild(0).Translate(new Vector2(0, 1) * -0.1f* speedH);
            BC.size -= new Vector2(0, 1) * 0.1f;
            BC.offset -= new Vector2(0, 1) * 0.05f;
            parent.size = BC.size;
            parent.offset = BC.offset;
            SP.size -= new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }

        Destroy(gameObject);
    }
    int speedH = 1;
    public override void HIT()
    {
        StopAllCoroutines();
        GetComponentInChildren<Rigidbody2D>().gravityScale = 4;
        BC.offset -= new Vector2(0, 2);
        foreach (var item in GetComponentsInChildren<BoxCollider2D>())
        {
            item.enabled = false;
        }
        speedH = 0;
        SPEEDV = 0;
        WAS2 = new WaitForSeconds(0.01f);
        WAS3 = new WaitForSeconds((0.00001f));
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
        B = GetComponentInParent<Boss>();
        parent = transform.GetChild(1).GetComponent<BoxCollider2D>();
        StartCoroutine(Grow_G());
    }
    /*
    private void Update()
    {
        if (B.Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    */
}
