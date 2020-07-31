using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoyer : MonoBehaviour
{
    //public GameObject Run1;
    private void Start()
    {

      if(FindObjectOfType<Player>() != null)
        {

        Destroy(FindObjectOfType<Player>().gameObject);
        Destroy(GameObject.Find("EventSystem(Clone)"));
        Destroy(GameObject.Find("Canvas(Clone)"));
        Destroy(GameObject.Find("SoundManager(Clone)"));
        Destroy(FindObjectOfType<GameManager>().gameObject);
   
        }

      /*
      if(FindObjectOfType<Run>() == null)
        {
            Instantiate(Run1);
        }
        */
    }




}
