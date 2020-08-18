using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCrystal_Y : Dialogue
{
    string[] DialogueText = new string[] {
        "少女：\n"  +  "騎士所配備的劍，應該能用這把劍斬斷藤蔓",
        "少女：\n"  +  "弟弟生前的持有物，心好痛…",
        "少女：\n"  +  "(A切換武器，可以使用劍來砍除藤蔓)",
        /*
        "\n\n"  + 
        "\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0" + 
        "(A切換武器，可以使用劍來砍除藤蔓)",
        */
                                            };


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OpenDialogue();
            DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
        }

    }

    protected override void Start()
    {
        base.Start();
    }

    private void finishDialogue()
    {
        player1.GetSword = true;
        GameObject.Find("劍").GetComponent<Image>().enabled = true;
        PlayerPrefs.SetInt("Sword" + 3, 1);
        CloseDialogue();
        Destroy(gameObject);
    }


    private void Update()
    {
        if (DialogueON && Input.GetKeyDown("c"))
        {
            DialogueID += 1;

            if (DialogueID > DialogueText.Length - 1)
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
