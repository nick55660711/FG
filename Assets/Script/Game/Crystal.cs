using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    #region 欄位
    public int ID;
    public CanvasGroup DialogueScreen;
    public Player player1;
    public bool DialogueON;

    /*
    string[] Dialogue = new string[] { "少女：\n" + "    這是第一句話"};
    public int DialogueID ;
    */




    #endregion

    #region 方法

    public void GetItem()
    {
        
    }


    public void OpenDialogue()
    {
        DialogueScreen.alpha = 1;
        DialogueScreen.blocksRaycasts = true;
        DialogueScreen.interactable = true;
        Time.timeScale = 0;
        DialogueON =  true;
    }
    public void CloseDialogue()
    {
        DialogueScreen.alpha = 0;
        DialogueScreen.blocksRaycasts = false;
        DialogueScreen.interactable = false;
        Time.timeScale = 1;
        DialogueON =  false;
    }
    
    /*
    public void CallDialogue(int ID) 
    {

        if (DialogueON && Input.GetKeyDown("z"))
        {

        }

        int dialogueID = 0 ;
       switch (ID)
        {
            // 水晶編號為0(一般水晶)，則回覆血量
            case 0:
                player1.Hp += 10;
                player1.HpText.text = "Hp：" + player1.Hp;
                break;

            case 1:
                OpenDialogue();
                string[] dialogue1 = { };

                DialogueScreen.GetComponentInChildren<Text>().text = dialogue1[dialogueID];

                
                break;
           
            
            
            case 2:
                OpenDialogue();
                int dialogueID2 = 0;
                string[] dialogue2 = { };

                DialogueScreen.GetComponentInChildren<Text>().text = dialogue2[dialogueID2];


                break;

        }

    }
    */


    #endregion

    #region 事件
    private void Start()
    {
        DialogueScreen = GameObject.Find("DialogueScreen").GetComponent<CanvasGroup>();
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }
    private void Update()
    {
       


    }

    #endregion




}
