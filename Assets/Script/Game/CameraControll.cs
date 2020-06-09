using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Player player1;
    private float X;
    private float Y;


    private void Start()
    {

        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    private void Update()
    {
        // X = Mathf.Clamp(X, player1.transform.localPosition.x, player1.transform.localPosition.x);

        // Y = Mathf.Clamp(Y, player1.transform.localPosition.y - 3, player1.transform.localPosition.y + 4);
        

        if (player1.transform.position.y > 7f)
        {
            Y = player1.transform.position.y - 2.5f ;
        }

        else if(player1.transform.position.y < 5.5f)
        {
            Y = 4.5f;
        }

            transform.position = new Vector3(player1.transform.position.x, Y, -10);
    

    }

   


}
