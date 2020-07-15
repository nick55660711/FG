using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextNPC_1 : Dialogue
{
    public GameObject HerbImage;


    string[] DialogueText = new string[] {
        "???：\n"  + "\u00A0\u00A0\u00A0\u00A0" + "請蒐集3份藥草",
    
                                            };



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.enabled)
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
        HerbImage.GetComponent<CanvasGroup>().alpha = 1;
        CloseDialogue();
        GetComponent<TextNPC_2>().enabled = true;
        this.enabled = false;
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
