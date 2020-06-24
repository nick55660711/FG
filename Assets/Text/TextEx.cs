using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEx : Dialogue
{
    string[] DialogueText = new string[] {
        "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" + "示範用～",
        "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" + "示範用～～"
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
        CloseDialogue();
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
