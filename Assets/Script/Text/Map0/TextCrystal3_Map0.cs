using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCrystal3_Map0 : Dialogue
{
    string[] DialogueText = new string[] {
       "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" + "呼，精神稍微穩定下來了，這些水晶到底是？",
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
        //水晶編號設為1
        GetComponent<Crystal>().ID = 1;
    }

    private void finishDialogue()
    {

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
