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
    public GameManager GM;



    public void ClearData()
    {
        PlayerPrefs.SetInt(scene.name + gameObject.name + 0, 0);
    }



    /// <summary>
    /// 觸碰後設定為已觸發
    /// </summary>
    /// <param name="collision"></param>

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(scene.name + gameObject.name + 3, 1);
        }
    }

    public virtual void destory()
    {
        if (PlayerPrefs.GetInt(scene.name + gameObject.name + 1) == 1)
        {
            Destroy(gameObject,0.2f);
        }

    }

    protected virtual void Start()
    {
        scene = SceneManager.GetActiveScene();
        GM = FindObjectOfType<GameManager>();
       
        print(scene.name+gameObject.name + PlayerPrefs.GetInt(scene.name + gameObject.name + 1));
        // 如果已觸發則摧毀
        destory();
         
    }
}



