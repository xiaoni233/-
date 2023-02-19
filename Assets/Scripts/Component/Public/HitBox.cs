using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
//ע��Ҫ��hitboxԶ�����
/// </summary>
public class HitBox : MyConponent
{
    private Collider2D obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        obj = collision;       
    }
    /// <summary>
    /// ����hitbox������⵽������ı�ǩ��Tag��ǩ�ȽϵĲ���ֵ
    /// </summary>
    /// <param name="Tag"></param>
    /// <returns></returns>
    public bool IsObjHurt(string Tag)
    {
        if (obj != null)
        {
            return obj.CompareTag(Tag);
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// �����¼�������
    /// </summary>
    /// <param name="Tag"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public bool IsObjHurt(string Tag,UnityAction callback)
    {
        if (obj != null)
        {
            callback.Invoke();
            return obj.CompareTag(Tag);
        }
        else
        {
            return false;
        }
    }
}
