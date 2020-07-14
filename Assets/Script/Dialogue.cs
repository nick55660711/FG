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
    public GameManager GM;



    #endregion

    #region 方法



    public void OpenDialogue()
    {
        DialogueScreen.alpha = 1;
        DialogueScreen.blocksRaycasts = true;
        DialogueScreen.interactable = true;
        GM.GamePause();
        DialogueON = true;
    }
    public void CloseDialogue()
    {
        DialogueScreen.alpha = 0;
        DialogueScreen.blocksRaycasts = false;
        DialogueScreen.interactable = false;
        GM.GameContinue();
        DialogueON = false;

    }

    



    #endregion

    #region 事件


    /// <summary>
    /// 呼叫成員，重置對話編號
    /// </summary>
    protected virtual void Start()
    {
        GM = FindObjectOfType<GameManager>();
        DialogueScreen = GameObject.Find("DialogueScreen").GetComponent<CanvasGroup>();
        player1 = FindObjectOfType<Player>();
        DialogueID = 0;
    }
   



    #endregion





}
