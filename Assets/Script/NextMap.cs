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
    [Header("要移動到的場景")]
    public string SceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GM.ChangeScene(SceneName);
        }
    }


    private void Start()
    {
       GM =  FindObjectOfType<GameManager>();
    }

}
