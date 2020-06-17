using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Map0_Load : MonoBehaviour
{
    public CanvasGroup DialogueScreen;
    public GameManager GM;
    public Map0_Save GMSave;
    Scene scene;
    public Player player1;
    public GameObject Trans0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GMSave.SaveData();
        }
    }


    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        GMSave = GM.GetComponent<Map0_Save>();
        player1 = FindObjectOfType<Player>();
        DialogueScreen = GameObject.Find("DialogueScreen").GetComponent<CanvasGroup>();
        scene = SceneManager.GetActiveScene();

        if (GMSave.Map0SaveResult[1] == 1)
        {
            DialogueScreen.GetComponentsInChildren<Text>()[1].gameObject.SetActive(false);
        }

        if (GMSave.Map0SaveResult[2] == 1) 
        {
            Trans0.GetComponent<Trans>().enabled = true;
        }

        if (GMSave.Map0SaveResult[3] == 1)
        {
            player1.GetBow = true;
        }


    }


    private void Update()
    {
        if(Input.GetKeyDown("w"))
        {
            for (int i = 0; i < GMSave.Map0SaveResult.Length; i++)
            {
                PlayerPrefs.SetInt(scene.name + i, 0);
                GMSave.Map0SaveResult[i] = 0;
            }
        }
    }





}
