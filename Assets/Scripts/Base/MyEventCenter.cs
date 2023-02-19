using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyEventCenter :Singleton<MyEventCenter>
{
    private Dictionary<string, UnityAction> eventDic = new Dictionary<string, UnityAction>();

    /// <summary>
    /// ����¼�����
    /// </summary>
    /// <param name="name">�¼���</param>
    /// <param name="action">�����¼���ί�к���</param>
    public void AddEventListener(string name,UnityAction action)
    {
        if(eventDic.ContainsKey(name))
        {
            eventDic[name] += action;
        }
        //û������ֵ�key
        else
        {
            eventDic.Add(name, action);
        }
    }

    /// <summary>
    /// �¼�����
    /// </summary>
    /// <param name="name">�ĸ����ֵ��¼�������</param>
    public void EventTrigger(string name)
    {
        //������¼�����������ĺ���
        if(eventDic.ContainsKey(name))
        {
            eventDic[name].Invoke();
        }
    }
    /// <summary>
    /// �Ƴ��¼��������������岻�ڵ�ʱ���ָ���쳣
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener(string name,UnityAction action)
    {
        if (eventDic.ContainsKey(name))
            eventDic[name] -= action;
    }

    /// <summary>
    /// �л�����ʱ������¼�
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }
}
