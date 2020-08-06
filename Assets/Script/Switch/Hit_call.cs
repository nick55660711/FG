using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_call : MonoBehaviour
{
    public GameObject[] Door;
    bool Open;

    SpriteRenderer SP;
    [Header("關閉圖片")]
    public Sprite UP_S;
    [Header("啟動圖片")]
    public Sprite Down_S;
    public bool OnTriger;
    [Header("會自動彈回")]
    public bool re;
    [Header("反覆開關")]
    public bool switch1;
    private void Start()
    {
        SP = GetComponent<SpriteRenderer>();
    }



    IEnumerator trigerON()
    {
        foreach (var item in Door)
        {
            yield return new WaitUntil(() => { return item.GetComponent<Moveplate_P>().Goal; }); ;
        }
        OnTriger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.CompareTag("Arrow")|| collision.collider.CompareTag("Sword")) && !OnTriger)
        {
            OnTriger = true;
            if (!Open && !switch1)
            {
                SP.sprite = Down_S;
                Open = true;
            }

            if (switch1)
            {
                Open = !Open;
                if (Open)
                {
                    SP.sprite = Down_S;
                }
                else
                {
                    SP.sprite = UP_S;
                }
            }

            foreach (var item in Door)
            {
                StartCoroutine(item.GetComponent<Moveplate_P>().Move());
            }
            StartCoroutine(trigerON());
        }

    }
  

  






}
