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




    public void CameraSet (int Y)
    {

        transform.position = new Vector3(player1.transform.position.x, Y, -10);
        SetON = true;

    }


    public void CancelSet()
    {

        SetON = false;

    }

    private void Start()
    {
        player1 = FindObjectOfType<Player>();
    }





    private void Update()
    {
       

        if (!SetON)
        {
            if (player1.transform.position.y > 6.5f)
            {
                Y = player1.transform.position.y - 2f;
            }

            else if (player1.transform.position.y < 5.5f)
            {
                Y = 4.5f;
            }

            X = transform.position.x;
            X =  Mathf.Lerp(X, player1.transform.position.x, 0.5f * Time.deltaTime * speed );

            if(player1.Timer2<2)
            transform.position = new Vector3(X, Y, -10);
            else
            transform.position = new Vector3(player1.transform.position.x, Y, -10);
        }



    }

   


}
