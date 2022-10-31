using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerAttackAnim : PlayerComponent
{
    private Animator animator;
    private float timer;
    private int comboCount;

    private void Awake()
    {
        comboCount = 1;
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(controller.isLightAttack);
        //Debug.Log(controller.isAttackReady);
        if(controller.isLightAttack&&controller.isAttackReady)
        {
            controller.isAttackReady = false;
            controller.isAttack = true;
            animator.SetTrigger("LightAttack");
            animator.SetInteger("ComboCount", comboCount);
        }
        if(comboCount>3)
        {
            SetComboCountOne();
        }
    }
    public void SetComboCountOne()
    {
        comboCount = 1;
    }
    public void ComboCountPlus()
    {
        comboCount++;
    }  

}
