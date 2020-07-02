using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// 傳送點開啟 - 小木屋前水晶
/// </summary>
public class SaveEvent1 : SaveState
{
    public GameObject Trans0;
    protected override void Start()
    {
        scene = SceneManager.GetActiveScene();

        // 如果已觸發則摧毀
        if (PlayerPrefs.GetInt(scene.name + gameObject.name) == 1)
        {
            Trans0.GetComponent<Trans>().enabled = true;
            Destroy(gameObject);
        }
    }
}
