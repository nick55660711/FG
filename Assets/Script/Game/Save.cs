using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{


    #region map0_Save
    Scene scene;

    /// <summary>
    /// Map0儲存引數 水晶1：0 ～ 事件1：1 對話框 ～ 水晶2：2 傳送點 ～ 紅水晶：3 取得弓 ～ 水晶3：4
    /// </summary>
    /*
    C1; //水晶
    E1; //事件 對話提示
    C2; //水晶 小屋傳送點
    R1; //紅水晶 武器：弓
    C3; //水晶
    */
    [Header("Map0儲存引數 水晶1：0 ～ 事件1：1 ～ 水晶2：2 ～ 紅水晶：3 ～ 水晶3：4")]
    public int[] Map0SaveResult = new int[5];

    #endregion



    public void SaveData()
    {
        // map0地圖資訊儲存
        for (int i = 0; i < Map0SaveResult.Length; i++)
        {
            PlayerPrefs.SetInt("Map0" + i, Map0SaveResult[i]);
            print(scene.name + i + PlayerPrefs.GetInt("Map0" + i));
        }

    }
    
    public void LoadData()
    {
        // 讀取儲存的地圖資訊
        for (int i = 0; i < Map0SaveResult.Length; i++)
        {
            Map0SaveResult[i] = PlayerPrefs.GetInt("Map0" + i);
        }
    }




    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        Map0SaveResult = new int[5];
        LoadData();

    }




    /// <summary>
    /// 清除map0存檔
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            for (int i = 0; i < Map0SaveResult.Length; i++)
            {
                PlayerPrefs.SetInt("Map0" + i, 0);
                Map0SaveResult[i] = 0;
            }
        }
    }
  

   

}
