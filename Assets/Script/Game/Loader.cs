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


    private void Awake()
    {

        Transform POS = GameObject.Find("Start").transform;
        if (FindObjectOfType<Player>() == null)
        {

            Instantiate(player1, POS.position, Quaternion.identity);
        }
        /*
        if (GameObject.Find("EventSystem(Clone)") == null)
        {

            Instantiate(EventSystem);
        }
        */

        if (GameObject.Find("Canvas(Clone)") == null)
        {

            Instantiate(Canvas);
        }
        if (FindObjectOfType<AudioSource>()== null)
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
