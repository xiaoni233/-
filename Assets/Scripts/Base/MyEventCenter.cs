using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventCenter :Singleton<MyEventCenter>
{
    private Dictionary<string, UnityAction> eventDic = new Dictionary<string, UnityAction>();

    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="name">事件名</param>
    /// <param name="action">处理事件的委托函数</param>
    public void AddEventListener(string name,UnityAction action)
    {
        if(eventDic.ContainsKey(name))
        {
            eventDic[name] += action;
        }
        //没有添加字典key
        else
        {
            eventDic.Add(name, action);
        }
    }

    /// <summary>
    /// 事件触发
    /// </summary>
    /// <param name="name">哪个名字的事件触发了</param>
    public void EventTrigger(string name)
    {
        //有这个事件，便调用它的函数
        if(eventDic.ContainsKey(name))
        {
            eventDic[name].Invoke();
        }
    }
    /// <summary>
    /// 移除事件监听，避免物体不在的时候空指针异常
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener(string name,UnityAction action)
    {
        if (eventDic.ContainsKey(name))
            eventDic[name] -= action;
    }

    /// <summary>
    /// 切换场景时，清空事件
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }
}
