using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVarious :MonoBehaviour
{
    
    private static PlayerVarious _instance;
    private void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// 注意要在Awake之后调用，否则传空
    /// </summary>
    /// <returns></returns>
    public  static PlayerVarious GetInstance()
    {
            return _instance;
    }
    //动画
    [HideInInspector]public Animator animator;
    [HideInInspector] public AnimatorStateInfo info;

    //组件
    [HideInInspector] public PlayerInputMgr inputMgr;
    [HideInInspector] public HitBox playerHitbox;
    public MyPlayerController playerController;
    //布尔值
    [HideInInspector] public bool isAttackReady = true;


    //浮点数
    public float interval = 1.5f;//战斗间隔
    public float playerHurtIntervalTime;
    public float lightSpeed;
   [HideInInspector] public float playerExitTime;
    [Header("打击感")]
    public float shakeTime=0.1f;
    public float lightStrength=0.015f;
    public int lightPause=6;

}
