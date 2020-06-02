using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{
    [Header("移動到哪個場景")]
    public string NextSceneName;


    public void NextScene() 
    {
    
    SceneManager.LoadScene(NextSceneName);
    
    
    
    }

    
}
