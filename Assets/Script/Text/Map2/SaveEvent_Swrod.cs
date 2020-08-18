using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveEvent_Swrod : SaveState
{
    public Player player1;

    public override void destory()
    {
        if (PlayerPrefs.GetInt(scene.name + gameObject.name + 1) == 1)
        {
            player1.GetSword = true;
            GameObject.Find("劍").GetComponent<Image>().enabled = true;
            Destroy(gameObject, 0.2f);
        }
    }
    protected override void Start()
    {

        player1 = FindObjectOfType<Player>();
        base.Start();

      

    }

}
