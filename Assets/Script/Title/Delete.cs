using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delete : MonoBehaviour
{
    public Button[] LoadButton;


    public void Delete_All()
    {
        
        PlayerPrefs.SetInt("SaveState" + 6, 0);
        PlayerPrefs.SetInt("SaveState" + 7, 0);
        PlayerPrefs.SetInt("SaveState" + 8, 0);
        LoadButton[0].interactable = false;
        LoadButton[1].interactable = false;
        LoadButton[2].interactable = false;
    }




}
