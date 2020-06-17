using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Map0_Save : MonoBehaviour
{
    Scene scene ;

    /// <summary>
    /// 水晶1：0 ～ 事件1：1 對話框 ～ 水晶2：2 傳送點 ～ 紅水晶：3 取得弓 ～ 水晶3：4
    /// </summary>
    /*
    C1; //水晶
    E1; //事件 對話提示
    C2; //水晶 小屋傳送點
    R1; //紅水晶 武器：弓
    C3; //水晶
    */
    [Header("水晶1：0 ～ 事件1：1 ～ 水晶2：2 ～ 紅水晶：3 ～ 水晶3：4")]
    public int[] Map0SaveResult = new int[5];
    public int index;
    Map0_Save GM;


    private void Awake()
    {
        GM = FindObjectOfType<GameManager>().GetComponent<Map0_Save>();
        Map0SaveResult = new int[5];
        scene = SceneManager.GetActiveScene();
        for (int i = 0; i < Map0SaveResult.Length; i++)
        {
            Map0SaveResult[i] = PlayerPrefs.GetInt(scene.name + i);
        }

        if (gameObject.name !="GM" && PlayerPrefs.GetInt(scene.name + index) == 1)
        {
            Destroy(gameObject);
        }

    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            GM.Map0SaveResult[index] = 1;
        }
        

    }

    public void SaveData() 
    {
        for (int i = 0; i < Map0SaveResult.Length; i++)
        {
            PlayerPrefs.SetInt( scene.name + i , GM.Map0SaveResult[i]);
            print(scene.name + i + PlayerPrefs.GetInt(scene.name + i));
        }

    }


}
