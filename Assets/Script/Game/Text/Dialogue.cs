using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    #region 欄位
    public CanvasGroup DialogueScreen;
    public Player player1;
    
    public int DialogueID;
    public bool DialogueON;




    #endregion

    #region 方法

    

    public void OpenDialogue()
    {
        DialogueScreen.alpha = 1;
        DialogueScreen.blocksRaycasts = true;
        DialogueScreen.interactable = true;
        Time.timeScale = 0;
        DialogueON = true;
    }
    public void CloseDialogue()
    {
        DialogueScreen.alpha = 0;
        DialogueScreen.blocksRaycasts = false;
        DialogueScreen.interactable = false;
        Time.timeScale = 1;
        DialogueON = false;

    }

    



    #endregion

    #region 事件


    /// <summary>
    /// 呼叫成員，重置對話編號
    /// </summary>
    protected virtual void Start()
    {
        DialogueScreen = GameObject.Find("DialogueScreen").GetComponent<CanvasGroup>();
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        DialogueID = 0;
    }
   



    #endregion





}
