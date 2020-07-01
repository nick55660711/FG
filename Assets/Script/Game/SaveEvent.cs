using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// 對話提示關閉 怪物觸發事件
/// </summary>
public class SaveEvent : SaveState
{
    public CanvasGroup DialogueScreen;
    protected override void Awake()
    {
        print("01");
        scene = SceneManager.GetActiveScene();

        // 如果已觸發則摧毀
        if (PlayerPrefs.GetInt(scene.name + gameObject.name) == 1)
        {
            DialogueScreen.GetComponentsInChildren<Text>()[1].gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }


}
