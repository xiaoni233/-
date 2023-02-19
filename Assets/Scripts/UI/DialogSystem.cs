using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")] 
    public Text textLabel;//设置文本显示接口
    public Image faceImage;//设置人物头像显示接口

    [Header("文本文件")]
    public TextAsset textFile;//txt文件读取接口
    public int index;//读取txt文件文字行数

    List<string> textList = new List<string>();//转换txt文字为string形式（保证正常输出）

    // Start is called before the first frame update
    void Start()
    {
        GetTextFormFile(textFile);//获取txt文本内容
        index = 0;//从第1行开始读取
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){        
            if (index < textList.Count)
            {
                textLabel.text = textList[index];
                index++;
            }
        }//当输入r时显示当前读取行的文字内容，同时读取行数+1，以便玩家下次按r输出接下来的文本内容
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();//先清空文本框已有内容，防止两段不同对话接轨
        index = 0;

        var lineDate = file.text.Split('\n');//读取txt每行文字

        foreach (var line in lineDate)
        {
            textList.Add(line);//添加txt文字进对话文本框
        }
    }
}
