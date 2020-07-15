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
    Scene Scene_Now;

    public void NextScene() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NextSceneName);
    
    }

    public void Restart()
    {

        SceneManager.LoadScene(Scene_Now.name);

    }


    public void Quit()
    {

        Application.Quit();

    }


    private void Start()
    {
        Scene_Now = SceneManager.GetActiveScene();
    }


}
