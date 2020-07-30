using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject player1;
    public GameObject GameManager_;
    public GameObject SoundManager;
    public GameObject Camaera;
    public GameObject Canvas;
    public GameObject EventSystem;



    void Start()
    {
        if(FindObjectOfType<Player>() == null)
        {

            Instantiate(player1);
        }
        if (GameObject.Find("EventSystem") == null)
        {

            Instantiate(EventSystem);
        }
         if(GameObject.Find("Canvas") == null)
        {

            Instantiate(Canvas);
        }
        if (GameObject.Find("SoundManager") == null)
        {

            Instantiate(SoundManager);
        }
        if (Camera.main == null)
        {

            Instantiate(Camaera);
        }

        if (FindObjectOfType<GameManager>() == null)
        {

            Instantiate(GameManager_);
        }





    }

    
}
