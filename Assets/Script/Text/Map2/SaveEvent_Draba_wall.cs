using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveEvent_Draba_wall : SaveState
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            PlayerPrefs.SetInt(scene.name + gameObject.name + 3, 1);
        }
    }

    public override void destory()
    {
        if (PlayerPrefs.GetInt(scene.name + gameObject.name + 1) == 1)
        {
            Destroy(transform.parent.gameObject,0.5f);
        }
    }
    protected override void Start()
    {

        base.Start();



    }
}
