using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_V : MonoBehaviour
{
    public GameObject[] Draba;
    Boss boss;
    public Transform player1;

    float Time = 5;
    WaitForSecondsRealtime WAS4 = new WaitForSecondsRealtime(5);
    IEnumerator Grow_V()
    {
        while (boss.Hp > 0)
        {

            yield return WAS4;


            float X = player1.position.x;
            Vector2 RandomPox = new Vector2(Random.Range(X-3, X+3), -0.9f);
            GameObject tmp = Instantiate(Draba[0], RandomPox, Quaternion.Euler(0, 0, 0));
            tmp.transform.SetParent(transform);
        }
       

    }
    public void Overdrive()
    {
        Time -= 0.5f;
        WaitForSecondsRealtime WAS4 = new WaitForSecondsRealtime(Time);
    }

    private void Start()
    {
        boss= GetComponent<Boss>();
        player1 = FindObjectOfType<Player>().transform;
        StartCoroutine(Grow_V());
    }

}
