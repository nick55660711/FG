using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEvent_1 : Dialogue
{

    string[] DialogueText = new string[] { "少女：\n" + "    這是第一句話" , "少女：\n" + "    這是第二句話" };


private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Player")
    {
        Invoke("OpenDialogue", 0.5f);
        DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
    }

}

protected override void Start()
{
    base.Start();
}


    private void Update()
    {
        if (DialogueON && Input.GetKeyDown("c"))
        {
            DialogueID += 1;
            if (DialogueID > DialogueText.Length - 1)
            {
                CloseDialogue();
                //關閉提示訊息
                DialogueScreen.GetComponentsInChildren<Text>()[1].gameObject.SetActive(false);
                Destroy(gameObject);
            }

            else
            {
                DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
            }

        }

        if (DialogueON && Input.GetKeyDown("s"))
        {
            CloseDialogue();
            //關閉提示訊息
            DialogueScreen.GetComponentsInChildren<Text>()[1].gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }
}
