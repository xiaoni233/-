using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private static GameManger gameManger;

    public static GameManger Instance
    {
        get
        {
            if (gameManger == null)
                gameManger = Transform.FindObjectOfType<GameManger>();
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
