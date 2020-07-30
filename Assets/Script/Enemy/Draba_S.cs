using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draba_S : Draba_G
{
    WaitForSeconds WAS3 = new WaitForSeconds(0.0025f);
    WaitForSeconds WAS2 = new WaitForSeconds(2);
    public BoxCollider2D parent;

    public override void HIT()
    {
        foreach (var item in GetComponentsInChildren<BoxCollider2D>())
        {
            item.enabled = false;
        }
        StopAllCoroutines();
        WAS2 = new WaitForSeconds(0.1f);
        WAS3 = new WaitForSeconds((0.0001f));
        GetHit = true;
      
        StartCoroutine(Grow_G_Fall());
    }

    SpriteRenderer SP;
    public float SPEEDV;
    BoxCollider2D BC;
    public IEnumerator Grow_G()
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
        StopAllCoroutines();
        StartCoroutine(Grow_G_Fall());
    }

    IEnumerator Grow_G_Fall()
    {
        yield return WAS2;
        while (SP.size.y > 0.1f)
        {
           
            BC.size -= new Vector2(0, 1) * 0.1f;
            BC.offset -= new Vector2(0, 1) * 0.05f;
            parent.size = BC.size;
            parent.offset = BC.offset;
            SP.size -= new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }
        if (GetHit) { Destroy(parent.gameObject); }

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
     // parent = transform.parent.GetComponent<BoxCollider2D>();
      parent = transform.GetComponent<BoxCollider2D>();
    }
    
}


