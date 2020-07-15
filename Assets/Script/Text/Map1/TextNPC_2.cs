using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextNPC_2 : Dialogue
{
    public GameObject HerbImage;
    public GameObject Trans;


    string[] DialogueText = new string[] {
        "???：\n"  + "\u00A0\u00A0\u00A0\u00A0" + "請蒐集3份藥草",
                                            };
    
    




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& this.enabled)
        {
            if(GM.Herb_No == 3) {
                DialogueText = new string[] {
                    "???：\n"  + "\u00A0\u00A0\u00A0\u00A0" + "已完成，後面沒路了",
                                            };

            }
            else
            {
                DialogueText = new string[] {
                        "???：\n"  + "\u00A0\u00A0\u00A0\u00A0" + "數量不足",
                                            };
            }

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
        if (GM.Herb_No == 3) { HerbImage.GetComponent<CanvasGroup>().alpha = 0; Trans.SetActive(true) ; this.enabled = false; }
        else { DialogueID = 0; }
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
