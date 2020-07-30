using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    Rigidbody2D rig;
    public Transform rota;

    public float angle = 120;
    public float speed = 10;
    public Sprite Torch_F;
    BoxCollider2D BOX;
    SpriteRenderer SPR;
    private void Start()
    {
        rota = transform;
       rig = GetComponent<Rigidbody2D>();
        BOX = GetComponent<BoxCollider2D>();
        SPR = GetComponent<SpriteRenderer>();
    }

    WaitForSeconds WAS3 = new WaitForSeconds(0.0025f);
    public IEnumerator Grow_G()
    {

        while (SPR.size.y < 0.69f)
        {
            SPR.size += new Vector2(0, 1) * 0.01f;
            yield return WAS3;
        }

    }
    public void FireUP()
    {
        StartCoroutine(Grow_G());
        BOX.enabled = true; 
    }

    public void HitDown()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        rig.gravityScale = 5;

        GetComponent<BoxCollider2D>().enabled = false;
        float y = rota.localEulerAngles.z;
        float targetY = y + angle;
        while (y < targetY)
        {
            rota.localEulerAngles += Vector3.forward * Time.deltaTime * speed*10;
            y -= Time.deltaTime * speed;
            yield return null;
        }
    }


}
