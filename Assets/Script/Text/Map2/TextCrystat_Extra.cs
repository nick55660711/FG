using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCrystat_Extra : Dialogue
{
    string[] DialogueText = new string[] {
        "少女：\n"  + "" + "這裡是我的家。",
        "少女：\n"  + "" + "我家的家庭成員有父親、母親、弟弟還有我。",
        "少女：\n"  + "" + "我們家族原先還能稱為貴族，可是近幾代平庸懶散而不甚奮發導致家道中落，現在就是虛有頭銜的落難貴族而已。",
        "少女：\n"  + "" + "也因此弟弟的夢想是被選為直屬騎士，立下功勳重振家族。",
        "少女：\n"  + "" + "……",

                                            };

    public GameObject family_pictrue;
    public GameObject family_pictrue_tmp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Canvas tmp = FindObjectOfType<Canvas>();
            family_pictrue_tmp = Instantiate(family_pictrue, tmp.transform);
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
        PlayerPrefs.SetInt("Sword" + 1, 1);
        Destroy(family_pictrue_tmp);
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
