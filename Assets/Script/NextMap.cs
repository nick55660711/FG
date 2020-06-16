using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMap : MonoBehaviour
{
    public GameManager GM;


    public string SceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            GM.ChangeScene(SceneName);
        }



    }


    private void Start()
    {
       GM =  FindObjectOfType<GameManager>();
    }

}
