using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCrystal1 : Dialogue
{

    string[] DialogueText = new string[] { "少女：\n" + "\u00A0\u00A0\u00A0\u00A0" + "方向鍵移動、Z跳躍、M叫出選單", };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag( "Player"))
        {
            OpenDialogue();
            DialogueScreen.GetComponentsInChildren<Text>()[1].text = "按下C繼續，按下S跳過對話";
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
                CloseDialogue();
                Destroy(gameObject);
            }

            else 
            {
                DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
            }


        }

        if (DialogueON && Input.GetKeyDown("s"))
        {
            DialogueScreen.GetComponentsInChildren<Text>()[1].gameObject.SetActive(false);
            CloseDialogue();
            Destroy(gameObject);
        }




    }




}
