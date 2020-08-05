using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public Text itemName;
    public void item()
    {
        for (int j = 1; j < SceneManager.sceneCountInBuildSettings; j++)
        {
            print(SceneManager.sceneCountInBuildSettings);
            for (int i = 0; i < PlayerPrefs.GetInt(j + "itemNO"); i++)
            {
                string SaveName = PlayerPrefs.GetString(j + i.ToString());
                itemName.text += ","+SaveName;
            }
        }
    }


    public void NewGame()
    {
        for (int i = 0; i < 4; i++)
        {
        PlayerPrefs.SetString("Map"+i+"PlayerLocate", "Start");
        }
        PlayerPrefs.SetFloat("HP0", 100);
        PlayerPrefs.SetFloat("Crystal_No0", 0);
        PlayerPrefs.SetFloat("Herb_No0", 0);
        PlayerPrefs.SetInt("SaveID", 0);
        PlayerPrefs.SetFloat("HP" + 1, PlayerPrefs.GetFloat("HP" + 0));
        PlayerPrefs.SetFloat("Crystal_No" + 1, PlayerPrefs.GetFloat("Crystal_No" + 0));
        PlayerPrefs.SetFloat("Herb_No" + 1, PlayerPrefs.GetFloat("Herb_No" + 0));
        for (int j = 1; j < SceneManager.sceneCountInBuildSettings; j++)
        {
            print(SceneManager.sceneCountInBuildSettings);
            for (int i = 0; i < PlayerPrefs.GetInt(j + "itemNO"); i++)
            {
                print(PlayerPrefs.GetInt(j + "itemNO"));
                string SaveName = PlayerPrefs.GetString(j + i.ToString());
                print(j + i.ToString());
                print(SaveName);
                PlayerPrefs.SetInt(SaveName + 0, 0);
                PlayerPrefs.SetInt(SaveName + 1, 0);
                PlayerPrefs.SetInt(SaveName + 3, 0);
            }
        }
        PlayerPrefs.SetInt("Bow"+1, 0);
        PlayerPrefs.SetInt("Sword"+1, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="SaveID">暫時紀錄狀態 0：初始 1：暫時 2 : 轉場 </param>
    public void Load(int SaveID)
    {
        for (int j = 1; j < SceneManager.sceneCountInBuildSettings; j++)
        {
            print("SceneNo:"+j);
                print("itemNO:"+PlayerPrefs.GetInt(j + "itemNO"));
            for (int i = 0; i < PlayerPrefs.GetInt(j + "itemNO"); i++)
            {
                string SaveName = PlayerPrefs.GetString(j + i.ToString());
                int tempSave = PlayerPrefs.GetInt(SaveName + SaveID);
                print(SaveName + ":" + tempSave);
                PlayerPrefs.SetInt(SaveName + 0, 0);
                PlayerPrefs.SetInt(SaveName + 1, tempSave);
                print(SaveName + 1+":"+PlayerPrefs.GetInt(SaveName + 1));
            }
        }

        PlayerPrefs.SetFloat("HP" + 1, PlayerPrefs.GetFloat("HP" + SaveID));
        PlayerPrefs.SetFloat("Crystal_No" + 1, PlayerPrefs.GetFloat("Crystal_No" + SaveID));
        PlayerPrefs.SetFloat("Herb_No" + 1, PlayerPrefs.GetFloat("Herb_No" + SaveID));

        PlayerPrefs.SetInt("Bow" + 1, PlayerPrefs.GetInt("Bow" + SaveID));
        PlayerPrefs.SetInt("Sword" + 1, PlayerPrefs.GetInt("Sword" + SaveID));
        print("SceneSave:" + PlayerPrefs.GetInt("SceneSave" + SaveID));
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneSave" + SaveID));
    }


    public void Load()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneSave"));
    }


}