using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{



    public void NewGame()
    {
        PlayerPrefs.SetString("Map0PlayerLocate", "Start");
        PlayerPrefs.SetFloat("HP0", 100);
        PlayerPrefs.SetFloat("Crystal_No0", 0);
        PlayerPrefs.SetFloat("Herb_No0", 0);
        PlayerPrefs.SetInt("SaveID", 0);
        Load(0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="SaveID">暫時紀錄狀態 0：初始 1：暫時 2 : 轉場 </param>
    public void Load(int SaveID)
    {
        for (int j = 0; j < SceneManager.sceneCountInBuildSettings; j++)
        {
            print(SceneManager.sceneCountInBuildSettings);
            for (int i = 0; i < PlayerPrefs.GetInt(j + "itemNO"); i++)
            {
                print(PlayerPrefs.GetInt(j + "itemNO"));
                string SaveName = PlayerPrefs.GetString(j + i.ToString());
                print(j + i.ToString());
                print(SaveName);
                int tempSave = PlayerPrefs.GetInt(SaveName + SaveID);
                PlayerPrefs.SetInt(SaveName + 0, 0);
                PlayerPrefs.SetInt(SaveName + 1, tempSave);
            }
        }

        PlayerPrefs.SetFloat("HP" + 1, PlayerPrefs.GetFloat("HP" + SaveID));
        PlayerPrefs.SetFloat("Crystal_No" + 1, PlayerPrefs.GetFloat("Crystal_No" + SaveID));
        PlayerPrefs.SetFloat("Herb_No" + 1, PlayerPrefs.GetFloat("Herb_No" + SaveID));

    }
    public void Load()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneSave"));
    }
}