using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draba_S : Draba_G
{
    WaitForSeconds WAS3 = new WaitForSeconds(0.0025f);
    WaitForSeconds WAS2 = new WaitForSeconds(1.5f);
    public BoxCollider2D parent;
    public float speed;
    public float Height;
    public float Low;
    Animator ani;
    public override void HIT()
    {
        GetHit = true;
        StopAllCoroutines();
        foreach (var item in GetComponentsInChildren<BoxCollider2D>())
        {
            item.enabled = false;
        }
        WAS3 = new WaitForSeconds((0.0001f));
        //   StartCoroutine(Grow_G_Fall());
        SP.color = new Vector4(1, 1, 1, 0.2f);
        StartCoroutine(vanish());
    }

    IEnumerator vanish()
    {
        while (SP.size.y > 0.1)
        {

            BC.size -= new Vector2(0, 1) * 0.1f;
            BC.offset -= new Vector2(0, 1) * 0.05f;
            parent.size = BC.size;
            parent.offset = BC.offset;
            SP_child.size -= new Vector2(0, 1) * 0.1f;
            SP.size -= new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }

    }
    SpriteRenderer SP;
   
    public  SpriteRenderer SP_child;

    public float SPEEDV;
    BoxCollider2D BC;
    public IEnumerator Grow_G()
    {
        if (GetHit) { print("DEAD"); yield break; }
        if (!GetHit)
        {
            while (SP.size.y < Height+ Random.Range(0, 3))
            {

                BC.size += new Vector2(0, 1) * 0.1f;
                BC.offset += new Vector2(0, 1) * 0.05f;
                parent.size = BC.size;
                parent.offset = BC.offset;
                SP_child.size += new Vector2(0, 1) * 0.1f;
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
       
        while (SP.size.y > Low+Random.Range(0,3))
        {
           
            BC.size -= new Vector2(0, 1) * 0.1f*speed;
            BC.offset -= new Vector2(0, 1) * 0.05f * speed;
            parent.size = BC.size;
            parent.offset = BC.offset;
            SP_child.size -= new Vector2(0, 1) * 0.1f * speed;
            SP.size -= new Vector2(0, 1) * 0.1f * speed;
            yield return WAS3;
        }
        if (GetHit) { Destroy(parent.gameObject); }

    }

    public override void Burn()
    {
        foreach (var item in GetComponentsInChildren<BoxCollider2D>())
        {
            item.enabled = false;
        }
        StopAllCoroutines();
        ani.SetTrigger("Burn");
        Destroy(parent.gameObject, 1.7f);
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


