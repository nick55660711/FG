﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public GameObject Respwan;
    [Header("當前場景名稱")]
    public Scene SceneNow;

    private void Start()
    {
        Respwan = GameObject.Find("Start");
        SceneNow = SceneManager.GetActiveScene();
    }




    void Update()
    {
        /*

        if (Input.GetKeyDown("r")) 
        {
            transform.position = Respwan.transform.position;
            PlayerPrefs.SetFloat("HP",100);
            PlayerPrefs.SetFloat("Crystal_No",0);
        }
        */

        if (Input.GetKeyDown("e"))
        {
            GetComponent<Player>().HP = 100;
            GetComponent<Player>().GetBow = true;
            GetComponent<Player>().GetSword = true;
        }
        
        /*
        if (Input.GetKeyDown("t"))
        {
            SceneManager.LoadScene(SceneNow.name);
        }
        */
        // if (Input.GetKeyDown("t")) { SceneManager.LoadScene("Map0"); }


    }



}
