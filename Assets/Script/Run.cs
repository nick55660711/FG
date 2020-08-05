using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Run : MonoBehaviour
{
    public CanvasGroup Blackout;
    Scene scene;
    int itemNo;
    public Text itemName; 
    WaitForSecondsRealtime WAS = new WaitForSecondsRealtime(0.1f);
    IEnumerator Runing()
    {

        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            SceneManager.LoadScene(i);
            yield return WAS;
            scene = SceneManager.GetActiveScene();
            itemNo = FindObjectsOfType<SaveState>().Length;
            PlayerPrefs.SetInt(scene.buildIndex + "itemNO", itemNo);
            int j = 0;
            foreach (var item in FindObjectsOfType<SaveState>())
            {
                PlayerPrefs.SetInt(scene.name + item.name + 0, 0);
                //紀錄存檔物件名稱
                PlayerPrefs.SetString(scene.buildIndex.ToString() + j, scene.name + item.name);
                j++;
                itemName.text += scene.name + item.name;
            }

            // if (i == 1) { FindObjectOfType<Player>().GetComponent<Rigidbody2D>().gravityScale = 0; }
            FindObjectOfType<Loader>().gameObject.SetActive(false);
        }

        SceneManager.LoadScene(0);
        yield return null;

        /*
        Blackout = GameObject.Find("BlackOut").GetComponent<CanvasGroup>();
        for (int i = 0; i < 10; i++)
        {
            Blackout.alpha -= 0.1f ;
            yield return WAS;
        }
        */
        PlayerPrefs.SetInt("Run", 1);
        Destroy(gameObject);
    }
    public GameObject Stone;
    private void Start()
    {
        //StartCoroutine(Runing());
        if (PlayerPrefs.GetInt("Run") == 1)
        {
            Destroy(Stone);
            Destroy(gameObject);
        }
        
    }

    private void Update()
    {

        if (Input.GetKeyDown("o")&& PlayerPrefs.GetInt("Run")!=1)
        {
            StartCoroutine(Runing());
            

        }

       

    }




}
