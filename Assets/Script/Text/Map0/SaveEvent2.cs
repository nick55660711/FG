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

    public override void destory()
    {
        if (PlayerPrefs.GetInt(scene.name + gameObject.name + 1) == 1)
        {
            player1.GetBow = false;
            player1.bow.SetActive(false);
            player1.GetComponent<SpriteRenderer>().sprite = player1.stay;
            GameObject.Find("弓").GetComponent<Image>().enabled = false;

            Destroy(gameObject, 0.2f);
        }
    }
 

}