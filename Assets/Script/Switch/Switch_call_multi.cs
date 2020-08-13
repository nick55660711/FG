using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_call_multi : Call_P
{
    public static bool OnTrigger;
    public bool MultipleTrigger;
    public SpriteRenderer[] SP2;

    protected override IEnumerator trigerON()
    {
        foreach (var item in Door)
        {
            StartCoroutine(item.GetComponent<Moveplate_P>().Move());
        }

        foreach (var item in Door)
        {
            yield return new WaitUntil(() => { return item.GetComponent<Moveplate_P>().Goal; }); ;
        }
        OnTrigger = false;

    }





    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !OnTrigger)
        {
            OnTrigger = true;
            if (!Open && !switch1)
            {
                SP.sprite = Down_S;
                Open = true;
                StartCoroutine(trigerON());
            }

            if (switch1)
            {
                Open = !Open;
                if (Open)
                {
                    SP.sprite = Down_S;
                    if (MultipleTrigger)

                        foreach (var item in SP2)
                        {
                            item.sprite = Down_S;
                        }
                }
                else
                {
                    SP.sprite = UP_S;
                    if (MultipleTrigger)
                        foreach (var item in SP2)
                        {
                            item.sprite = UP_S;
                        }
                }
                StartCoroutine(trigerON());
            }


        }


    }
  
}
