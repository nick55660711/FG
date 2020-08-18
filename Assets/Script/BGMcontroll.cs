using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMcontroll : MonoBehaviour
{
    public AudioClip CastleBGM;
    public AudioClip ForestBGM;
    AudioSource SoundManager;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager = GetComponent<AudioSource>();

        string SceneName = SceneManager.GetActiveScene().name;
       
        if (SceneName == "Map2"|| SceneName == "Map3") { SoundManager.clip = CastleBGM;
            SoundManager.Play();
        }
    }

    
}
