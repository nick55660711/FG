using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveEvent_Swrod : SaveState
{
    public Player player1;

    public override void destory()
    {
        if (PlayerPrefs.GetInt(scene.name + gameObject.name + 1) == 1)
        {
            player1.GetSword = true;
            Destroy(gameObject, 0.2f);
        }
    }
    protected override void Start()
    {

        player1 = FindObjectOfType<Player>();
        base.Start();

      

    }

}
