using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public CanvasGroup MenuScreen;
    public bool OpenScreen;
    GameManager GM;

    public void OptionOpen()
    {
        MenuScreen.alpha = 1;
        MenuScreen.interactable = true;
        MenuScreen.blocksRaycasts = true;
        GM.GamePause();
    }

    public void OptionClose()
    {
        MenuScreen.alpha = 0;
        MenuScreen.interactable = false;
        MenuScreen.blocksRaycasts = false;
        GM.GameContinue();
    }

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    public bool StopMenu;
    private void Update()
    {

        if (Input.GetKeyDown("m")&& !StopMenu)
        {
            OpenScreen = !OpenScreen;
            if (OpenScreen)  OptionOpen();
            if(!OpenScreen)  OptionClose();
        }

    }


}
