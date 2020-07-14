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
    
    
    




    #endregion

    #region 方法
    public void Restart()
    {
        PlayerPrefs.SetFloat("HP",100);
        /// <summary>
        /// 呼叫資料儲存方法
        /// </summary>
        PlayerPrefs.SetFloat("Crystal_No", Crystal_No);
        PlayerPrefs.SetFloat("Herb_No", Herb_No);
        SceneManager.LoadScene(scene.name);
    }

    public void ChangeScene(string SceneName)
    {
        PlayerPrefs.SetFloat("HP",player1.HP);
        PlayerPrefs.SetFloat("Crystal_No", Crystal_No);
        PlayerPrefs.SetFloat("Herb_No", Herb_No);
        /// <summary>
        /// 呼叫資料儲存方法
        /// </summary>
        SceneManager.LoadScene(SceneName);
    } 

    public void Save(int saveID)
    {

        PlayerPrefs.SetFloat(saveID + "HP", player1.HP);
        PlayerPrefs.SetFloat(saveID + "Crystal_No", Crystal_No);
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            for (int j = 0; j < PlayerPrefs.GetInt(i + "Length"); j++)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString(i.ToString() + j) + saveID, PlayerPrefs.GetInt(PlayerPrefs.GetString(i + j + "temp")));



            }
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
                HerbText = GameObject.Find("Herb_No_Text").GetComponent<Text>();
                HerbText.text = " : " + Herb_No;


                break;
        }







    }

    



    

    #endregion

    #region 事件

    private void Start()
    {
        //抓取物件
        player1 = FindObjectOfType<Player>(); //不能使用FindTag.GetComponent
        HP_Bar = GameObject.Find("HP_Bar").GetComponent<Image>();
        HpText = GameObject.Find("HP_Text").GetComponent<Text>();
        CrystalText = GameObject.Find("Crystal_No_Text").GetComponent<Text>();
        scene = SceneManager.GetActiveScene(); 

        //讀取血量與碎片量
        player1.HP = PlayerPrefs.GetFloat("HP");
        Crystal_No = PlayerPrefs.GetFloat("Crystal_No");
        Herb_No = PlayerPrefs.GetFloat("Herb_No");

        // enemy Layer不互相碰撞
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(8, 9);

        //更新UI
        HpText.text = "Hp : " + player1.HP;
        HP_Bar.fillAmount = player1.HP / HP_MAX;
        CrystalText.text = " : " + Crystal_No;

        PauseTime = 0;

    }



   

    #endregion






}
