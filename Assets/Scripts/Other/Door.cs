using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public GameObject doorTip;
    private bool inDoor;
    private void Update()
    {
        if(inDoor&&PlayerInputMgr.GetInstance().IsInteraction)
        {
            LevelChange();
        }
    }
    /// <summary>
    /// win必须是1号才行
    /// </summary>
    private void LevelChange()
    {
        SceneManager.LoadScene(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorTip.SetActive(true);
            inDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorTip.SetActive(false);
            inDoor = false;
        }
    }
}
