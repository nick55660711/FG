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
    BoxCollider2D Box;
    [Header("要移動到的場景")]
    public string NextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetString(NowScene.name + "PlayerLocate", this.name);
            GM.ChangeScene(NextSceneName);
        }
    }
    /*
   WaitForSecondsRealtime WAS2 = new WaitForSecondsRealtime(1);
   IEnumerator BOXON()
   {
       yield return WAS2;
       Box.enabled = true;
   }
    */
    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        NowScene = SceneManager.GetActiveScene();
        /*
        Box = GetComponent<BoxCollider2D>();
        StartCoroutine(BOXON());
        */
    }

}
