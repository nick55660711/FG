using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Player player1;
    private float X;
    private float Y;
    public float speed;
    public bool SetON;
    public bool Set_height;
    private float Y_fix;

    public GameManager GM;


    public void CameraSet (float A)
    {
       // Set_height = true;
           Y_fix = A;
       // transform.position = new Vector3(player1.transform.position.x, Y, -10);

    }

    public void Shake() {
        SetON = true;
        transform.position = new Vector3(player1.transform.position.x, Y, depth);
    }

    public void CancelSet()
    {

        SetON = false;

    }
    float depth = -10;
    private void Start()
    {
        //transform.rotation = Quaternion.Euler(Vector3.zero);
        //depth = -10;
        Y_fix = 0;
       GM = FindObjectOfType<GameManager>();
        player1 = FindObjectOfType<Player>();
        player1.OnDead += () => { SetON = true; };
        CancelSet();
      //  GM.onChangeScene += CancelSet;
    }
    /*
    bool reverse;
    WaitForSecondsRealtime WAS = new WaitForSecondsRealtime(0.0001f);
    IEnumerator reversal()
    {
        Time.timeScale = 0;
        // Vector3 Pos = new Vector3(transform.position.x, transform.position.y, 0);
        float i = 0;
        while (i<180)
        {
            i += 1;
            transform.Rotate( Vector3.up);
            yield return WAS;

        }




        transform.rotation =Quaternion.Euler (Vector3.up * 180);

        Time.timeScale = 1;


    }
    */

    private void Update()
    {
       

        if (!SetON&&!Set_height)
        {
            if (player1.transform.position.y > 5.5f+ Y_fix)
            {
                Y = player1.transform.position.y - 1f;
            }

            else if (player1.transform.position.y < 5.5f+ Y_fix)
            {
                Y = 4.5f+ Y_fix;
            }

            X = transform.position.x;
            X =  Mathf.Lerp(X, player1.transform.position.x, 0.5f * Time.deltaTime * speed );

            transform.position = new Vector3(X, Y,-10);
        }
        /*
        if (!reverse&&player1.HP <90)
        {
            reverse = true;
            StartCoroutine(reversal());
        }

    */
    }

   


}
