using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCrystal2 : Dialogue
{

    string[] DialogueText = new string[] { "少女：\n" + "    這是第一句話", "少女：\n" + "    這是第二句話" };

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


    private void Update()
    {
        if (DialogueON && Input.GetKeyDown("c"))
        {
                DialogueID += 1;

            if (DialogueID  > DialogueText.Length -1 )
            {
                print(DialogueID + "" + DialogueText.Length + "if");
                CloseDialogue();
                Destroy(gameObject);
            }

            else 
            {
                print(DialogueID+ "" + DialogueText.Length + "else" );
                DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
            }


        }

        if (DialogueON && Input.GetKeyDown("s"))
        {
            CloseDialogue();
            Destroy(gameObject);
        }




    }




}
