﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region 欄位

    public Player player1;
    public float HP_MAX;
    public Image HP_Bar;
    public float Crystal_No;
    public float Herb_No;
    public Text HpText;
    public Text CrystalText;
    public Text HerbText;
    //public delegate void GMdelegate();
    //public GMdelegate onChangeScene;
    Scene scene;
   public int PauseTime;
    /// <summary>
    /// 暫時紀錄狀態 0：初始 1：暫時 2 : 轉場 
    /// </summary>
    public int temp = 1;
    public int itemNo;
    public List<string> itemname;
    public CameraControll camera1;
    public CanvasGroup Blackout;

    public float TimerSTOP;

    #endregion

    #region 方法
    public void Restart()
    {

        PlayerPrefs.SetFloat("HP" + 1, 100);
        StartCoroutine(BlackScreen(1, scene.name));

    }
    public AudioClip CastleBGM;
    public AudioClip ForestBGM;

    public void ChangeScene(string SceneName)
    {
        /// <summary>
        /// 暫時儲存資料
        /// </summary>
       
        SaveMapData();

        StartCoroutine(BlackScreen(1, SceneName));


    }

    WaitForSecondsRealtime WAS = new WaitForSecondsRealtime(0.01f);

    public IEnumerator BlackScreen(float A)
    {
        for (int i = 0; i < 10; i++)
        {

            Blackout.alpha += 0.1f * A;
            yield return WAS;
        }
    }

    public IEnumerator BlackScreen(float A, WaitForSecondsRealtime B)
    {
        for (int i = 0; i < 20; i++)
        {

            Blackout.alpha += 0.05f * A;
            yield return B;
        }
    }

    WaitForSecondsRealtime WAS2 = new WaitForSecondsRealtime(0.3f);
    IEnumerator BlackScreen(int A, string SceneName)
    {
        for (int i = 0; i < 10; i++)
        {

            Blackout.alpha += 0.1f * A;
            yield return WAS;
        }

        player1.transform.position = Vector2.up * 100;

        if (menu_C.OpenScreen)
        {
            menu_C.OpenScreen = !menu_C.OpenScreen; menu_C.OptionClose();
        }

        SceneManager.LoadScene(SceneName);


        yield return WAS2;

        if (SceneName == "Map1"&& SoundManager.clip != ForestBGM) { SoundManager.clip = ForestBGM; SoundManager.Play(); }
        if (SceneName == "Map2"&& SoundManager.clip != CastleBGM) { SoundManager.clip = CastleBGM; SoundManager.Play(); }
        StartScene();
        player1.StartScene();
    }

    IEnumerator BlackScreen()
    {

        for (int i = 0; i < 10; i++)
        {

            Blackout.alpha += 0.1f * 1;
            yield return WAS;
        }
        Time.timeScale = 1;

        if (menu_C.OpenScreen)
        {
            menu_C.OpenScreen = !menu_C.OpenScreen; menu_C.OptionClose();
        }

        SceneManager.LoadScene(0);


        yield return WAS2;


    }

    WaitForSecondsRealtime WAS3 = new WaitForSecondsRealtime(1f);
    WaitForSecondsRealtime WAS4 = new WaitForSecondsRealtime(0.1f);
   public IEnumerator GameOver(CanvasGroup GameoverScreen)
    {
        print("GO");
        for (int i = 0; i < 10; i++)
        {

            GameoverScreen.alpha += 0.1f;
            yield return WAS4;

        }
        player1.rig.constraints = RigidbodyConstraints2D.FreezeRotation;

        print("GameO");
        yield return WAS3;
        for (int i = 1; i <6; i++)
        {

            GameoverScreen.GetComponentsInChildren<Image>()[1].color = new Vector4(1,1,1,1)* 0.2f *i ;
            yield return WAS4;

        }
        print("Over");
        for (int i = 1; i < 6; i++)
        {

            GameoverScreen.GetComponentsInChildren<Image>()[2].color = new Vector4(1,1,1,1)* 0.2f *i ;
            yield return WAS4;

        }

        GameoverScreen.blocksRaycasts = true;
        GameoverScreen.interactable = true;

        /*
        if (menu_C.OpenScreen)
        {
            menu_C.OpenScreen = !menu_C.OpenScreen; menu_C.OptionClose();
        }
        */
        // SceneManager.LoadScene(0);




    }

    /*
    PlayerPrefs.SetInt(scene.buildIndex + "itemNO" , itemNo);
    print(scene.buildIndex + "itemNO" +PlayerPrefs.GetInt(scene.name + "itemNO"));
        int i = 0;
    foreach (var item in FindObjectsOfType<SaveState>())
    {
        PlayerPrefs.SetInt(scene.name + item.name + 0 ,0);
        //紀錄存檔物件名稱
        PlayerPrefs.SetString(scene.buildIndex.ToString() + i, scene.name + item.name);
        print(scene.buildIndex.ToString() + i + PlayerPrefs.GetString(scene.buildIndex.ToString() + i));
        i++;
    }
    */
    public void SaveAllData(int SaveID)
    {
        /// <summary>
        /// 永久儲存資料
        /// </summary>
       
        SaveMapData();
        temp = SaveID;
        PlayerPrefs.SetFloat("HP" + temp, player1.HP);
        PlayerPrefs.SetFloat("Crystal_No" + temp, Crystal_No);
        PlayerPrefs.SetFloat("Herb_No" + temp, Herb_No);
        PlayerPrefs.SetInt("SceneSave" + temp, scene.buildIndex);
        PlayerPrefs.SetInt("Bow" + temp, PlayerPrefs.GetInt("Bow" +1));
        PlayerPrefs.SetInt("Sword" + temp, PlayerPrefs.GetInt("Sword" + 1));
        PlayerPrefs.SetInt("SaveState" + SaveID, 1);
        print("SceneSave:" + PlayerPrefs.GetInt("SceneSave" + temp));
        for (int j = 1; j < SceneManager.sceneCountInBuildSettings; j++)
        {
            print("itemNO.Map"+j+":"+PlayerPrefs.GetInt(j + "itemNO"));
            for (int i = 0; i < PlayerPrefs.GetInt(j + "itemNO"); i++)
            {
                string SaveName = PlayerPrefs.GetString(j.ToString() + i);
                int tempSave1 = PlayerPrefs.GetInt(SaveName + 3);
                PlayerPrefs.SetInt(SaveName + temp, tempSave1);

                print(SaveName +"SaveNO"+temp+ " State:"+PlayerPrefs.GetInt(SaveName + temp));
            }
        }
        
         
    }


    public void SaveMapData()
    {
        temp = 1;
        PlayerPrefs.SetFloat("HP" + temp, player1.HP);
        PlayerPrefs.SetFloat("Crystal_No" + temp, Crystal_No);
        PlayerPrefs.SetFloat("Herb_No" + temp, Herb_No);
        PlayerPrefs.SetInt("Sword" + 1, PlayerPrefs.GetInt("Sword" + 3));
        PlayerPrefs.SetInt("Bow" + 1, PlayerPrefs.GetInt("Bow" + 3));
        for (int i = 0; i < itemNo; i++)
        {
            string SaveName = PlayerPrefs.GetString(scene.buildIndex.ToString() + i);
            int tempSave3 = PlayerPrefs.GetInt(SaveName + 3);
           // print("tempSave:" + tempSave3);
            PlayerPrefs.SetInt(SaveName + temp, tempSave3);
           // print("Name:" + SaveName + temp + ",Get numbers:" + PlayerPrefs.GetInt(SaveName + temp));
        }
    }
    public void Clear()
    {
        if (Input.GetKeyDown("w"))
        {
            print("Clear");
            PlayerPrefs.SetString(scene.name + "PlayerLocate", "Start");
            PlayerPrefs.SetFloat("HP" + 1, 100);
            PlayerPrefs.SetFloat("Crystal_No" + 1, 0);
            PlayerPrefs.SetFloat("Herb_No" + 1, 0);
            for (int i = 0; i < itemNo; i++)
            {
                string SaveName = PlayerPrefs.GetString(scene.buildIndex.ToString() + i);
                PlayerPrefs.SetInt(SaveName + 1, 0);
                PlayerPrefs.SetInt(SaveName + 3, 0);
            }
        }
        if (Input.GetKeyDown("t"))
        {
            Restart();
        }
    }


    public void GamePause()
    {
        Time.timeScale = 0;
        player1.Stop = true;
        PauseTime++;
        print(" PauseTime:" + PauseTime);
    }
    public void GameContinue()
    {
        PauseTime--;
        print(" PauseTimeSTOP:" + PauseTime);
        if (PauseTime == 0)
        {
            Time.timeScale = 1;

            player1.Stop = false;
        }

    }



    public void HpUpdate()
    {
        PlayerPrefs.SetFloat("HP" + 1, player1.HP);

        HpText.text = "Hp : " + player1.HP;
        HP_Bar.fillAmount = player1.HP / HP_MAX;
    }

    /// <summary>
    /// 取得道具
    /// </summary>
    /// <param name="itemID">道具ID 0：水晶 － 1：藥草 </param>
    public void GetItem(int itemID)
    {


        switch (itemID)
        {
            case 0:
                //回血
                player1.HP += 5;
                player1.HP = Mathf.Clamp(player1.HP, 0, HP_MAX);
                HpUpdate();

                //道具+1
                Crystal_No += 1;
                CrystalText.text = "  " + Crystal_No;

                break;

            case 1:
                Herb_No++;

                HerbText.text = "  " + Herb_No;

                break;
        }







    }







    #endregion

    void StartScene()
    {
        //抓取物件
        PauseTime = 0;

        Blackout.alpha = 1;
        StartCoroutine(BlackScreen(-1));
        scene = SceneManager.GetActiveScene(); //轉換場景需要重新抓取
        print(scene.name);
        itemNo = FindObjectsOfType<SaveState>().Length; //轉換場景需要重新抓取
        PlayerPrefs.SetInt(scene.buildIndex + "itemNO", itemNo);
        print(scene.buildIndex + "itemNO" + PlayerPrefs.GetInt(scene.name + "itemNO"));
        int i = 0;
        foreach (var item in FindObjectsOfType<SaveState>())
        {
            PlayerPrefs.SetInt(scene.name + item.name + 0, 0);
            //紀錄存檔物件名稱
            PlayerPrefs.SetString(scene.buildIndex.ToString() + i, scene.name + item.name);
            print(scene.buildIndex.ToString() + i + PlayerPrefs.GetString(scene.buildIndex.ToString() + i));
            i++;
        }
            print("Boss:"+PlayerPrefs.GetInt("Map3BossTriger1"));

        //讀取血量與碎片量
        player1.HP = PlayerPrefs.GetFloat("HP" + 1);
        Crystal_No = PlayerPrefs.GetFloat("Crystal_No" + 1);
        Herb_No = PlayerPrefs.GetFloat("Herb_No" + 1);
        /*
        // enemy Layer不互相碰撞
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(8, 9);

        for (int k = 0; k < 13; k++)
        {
            if (k == 8) continue;
            if (k == 13) continue;
            Physics2D.IgnoreLayerCollision(k, 11);
        }
        */

        //更新UI
        HpText.text = "Hp : " + player1.HP;
        HP_Bar.fillAmount = player1.HP / HP_MAX;
        CrystalText.text = "  " + Crystal_No;
        HerbText.text = "  " + Herb_No;


    }

    #region 事件

   // Button RestartButton;
    Button TitleButton;
    Button SaveButton;
    Button SaveButton2;
    Button SaveButton3;
    Menu menu_C;
    public AudioSource SoundManager;
    
    public void SoundPlay(AudioClip sound)
    {
        SoundManager.PlayOneShot(sound);

    }


    private void Awake()
    {
        //抓取物件
        player1 = FindObjectOfType<Player>(); //不能使用FindTag.GetComponent
        HP_Bar = GameObject.Find("HP_Bar").GetComponent<Image>();
        HpText = GameObject.Find("HP_Text").GetComponent<Text>();
        CrystalText = GameObject.Find("Crystal_No_Text").GetComponent<Text>();
        Blackout = GameObject.Find("BlackScreen").GetComponent<CanvasGroup>();
        scene = SceneManager.GetActiveScene();
        itemNo = FindObjectsOfType<SaveState>().Length;
        HerbText = GameObject.Find("Herb_No_Text").GetComponent<Text>();
        SoundManager = FindObjectOfType<AudioSource>();
        //按鈕
       // RestartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        TitleButton = GameObject.Find("Title_Button").GetComponent<Button>();
        SaveButton = GameObject.Find("Save_Button").GetComponent<Button>();
        SaveButton2 = GameObject.Find("Save_Button2").GetComponent<Button>();
        SaveButton3 = GameObject.Find("Save_Button3").GetComponent<Button>();
       // RestartButton.onClick.AddListener(() => { Restart(); });
        TitleButton.onClick.AddListener(() => { StartCoroutine(BlackScreen()); });
        SaveButton.onClick.AddListener(() => { SaveAllData(6); });
        SaveButton2.onClick.AddListener(() => { SaveAllData(7); });
        SaveButton3.onClick.AddListener(() => { SaveAllData(8); });
        menu_C = FindObjectOfType<Menu>();



        camera1 = Camera.main.GetComponent<CameraControll>();
        camera1.CancelSet();
        PlayerPrefs.SetInt(scene.buildIndex + "itemNO", itemNo);

        int i = 0;
        foreach (var item in FindObjectsOfType<SaveState>())
        {
            PlayerPrefs.SetInt(scene.name + item.name + 0, 0);
            //紀錄存檔物件名稱
            PlayerPrefs.SetString(scene.buildIndex.ToString() + i, scene.name + item.name);
     
            i++;
        }

    }

    private void Start()
    {
        Blackout.alpha = 1;
        StartCoroutine(BlackScreen(-1));

        //讀取血量與碎片量
        player1.HP = PlayerPrefs.GetFloat("HP" + 1);
        Crystal_No = PlayerPrefs.GetFloat("Crystal_No" + 1);
        Herb_No = PlayerPrefs.GetFloat("Herb_No" + 1);
        // enemy Layer不互相碰撞
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(8, 9);


        for (int k = 0; k < 14; k++)
        {
            if (k == 8|| k == 10|| k == 12) continue;
           
            Physics2D.IgnoreLayerCollision(k, 11);
        }

        //更新UI
        HpText.text = "Hp : " + player1.HP;
        HP_Bar.fillAmount = player1.HP / HP_MAX;
        CrystalText.text = "  " + Crystal_No;
        HerbText.text = "  " + Herb_No;

        PauseTime = 0;

    }

   


    #endregion






}
