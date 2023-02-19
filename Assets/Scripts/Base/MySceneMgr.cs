using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneMgr : MonoBehaviour
{
    private MySceneMgr sceneMgr;

    public MySceneMgr SceneMgr
    {
        get
        {
            if (sceneMgr == null)
                sceneMgr = Transform.FindObjectOfType<MySceneMgr>();
            return sceneMgr;
        }
       private set => sceneMgr = value;
    }




}
