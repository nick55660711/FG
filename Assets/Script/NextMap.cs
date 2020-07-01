using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 遊戲內場景轉換
/// </summary>


public class NextMap : MonoBehaviour
{
    public GameManager GM;
    Scene NowScene;
    public int PlayerLocate; //紀錄位置
    [Header("要移動到的場景")]
    public string NextSceneName; 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerPrefs.SetInt(NowScene.name + "PlayerLocate", PlayerLocate);
            GM.ChangeScene(NextSceneName);
        }
    }


    private void Start()
    {
       GM =  FindObjectOfType<GameManager>();
        NowScene = SceneManager.GetActiveScene();
    }

}
