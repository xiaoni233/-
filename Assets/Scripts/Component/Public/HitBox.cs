using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
//注意要把hitbox远离地面
/// </summary>
public class HitBox : MyConponent
{
    private Collider2D obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        obj = collision;       
    }
    /// <summary>
    /// 返回hitbox触发检测到的物体的标签与Tag标签比较的布尔值
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
    /// 触发事件的重载
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
