using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartButton : MonoBehaviour
{
   public void Restart()
   {
        Debug.Log("restart");
        SceneManager.LoadScene(0);
    }
}
