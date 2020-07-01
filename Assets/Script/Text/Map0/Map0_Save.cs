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
    [Header("水晶1：0 ～ 事件1：1 ～ 水晶2：2 ～ 紅水晶：3 ～ 水晶3：4 ")]
    public int index;
    Save GM;



   /// <summary>
   /// 觸碰後設定為已觸發
   /// </summary>
   /// <param name="collision"></param>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag( "Player"))
        {
            GM.Map0SaveResult[index] = 1;
        }

    }

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>().GetComponent<Save>();
        scene = SceneManager.GetActiveScene();


       
        // 如果已觸發則摧毀
        if ( PlayerPrefs.GetInt(scene.name + index) == 1)
        {
            Destroy(gameObject);
        }

    }
   


}
