using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draba_S : Draba_G
{
    WaitForSeconds WAS3 = new WaitForSeconds(0.0025f);
    WaitForSeconds WAS2 = new WaitForSeconds(1.5f);
    public BoxCollider2D parent;
    public float speed;
    Animator ani;
    public override void HIT()
    {
        GetHit = true;
        print("Hit");
        StopAllCoroutines();
        foreach (var item in GetComponentsInChildren<BoxCollider2D>())
        {
            item.enabled = false;
        }
        WAS2 = new WaitForSeconds(0.05f);
        WAS3 = new WaitForSeconds((0.0001f));
        print("Hit2");
        StartCoroutine(Grow_G_Fall());
        print("Hit3");
    }

    SpriteRenderer SP;
    public float SPEEDV;
    BoxCollider2D BC;
    public IEnumerator Grow_G()
    {
        if (GetHit) { print("DEAD"); yield break; }
        if (!GetHit)
        {
            while (SP.size.y < 13f)
            {

                BC.size += new Vector2(0, 1) * 0.1f;
                BC.offset += new Vector2(0, 1) * 0.05f;
                parent.size = BC.size;
                parent.offset = BC.offset;
                SP.size += new Vector2(0, 1) * 0.1f;
                yield return WAS3;
            }
        }
    }

    public void Fall()
    {

        StopAllCoroutines();
        StartCoroutine(Grow_G_Fall());
    }

    IEnumerator Grow_G_Fall()
    {
        yield return WAS2;
       
        while (SP.size.y > 1f)
        {
           
            BC.size -= new Vector2(0, 1) * 0.1f*speed;
            BC.offset -= new Vector2(0, 1) * 0.05f * speed;
            parent.size = BC.size;
            parent.offset = BC.offset;
            SP.size -= new Vector2(0, 1) * 0.1f * speed;
            yield return WAS3;
        }
        if (GetHit) { Destroy(parent.gameObject); }

    }

    public void Burn()
    {
        foreach (var item in GetComponentsInChildren<BoxCollider2D>())
        {
            item.enabled = false;
        }
        StopAllCoroutines();
        ani.SetTrigger("Burn");
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
        ani= GetComponent<Animator>();
        SP = GetComponent<SpriteRenderer>();
        BC = GetComponent<BoxCollider2D>();
     // parent = transform.parent.GetComponent<BoxCollider2D>();
      parent = transform.GetComponent<BoxCollider2D>();
    }
    
}


