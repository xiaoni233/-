using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMgr : MonoBehaviour
{
    private PlayerVarious various;
    
    private int comboCount=0;
    private float timer;

    private void Start()
    {
        various = PlayerVarious.GetInstance();
    }

    private void Update()
    {
        Attack();
    }
    //
    private void Attack()
    {
       
        if(various.inputMgr.IsLightAttackButtonDowm()&& various.isAttackReady)
        {          
            various.playerController.SetVelocityX(various.playerController.transform.localScale.x * various.lightSpeed);
            various.isAttackReady = false;
            comboCount++;
            if (comboCount > 3)
                comboCount = 1;
            timer = various.interval;
            various.animator.SetTrigger("LightAttack");
            various.animator.SetInteger("ComboCount", comboCount);
            //攻击敌人
            if (various.playerHitbox.IsObjHurt("Enemy"))
            {
                MyEventCenter.GetInstance().EventTrigger("EnemyHurt");
                CameraController.Instance.HitPause(various.lightPause);
                CameraController.Instance.CameraShake(various.shakeTime, various.lightStrength);
            }
        }
        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                comboCount = 0;
            }
        }
    }
    /// <summary>
    /// 提供动画事件函数，攻击结束后调用
    /// </summary>
    public void AttackOver()
    {
        various.isAttackReady = true;
    }

}
