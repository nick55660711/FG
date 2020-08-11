using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextNPC_2 : Dialogue
{
    public GameObject HerbImage;
    public GameObject Trans;


    string[] DialogueText = new string[] {
        "???：\n"  + "" + "請蒐集3份藥草",
                                            };


    



    bool Re;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Re|| GM.Herb_No == 4)
        {

            if (collision.tag == "Player" && this.enabled)
            {
                if (GM.Herb_No == 4)
                {
                    DialogueText = new string[] {
                    "男：\n"  + "" + "感謝你的協助，城堡的門已經打開了",
                    "女：\n"  + "" + "順便為你進行治療",
                    "女：\n"  + "" + "……希望服用這些藥草後她的病情會好轉",
                                            };

                }
                else
                {
                    DialogueText = new string[] {
                        "???：\n"  + "" + "數量不夠，總共需要4份",
                                            };
                    Re = true;
                }

                OpenDialogue();
                DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
            }

        }
    }

    protected override void Start()
    {
        base.Start();
    }

    private void finishDialogue()
    {
        CloseDialogue();
        if (GM.Herb_No == 4)
        {
            player1.HP = GM.HP_MAX;
            GM.HpUpdate();
            Trans.SetActive(true);
            GetComponent<SaveEvent_2_NPC>().finish();
            this.enabled = false;
        }
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
