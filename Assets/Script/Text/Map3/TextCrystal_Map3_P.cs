using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCrystal_Map3_P : Dialogue
{/*
    string[] DialogueText = new string[] {
        "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" + "小時候我時常望向窗外的庭院，那裡有一棵被藤蔓寄生的大樹，枯朽且搖搖欲墜。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"我長期臥病在床，一直持續接受治療卻沒有任何起色。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"父母為了我耗費大量心力與金錢，似乎也會委託附近的獵人收集森林的藥草。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"對於家道中落的父親是無法承受的重壓。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"雖然他們在我面前總是表現出沒問題的樣子，但是每天都被逼得焦頭爛額、身形也日益消瘦，讓我十分痛苦。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"為什麼要為我做到這種程度？如果我趕快病死對大家都好……。為什麼當時死的不是我？",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"我就像那些寄生在樹上的藤蔓一樣，不斷吸收這個家的生命力化作自己的養分",

    };
    */

    string[] DialogueText = new string[] {
        "少女：\n"  + "小時候我時常望向窗外的庭院，那裡有一棵被藤蔓寄生的大樹，枯朽且搖搖欲墜。",
    "少女：\n"  +  "我長期臥病在床，一直持續接受治療卻沒有任何起色。",
    "少女：\n"  +  "父母為了我耗費大量心力與金錢，似乎也會委託附近的獵人收集森林的藥草。",
    "少女：\n"  + "對於家道中落的父親是無法承受的重壓。",
    "少女：\n"   +"雖然他們在我面前總是表現出沒問題的樣子，但是每天都被逼得焦頭爛額、身形也日益消瘦，讓我十分痛苦。",
    "少女：\n"   +"為什麼要為我做到這種程度？如果我趕快病死對大家都好……。為什麼當時死的不是我？",
    "少女：\n"  +  "我就像那些寄生在樹上的藤蔓一樣，不斷吸收這個家的生命力化作自己的養分",

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
        GetComponent<Crystal>().ID = 1;
    }

    private void finishDialogue()
    {
        player1.GetSword = true;
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