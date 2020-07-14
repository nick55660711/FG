using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEvent_1 : Dialogue
{
    public GameObject Enemy;
    public bool SpawnON;


    


    /// <summary>
    /// 生成怪物在玩家位置
    /// </summary>
    /// <param name="collider">玩家</param>
    public void createEnemy(Transform collider)
    {
       

            Instantiate(Enemy, collider.position, Quaternion.identity);
       

    }

   






    string[] DialogueText = new string[] { "少女：\n" + "\u00A0\u00A0\u00A0\u00A0" + "好痛" };


private void OnTriggerEnter2D(Collider2D collision)
{
        //生成怪物

        if (!SpawnON && collision.tag == "Player")
        {
            createEnemy(collision.transform);
            SpawnON = true;
        }


        //開啟對話
        if (collision.tag == "Player")
    {
        Invoke("OpenDialogue", 0.5f);
        DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
    }

}

protected override void Start()
{
    base.Start();
}


    private void Update()
    {
        if (DialogueON && Input.GetKeyDown("c"))
        {
            DialogueID += 1;
            if (DialogueID > DialogueText.Length - 1)
            {
                CloseDialogue();
                //關閉提示訊息
                DialogueScreen.GetComponentsInChildren<Text>()[1].gameObject.SetActive(false);
                Destroy(gameObject);
            }

            else
            {
                DialogueScreen.GetComponentInChildren<Text>().text = DialogueText[DialogueID];
            }

        }

        if (DialogueON && Input.GetKeyDown("s"))
        {
            CloseDialogue();
            //關閉提示訊息
            DialogueScreen.GetComponentsInChildren<Text>()[1].gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }
}
