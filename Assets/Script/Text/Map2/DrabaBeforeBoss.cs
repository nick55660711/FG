using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrabaBeforeBoss : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("Map3BossTriger" + 1) == 1)
        {
            Destroy(gameObject, 0.2f);
        }
    }
    


}
