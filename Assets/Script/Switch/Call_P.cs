using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call_P : MonoBehaviour
{
    public GameObject[] Door;
    public bool Open;

    protected SpriteRenderer SP;
    [Header("關閉圖片")]
    public Sprite UP_S;
    [Header("啟動圖片")]
    public Sprite Down_S;
    [Header("會自動彈回")]
    public bool Autore;
    [Header("反覆開關")]
    public bool switch1;

    [Header("延遲彈回時間")]
    public float delaytime;
    /*
    [Header("延遲彈回")]
    public bool delay;
    */
    public bool OnTriger;
    protected virtual void Start()
    {
        SP = GetComponent<SpriteRenderer>();
    }



    protected virtual IEnumerator trigerON()
    {
        foreach (var item in Door)
        {
            StartCoroutine(item.GetComponent<Moveplate_P>().Move());
        }

        foreach (var item in Door)
        {
        yield return new WaitUntil(() => { return item.GetComponent<Moveplate_P>().Goal; }); ;
        }
        //if(!delay)
        OnTriger = false;

    }

    protected virtual IEnumerator trigerON(int TriggerNO)
    {
        foreach (var item in Door)
        {
            StartCoroutine(item.GetComponent<Moveplate_P>().Move(TriggerNO));
        }

        foreach (var item in Door)
        {
            yield return new WaitUntil(() => { return item.GetComponent<Moveplate_P>().Goal; }); ;
        }
        OnTriger = false;
    }



}
