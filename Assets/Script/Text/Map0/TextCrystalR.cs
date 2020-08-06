using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCrystalR : Dialogue
{

    string[] DialogueText = new string[] {
        "少女：\n" + "\u00A0\u00A0\u00A0\u00A0" + "這是獵人的小屋...水晶內是他的記憶", 
        "少女：\n" + "\u00A0\u00A0\u00A0\u00A0" + "透過獵人的記憶，我掌握了弓的使用方法(X：射出弓箭，可以站在插在牆上的箭)",
    
    
    
    };


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
        player1.GetBow = true;
        PlayerPrefs.SetInt("Bow"+1, 1);
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
