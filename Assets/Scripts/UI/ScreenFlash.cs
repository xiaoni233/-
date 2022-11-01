using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFlash : MonoBehaviour
{
    private Image img;
    public float time;
    public Color flashColor;
    private Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        defaultColor = img.color;
    }  

    public  void FlashScreen()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        img.color = flashColor;
        yield return new WaitForSeconds(time);
        img.color = defaultColor;
    }
   
}
