using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 取得弓 - 小木屋內紅水晶
/// </summary>

public class SaveEvent2 : SaveState
{
    public Player player1;
    protected override void Start()
    {
        scene = SceneManager.GetActiveScene();

        // 如果已觸發則摧毀
        if (PlayerPrefs.GetInt(scene.name + gameObject.name) == 1)
        {
            player1.GetBow = true;
            Destroy(gameObject);
        }
    }


}