using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Call : Call_P
{
   
   


   

    private void OnTriggerStay2D(Collider2D collision)
    {
        SP.sprite = Down_S;

        if ((collision.CompareTag("Player") || collision.CompareTag("Box")) && !OnTriger)
        {
            OnTriger = true;
            if (!Open && !switch1)
            {
                Open = true;
                StartCoroutine(trigerON());

            }


        }

    }

    bool Ondelay;
    bool buttonUP;
    public IEnumerator DelayRe()
    {

        yield return new WaitForSeconds(delaytime);
        SP.sprite = UP_S;
        buttonUP = true;
        foreach (var item in Door)
        {
            StartCoroutine(item.GetComponent<Moveplate_P>().Move());
        }
        foreach (var item in Door)
        {
            yield return new WaitUntil(() => { return item.GetComponent<Moveplate_P>().Goal; }); ;
        }

        buttonUP = false;
        Open = false;
        Ondelay = false;
    }

    /*
    public IEnumerator DelayRe_call()
    {

    }
    */

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("Box")) && Autore&&!Ondelay)
        {
            Ondelay = true;
            StartCoroutine(DelayRe());
           
        }  

        if(buttonUP) SP.sprite = UP_S;

    }





}
