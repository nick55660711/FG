using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 按鈕場景移動控制 
/// </summary>


public class SceneTrans : MonoBehaviour
{
    [Header("移動到哪個場景")]
    public string NextSceneName;


    public void NextScene() 
    {
    
    SceneManager.LoadScene(NextSceneName);
    
    }

    


    public void Quit()
    {

        Application.Quit();

    }




}
