using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextNPC_1 : Dialogue
{
    public GameObject HerbImage;


    string[] DialogueText = new string[] {
        "少女：\n"  + "" + "請問要如何才能進入城堡。",
        "???：\n"  + "" + "如果你協助我們，就讓你進入城堡。\n"+ ""+"希望你收集附近的藥草，對我們家小孩的病情會很有幫助的。",
        "???：\n"  + "" + "請蒐集4份藥草。",
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
        //sHerbImage.GetComponent<CanvasGroup>().alpha = 1;
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
