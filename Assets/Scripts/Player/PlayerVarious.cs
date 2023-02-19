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
    /// ע��Ҫ��Awake֮����ã����򴫿�
    /// </summary>
    /// <returns></returns>
    public  static PlayerVarious GetInstance()
    {
            return _instance;
    }
    //����
    [HideInInspector]public Animator animator;
    [HideInInspector] public AnimatorStateInfo info;

    //���
    [HideInInspector] public PlayerInputMgr inputMgr;
    [HideInInspector] public HitBox playerHitbox;
    public MyPlayerController playerController;
    //����ֵ
    [HideInInspector] public bool isAttackReady = true;


    //������
    public float interval = 1.5f;//ս�����
    public float playerHurtIntervalTime;
    public float lightSpeed;
   [HideInInspector] public float playerExitTime;
    [Header("�����")]
    public float shakeTime=0.1f;
    public float lightStrength=0.015f;
    public int lightPause=6;

}
