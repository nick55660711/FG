using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draba_R : Draba_G
{
    WaitForSeconds WAS3 = new WaitForSeconds(0.0025f);
    WaitForSeconds WAS2 = new WaitForSeconds(1.5f);
    public BoxCollider2D parent;
    public float speed;
    [Header("生長長度：下藤蔓 5.2f 上藤蔓 10f ")]
    public float Length;
    Animator ani;

    public override void HIT()
    {
        GetHit = true;
        StopAllCoroutines();
        foreach (var item in GetComponentsInChildren<BoxCollider2D>())
        {
            item.enabled = false;
        }
        StopAllCoroutines();
        WAS2 = new WaitForSeconds(0.05f);
        WAS3 = new WaitForSeconds((0.0001f));
        StartCoroutine(Grow_G_Fall());
    }

    SpriteRenderer SP;
    BoxCollider2D BC;
    public IEnumerator Grow_G()
    {
        WaitForSeconds WAS2 = new WaitForSeconds(Random.Range(1f, 2));
        yield return WAS2;
        if (GetHit) { print("DEAD"); yield break; }
        if (!GetHit)
        {
            while (SP.size.y < Length+ Random.Range(-1, 5))
            {

                BC.size += new Vector2(0, 1) * 0.1f;
                BC.offset += new Vector2(0, 1) * 0.05f;
                parent.size = BC.size;
                parent.offset = BC.offset;
                SP.size += new Vector2(0, 1) * 0.1f;
                yield return WAS3;
            }
        }
        StartCoroutine(Grow_G_Fall());
    }

   

    IEnumerator Grow_G_Fall()
    {
        WaitForSeconds WAS2 = new WaitForSeconds(Random.Range(0.3f,2));
        yield return  WAS2;
        while (SP.size.y > 0.1f)
        {

            BC.size -= new Vector2(0, 1) * 0.1f * speed;
            BC.offset -= new Vector2(0, 1) * 0.05f * speed;
            parent.size = BC.size;
            parent.offset = BC.offset;
            SP.size -= new Vector2(0, 1) * 0.1f * speed;
            yield return WAS3;
        }
        if (GetHit) { Destroy(parent.gameObject); }
        StartCoroutine(Grow_G());
    }

    public override void Burn()
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
        ani = GetComponent<Animator>();
        SP = GetComponent<SpriteRenderer>();
        BC = GetComponent<BoxCollider2D>();
        // parent = transform.parent.GetComponent<BoxCollider2D>();
        parent = transform.parent.GetComponent<BoxCollider2D>();
        StartCoroutine(Grow_G());
    }

}
