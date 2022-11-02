using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;//对话系统UI按钮显示接口
    public GameObject talkUI;//对话文本框显示接口

    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);//当进入文本对话显示范围，显示提示玩家按按钮进入对话
    }
    private void OnTriggerExit2D(Collider2D other)
    {
         Button.SetActive(false);
         talkUI.SetActive(false);//当退出对话范围时关闭对话框和按钮
    }

    // Update is called once per frame
    void Update()
    {
        if(Button.activeSelf && Input.GetKeyDown(KeyCode.R)){
            talkUI.SetActive(true);//检测按钮是否正在运行且玩家是否按下按钮（此处设置为R），当玩家按下按钮时显示对话框开始对话
        }
    }
}
