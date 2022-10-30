using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public List<MyConponent> cpList;
    private Dictionary<System.Type, MyConponent> componentTable;

    protected void ComponentInitialize()
    {
        componentTable = new Dictionary<System.Type, MyConponent>(cpList.Count);
        foreach (MyConponent cp in cpList)
        {
            componentTable.Add(cp.GetType(), cp);
        }
    }

    protected bool FindComponentInTable(System.Type type)
    {
       return componentTable.ContainsKey(type);
    }

    protected MyConponent GetMyComponent(System.Type  type)
    {
        if(FindComponentInTable(type)!=false)
        {
            return componentTable[type];
        }
        return null;
    }

    /// <summary>
    /// 设置激活或失活，找不到返回false
    /// </summary>
    /// <param name="isActive"></param>
    /// <param name="type"></param>
    /// <returns></returns>
   protected bool SetMyComponentActive(bool isActive, System.Type type)
    {
        MyConponent myCp = GetMyComponent(type);
        if (myCp!=null)
        {
            myCp.enabled = isActive;
            return true;
        }
        else
        {
            return false;
        }
    }

    protected bool isMyCpActive(System.Type type)
    {
        MyConponent myCp = GetMyComponent(type);
        if (myCp != null)
        {
            return myCp.enabled;
        }
        else
        {
            return false;
        }
    }


}
