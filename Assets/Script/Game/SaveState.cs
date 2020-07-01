using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 觸發後會摧毀的物件 
/// </summary>
public class SaveState : MonoBehaviour, IClearData
{
    public Scene scene;




    public void ClearData()
    {
        PlayerPrefs.SetInt(scene.name + gameObject.name, 0);
    }



    /// <summary>
    /// 觸碰後設定為已觸發
    /// </summary>
    /// <param name="collision"></param>

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(scene.name + gameObject.name, 1);
        }

    }

    protected virtual void Awake()
    {
        scene = SceneManager.GetActiveScene();
        print("00");

        // 如果已觸發則摧毀
        if (PlayerPrefs.GetInt(scene.name + gameObject.name) == 1)
        {

            ClearData(); // 測試用 之後必須移除
            Destroy(gameObject);
        }

    }

    protected void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            ClearData();
        }

    }
}
