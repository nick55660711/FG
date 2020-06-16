using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 標題畫面控制
/// </summary>
public class Title : MonoBehaviour
{
    #region 欄位
    public CanvasGroup Option;
    public CanvasGroup Save;
    public CanvasGroup TitleScreen;














    #endregion

    #region 方法

    public void OptionOpen()
    {
        Option.alpha = 1;
        Option.interactable = true;
        Option.blocksRaycasts = true;
        TitleScreen.interactable = false;

    }
    
    public void OptionClose()
    {
        Option.alpha = 0;
        Option.interactable = false;
        Option.blocksRaycasts = false;
        TitleScreen.interactable = true;


    }
    public void SaveOpen()
    {
        Save.alpha = 1;
        Save.interactable = true;
        Save.blocksRaycasts = true;
        TitleScreen.interactable = false;


    }
    
    public void SaveClose()
    {
        Save.alpha = 0;
        Save.interactable = false;
        Save.blocksRaycasts = false;
        TitleScreen.interactable = true;

    }









    #endregion

    #region 事件













    #endregion










}
