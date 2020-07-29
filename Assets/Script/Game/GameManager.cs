using System.Collections;
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
    public delegate void GMdelegate();
    public GMdelegate onChangeScene;
    Scene scene;
    int PauseTime;
    /// <summary>
    /// 暫時紀錄狀態 0：初始 1：暫時 2 : 轉場 
    /// </summary>
    public int temp = 1;
    public int itemNo;
    public List<string> itemname;
    




    #endregion

    #region 方法
    public void Restart()
    {
 
        SceneManager.LoadScene(scene.name);
    }

    public void ChangeScene(string SceneName)
    {
        /// <summary>
        /// 暫時儲存資料
        /// </summary>
      
        SaveMapData();

     

        SceneManager.LoadScene(SceneName);
    }

    public void SaveAllData(int SaveID)
    {
        /// <summary>
        /// 永久儲存資料
        /// </summary>
        temp = SaveID;
        PlayerPrefs.SetFloat("HP" + temp, player1.HP);
        PlayerPrefs.SetFloat("Crystal_No" + temp, Crystal_No);
        PlayerPrefs.SetFloat("Herb_No" + temp, Herb_No);
        PlayerPrefs.SetInt("SceneSave", scene.buildIndex);
        SaveMapData();

    }


    public void SaveMapData()
    {
        temp = 1;
        PlayerPrefs.SetFloat("HP" + temp, player1.HP);
        PlayerPrefs.SetFloat("Crystal_No" + temp, Crystal_No);
        PlayerPrefs.SetFloat("Herb_No" + temp, Herb_No);
        for (int i = 0; i < itemNo; i++)
        {
            string SaveName = PlayerPrefs.GetString(scene.buildIndex.ToString() + i);
            int tempSave = PlayerPrefs.GetInt(SaveName + 1);
            PlayerPrefs.SetInt(SaveName + temp, tempSave);
        }
    }


    public void GamePause() 
    {
        Time.timeScale = 0;
        PauseTime++;
    }
    public void GameContinue() 
    {
        PauseTime-- ;
        if(PauseTime == 0) Time.timeScale = 1;

    }

    

    public void HpUpdate()
    {
            PlayerPrefs.SetFloat("HP" + 1 , player1.HP);

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
                CrystalText.text = " : " + Crystal_No;

                break;

            case 1:
                Herb_No++ ;
                
                HerbText.text = " : " + Herb_No;

                break;
        }







    }







    #endregion

    #region 事件

    private void Awake()
    {
        //抓取物件
        player1 = FindObjectOfType<Player>(); //不能使用FindTag.GetComponent
        HP_Bar = GameObject.Find("HP_Bar").GetComponent<Image>();
        HpText = GameObject.Find("HP_Text").GetComponent<Text>();
        CrystalText = GameObject.Find("Crystal_No_Text").GetComponent<Text>();
        scene = SceneManager.GetActiveScene(); 
        itemNo = FindObjectsOfType<SaveState>().Length;
        HerbText = GameObject.Find("Herb_No_Text").GetComponent<Text>();
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
         
    }

    private void Start()
    {

        //讀取血量與碎片量
        player1.HP = PlayerPrefs.GetFloat("HP" + 1);
        Crystal_No = PlayerPrefs.GetFloat("Crystal_No" + 1);
        Herb_No = PlayerPrefs.GetFloat("Herb_No" + 1);
        // enemy Layer不互相碰撞
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(8, 9);

        //更新UI
        HpText.text = "Hp : " + player1.HP;
        HP_Bar.fillAmount = player1.HP / HP_MAX;
        CrystalText.text = " : " + Crystal_No;
        HerbText.text = " : " + Herb_No;

        PauseTime = 0;

    }



   

    #endregion






}
