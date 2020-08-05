using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCrystal1 : Dialogue
{
    WaitForSeconds WAS = new WaitForSeconds(1);
    WaitForSeconds WAS2 = new WaitForSeconds(1.5f);
    WaitForSeconds WAS3 = new WaitForSeconds(0.2f);
    string[] DialogueText = new string[] 
    {
        "少女：\n" + "\u00A0\u00A0\u00A0\u00A0" + "這裡是?",
        "少女：\n" + "\u00A0\u00A0\u00A0\u00A0" + "想不起來了……",
        "少女：\n" + "\u00A0\u00A0\u00A0\u00A0" + "奇怪的水晶，在觸碰到的時候好像可以回想起一些事",
        "少女：\n" + "\u00A0\u00A0\u00A0\u00A0" + "這裡是某座森林，而且我似乎很熟悉這片森林",
        "少女：\n" + "\u00A0\u00A0\u00A0\u00A0" + "四處探索，找尋更多水晶看看吧" + "(移動：方向鍵、Z：跳躍、M：選單)"

    };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag( "Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(Opening());

        }
    }

    IEnumerator Opening()
    {
        player1.Stop = true;
        player1.transform.eulerAngles = new Vector3(0, 0, 0);
        player1.transform.Rotate(Vector3.forward * -90);
        yield return WAS2;
        player1.transform.Rotate(Vector3.forward * 90);

        //player1.transform.Translate(Vector3.up * 2);
        player1.rig.AddForce(new Vector2(0, 600));

        yield return WAS;
        while (player1.transform.position.x < -10)
        {

            player1.rig.velocity = new Vector2(1.3f, 0);
            yield return WAS3;
        }

        player1.rig.velocity = new Vector2(0, 0);

        OpenDialogue();
        DialogueON = false;
        Time.timeScale = 1;
        for (int i = 0; i < 2; i++)
        {
            DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
            DialogueID += 1;
            yield return WAS2;
        }
        CloseDialogue();

        player1.transform.eulerAngles = new Vector3(0, 180, 0);
        while (player1.transform.position.x > -13.4)
        {
            player1.rig.velocity = new Vector2(-3, 0);
            yield return WAS3;
        }

        player1.rig.velocity = new Vector2(0, 0);

        OpenDialogue();
        DialogueON = false;
        Time.timeScale = 1;
        for (int i = 0; i < 2; i++)
        {
            DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
            DialogueID += 1;
            yield return WAS2;
            yield return WAS2;
        }

        DialogueON = true;
        GM.GetItem(0);
        DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
        DialogueScreen.GetComponentsInChildren<Text>()[1].text = "按下C繼續";
    }

    private void finishDialogue()
    {
        player1.Stop = false;
        CloseDialogue();

        Destroy(gameObject);
    }


    protected override void Start()
    {
        base.Start();
        //水晶編號設為1
    }


    private void Update()
    {
        if (DialogueON && Input.GetKeyDown("c"))
        {
                DialogueID += 1;

            if (DialogueID  > DialogueText.Length -1 )
            {
                finishDialogue();
            }

            else 
            {
                DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
            }


        }

        if (DialogueON && Input.GetKeyDown("s"))
        {
            finishDialogue();
        }




    }




}
