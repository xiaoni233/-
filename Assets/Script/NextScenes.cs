using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScenes : MonoBehaviour
{
 void Update()
{
        if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        } 
    } 
  } 