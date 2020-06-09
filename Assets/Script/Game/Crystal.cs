using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    #region 欄位
    public int ID;
    public CanvasGroup DialogueScreen;
    public Player player1;
    string[] Dialogue = new string[] { "少女：\n" + "    這是第一句話", "" };
    public int DialogueID ;





    #endregion

    #region 方法

    public void GetItem()
    {
        CallCrystal(ID);
    }


    public void OpenDialogue()
    {
        DialogueScreen.alpha = 1;
        DialogueScreen.blocksRaycasts = true;
        DialogueScreen.interactable = true;
        Time.timeScale = 0;
    }
    public void CloseDialogue()
    {
        DialogueScreen.alpha = 0;
        DialogueScreen.blocksRaycasts = false;
        DialogueScreen.interactable = false;
        Time.timeScale = 1;
    }

    public void CallCrystal(int ID) 
    {
       switch (ID)
        {
            // 水晶編號為0(一般水晶)，則回覆血量
            case 0:
                player1.Hp += 10;
                player1.HpText.text = "Hp：" + player1.Hp;
                break;

            case 1:
                OpenDialogue();
                DialogueScreen.GetComponentInChildren<Text>().text = Dialogue[DialogueID];

                
                break;
           
            
            
            case 2:

                break;

        }

    }



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
