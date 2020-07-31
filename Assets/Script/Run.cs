using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run : MonoBehaviour
{
    public CanvasGroup Blackout;

    WaitForSecondsRealtime WAS = new WaitForSecondsRealtime(0.01f);
    IEnumerator Runing()
    {

        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            SceneManager.LoadScene(i);
            yield return null;
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
    private void Start()
    {
       //StartCoroutine(Runing());
    }

    private void Update()
    {

        if (Input.GetKeyDown("o")&& PlayerPrefs.GetInt("Run")!=1)
        {
            StartCoroutine(Runing());
            

        }

       

    }




}
