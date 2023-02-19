using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManger : MonoBehaviour
{
    private static MyGameManger gameManger;

    public static MyGameManger Instance
    {
        get
        {
            if (gameManger == null)
                gameManger = Transform.FindObjectOfType<MyGameManger>();
            return gameManger;
        }
        set => gameManger = value;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void RecoverTime()
    {
        Time.timeScale = 1;
    }
}
