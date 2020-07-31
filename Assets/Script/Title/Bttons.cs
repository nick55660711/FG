using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bttons : MonoBehaviour
{


    public int SaveID;



    private void Start()
    {
        if (PlayerPrefs.GetInt("SaveState" + SaveID) ==1)
        {

        GetComponent<Button>().interactable = true;
        }
    }
}
