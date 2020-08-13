using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 標題畫面控制
/// </summary>
public class Title : MonoBehaviour
{
    #region 欄位
    public CanvasGroup Option;
    public CanvasGroup Save;
    public CanvasGroup TitleScreen;

    //聲音控制
    bool SoundOFF;
    public Slider SoundSlider;
    [Header("聲音按鈕圖片")]
    public Image SoundButtonImage;
    [Header("聲音開啟圖片")]
    public Sprite SoundOpenSprite;
    [Header("聲音關閉圖片")]
    public Sprite SoundCloseSprie;









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


    public void ClickSoundButton() 
    {
        SoundOFF = !SoundOFF;
        if (SoundOFF) { AudioListener.pause = true; SoundButtonImage.sprite = SoundCloseSprie; } ; //聲音關閉
        if (!SoundOFF) { AudioListener.pause = false;  SoundButtonImage.sprite = SoundOpenSprite; }; //聲音開啟
    }

    public void SoundChange()
    {
        AudioListener.volume = SoundSlider.value;
        
        print(AudioListener.volume);
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


    private void Start()
    {
        print(gameObject.name);
        // 聲音控制
        AudioListener.volume = SoundSlider.value;
        if (SoundOFF) { AudioListener.pause = true; SoundButtonImage.sprite = SoundCloseSprie; }; //聲音關閉
        if (!SoundOFF) { AudioListener.pause = false; SoundButtonImage.sprite = SoundOpenSprite; }; //聲音開啟
    }










    #endregion










}
