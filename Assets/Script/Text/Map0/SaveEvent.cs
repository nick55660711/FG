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

    public override void destory()
    {
        if (PlayerPrefs.GetInt(scene.name + gameObject.name + 1) == 1)
        {
            Destroy(gameObject);
        }
    }


}
