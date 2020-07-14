using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{

    public void NewGame()
    {
        PlayerPrefs.SetString("Map0PlayerLocate", "Start");
        PlayerPrefs.SetFloat("HP", 100);
        PlayerPrefs.SetInt("Reset", 1);
        PlayerPrefs.SetFloat("Crystal_No", 0);

    }





}
