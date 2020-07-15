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
    
    [Header("要移動到的場景")]
    public string NextSceneName; 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag( "Player"))
        {
            PlayerPrefs.SetString(NowScene.name + "PlayerLocate", this.name);
            GM.ChangeScene(NextSceneName);
        }
    }


    private void Start()
    {
       GM =  FindObjectOfType<GameManager>();
        NowScene = SceneManager.GetActiveScene();
    }

}
