using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveEvent_2_NPC : SaveState
{
    public GameObject Trans0;


    protected override void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void finish()
    {
        PlayerPrefs.SetInt(scene.name + gameObject.name + 3, 1);
    }

    public override void destory()
    {
        if (PlayerPrefs.GetInt(scene.name + gameObject.name + 1) == 1)
        {
            Trans0.SetActive (true);
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
