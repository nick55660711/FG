using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Load 腳本 要掛在Canvas上
/// </summary>
public class Save : MonoBehaviour
{

    public bool ClearData;

    #region map0_Save
    Scene scene;

    /// <summary>
    /// Map0儲存引數 水晶1：0 ～ 事件1：1 對話框 ～ 水晶2：2 傳送點 ～ 紅水晶：3 取得弓 ～ 水晶3：4 ～ 玩家位置：5
    /// </summary>
    /*
    C1; //水晶
    E1; //事件 對話提示
    C2; //水晶 小屋傳送點
    R1; //紅水晶 武器：弓
    C3; //水晶
    */
    public int[] NowSaveResult;
    [Header("Map0儲存引數 水晶1：0 ～ 事件1：1 ～ 水晶2：2 ～ 紅水晶：3 ～ 水晶3：4 ")]
    public int[] Map0SaveResult = new int[6];

    #endregion


    /// <summary>
    /// 切換場景時由GM呼叫儲存方法
    /// </summary>

    public void SaveData()
    {

        // map0地圖資訊儲存
        for (int i = 0; i < Map0SaveResult.Length; i++)
        {
            PlayerPrefs.SetInt("Map0" + i, Map0SaveResult[i]);
            print(scene.name + i + PlayerPrefs.GetInt("Map0" + i));
        }

    }
    
    /// <summary>
    /// 由Canvas呼叫讀取方法
    /// </summary>

        // 讀取儲存的地圖資訊
    public void LoadData()
    {
        // map0地圖資訊讀取
        for (int i = 0; i < Map0SaveResult.Length; i++)
        {
            Map0SaveResult[i] = PlayerPrefs.GetInt("Map0" + i);
        }
    }




    private void Awake()
    {

        scene = SceneManager.GetActiveScene();
        if (PlayerPrefs.GetInt("ClaerData") == 1)
        {
            //重置玩家出生位置
            PlayerPrefs.SetString(scene.name + "PlayerLocate", "Start");

            foreach (var item in FindObjectsOfType<SaveState>())
            {

                item.ClearData();
                PlayerPrefs.SetInt(scene.name + item.name, 0);
            }
        }

    }




    /// <summary>
    /// 清除map0存檔
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {

                ClearData = !ClearData;
            if (ClearData) 
            { 
                PlayerPrefs.SetInt("ClaerData", 1);
            }

            if (!ClearData) 
            { 
                PlayerPrefs.SetInt("ClaerData", 0);
            }

                print(ClearData);


            
        }
    }
  

   

}
