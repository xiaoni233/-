using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDiolog : MonoBehaviour
{
    public GameObject enterDialog;
    public GameObject tips;
private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.tag == "Player")
    {
           tips.SetActive(true);
            Debug.Log("tip");
           
    }
}
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("InterAction");
        if (PlayerInputMgr.GetInstance().IsInteraction)
        {
            Debug.Log("InterAction");
            enterDialog.SetActive(true);
            tips.SetActive(false);
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
{
    if(collision.tag == "Player")
    {
           tips.SetActive(false);
            enterDialog.SetActive(false);
    }  
  }
}