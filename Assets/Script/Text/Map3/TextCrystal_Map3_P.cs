using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextCrystal_Map3_P : Dialogue
{/*
    string[] DialogueText = new string[] {
        "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" + "小時候我時常望向窗外的庭院，那裡有一棵被藤蔓寄生的大樹，枯朽且搖搖欲墜。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"我長期臥病在床，一直持續接受治療卻沒有任何起色。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"父母為了我耗費大量心力與金錢，似乎也會委託附近的獵人收集森林的藥草。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"對於家道中落的父親是無法承受的重壓。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"雖然他們在我面前總是表現出沒問題的樣子，但是每天都被逼得焦頭爛額、身形也日益消瘦，讓我十分痛苦。",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"為什麼要為我做到這種程度？如果我趕快病死對大家都好……。為什麼當時死的不是我？",
    "少女：\n"  + "\u00A0\u00A0\u00A0\u00A0" +"我就像那些寄生在樹上的藤蔓一樣，不斷吸收這個家的生命力化作自己的養分",

    };
    */

    string[] DialogueText = new string[] {
    "少女：\n"  + "從小時候開始我就時常望向窗外的庭院，那裡有一棵被藤蔓寄生的大樹，枯朽且搖搖欲墜。",
    "少女：\n"  +  "因為生病的關係，生活幾乎都在床上度過，雖然持續接受治療，但我的病情卻沒有任何起色。",
    "少女：\n"  +  "父母為了我耗費大量心力與金錢，似乎也會委託附近的獵人收集森林的藥草。",
    "少女：\n"  + "對於家道中落的父親是無法承受的重壓。",
    "少女：\n"   +"雖然他們在我面前總是表現出沒問題的樣子，但是每天都被逼得焦頭爛額、身形也日益消瘦，讓我十分痛苦。",
    "少女：\n"   +"為什麼要為我做到這種程度？如果我趕快病死對大家都好……。為什麼當時死的不是我？",
    "少女：\n"  +  "我就像那些寄生在樹上的藤蔓一樣，不斷吸收這個家的生命力化作自己的養分……",
    "少女：\n"  +  "……",
    };

    public AudioSource SoundManager;
    public AudioClip final;
    public AudioClip type;
    public SpriteRenderer blackscreen;
    WaitForSecondsRealtime WAS4 = new WaitForSecondsRealtime(0.1f);
    WaitForSecondsRealtime WAS2 = new WaitForSecondsRealtime(2);
    IEnumerator end(int A,int B)
    {
        SoundManager.clip = final;
        SoundManager.volume = 0.5f;
        SoundManager.Play();
        for (int i = A; i < B; i++)
        {
            blackscreen.color = new Vector4(0,0, 0, 0.1f * i);
            yield return WAS4;
        }
        OpenDialogue();
        DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Time.timeScale = 0;
            StartCoroutine(end(1,6));
        }

    }

    protected override void Start()
    {
        SoundManager = FindObjectOfType<AudioSource>();
        base.Start();
        GetComponent<Crystal>().ID = 1;
    }

    string endString = "Chapter1 結束";
    public GameObject EndingText;
    public GameObject Credit2;
    WaitForSecondsRealtime WAS5 = new WaitForSecondsRealtime(0.3f);
    WaitForSecondsRealtime WAS6 = new WaitForSecondsRealtime(0.01f);
    WaitForSecondsRealtime WAS7 = new WaitForSecondsRealtime(0.15f);
    WaitForSecondsRealtime WAS8 = new WaitForSecondsRealtime(3.5f);

    IEnumerator end2()
    {
        endbool = true;
        yield return StartCoroutine(GM.BlackScreen(1, WAS7));
        GameObject tmp =  Instantiate(EndingText, GM.Blackout.transform);
        
        for (int i =0 ; i < endString.Length; i++)
        {
            //print(endString.Substring(i, 1));
            SoundManager.PlayOneShot(type, 0.8f);
            tmp.GetComponent<Text>().text += endString.Substring(i,1);
            yield return WAS5;
        }

            GameObject tmp2 = Instantiate(Credit2, GM.Blackout.transform);
        //tmp2.transform.localPosition =Vector3.up *-1900 ;
        while (tmp2.transform.localPosition.y<1815)
        {
            tmp.transform.Translate(Vector2.up);
                tmp2.transform.Translate(Vector2.up);
            print(tmp2.transform.localPosition.y);
            yield return WAS6;
        }

        tmp2.transform.localPosition = Vector3.up * 1820;

        yield return WAS8;


        print("Finish");
        SceneManager.LoadScene(0);

    }
    bool endbool;
    private void finishDialogue()
    {
       if(!endbool) StartCoroutine(end2());

    }


    private void Update()
    {
        if (DialogueON && Input.GetKeyDown("c"))
        {
            DialogueID += 1;

            if (DialogueID > DialogueText.Length - 1)
            {
                finishDialogue();
            }

            else
            {
                DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
            }


        }

        if (DialogueON && Input.GetKeyDown("s"))
        {
            finishDialogue();
        }

    }

}