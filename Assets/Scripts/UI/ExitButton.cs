using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
   public void  ExitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
