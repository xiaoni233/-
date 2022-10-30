using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputMgr :MonoBehaviour
{
    private void Awake()
    {
        input = this;
    }
    
    public static PlayerInputMgr GetInstance()
    {
        return input;
    }
    private static PlayerInputMgr input;
    private Vector2 axes;
    private float axesX;
    private bool isJump;
    private bool isDash;
    private bool isMove;
    private bool isStopJump;
    private bool isAttack;
    
    private bool flag = true;
    public Vector2 Axes
    {
        get { return axes; }
        private set { axes = value; }
    }
    public float AxesX
    {
        get { return axesX; }
        private set { axesX = value; }
    }
    public bool IsMove
    {
        get { return isMove; }
        private set { isMove = value; }
    }
    public bool IsJump
    {
        get { return isJump; }
        private set { isJump = value; }
    }
    public bool IsDash
    {
        get { return isDash; }
        private set { isDash = value; }
    }
    
    public bool IsStopJump
    {
        get { return isStopJump; }
        private set {  isStopJump = value; }
    }
    public bool IsAttack { get => isAttack; set => isAttack = value; }

    public void  EnableGameplayInput()
    {        
        GameObject.Find("Player").GetComponent<PlayerInput>().enabled=flag;
        flag = !flag; 
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        //Debug.Log("MoveInput:" + context.ReadValue<Vector2>());
        Axes = context.ReadValue<Vector2>();
        AxesX = Axes.x;
        IsMove = (AxesX != 0f);
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        IsJump = context.ReadValueAsButton();
        isStopJump = context.canceled;
       // Debug.Log("StopJump"+isStopJump);
        //if (context.started)
        //{
        //    Debug.Log("Jump Start:" +context.ReadValueAsButton());
        //}
        //if(context.performed)
        //{
        //    Debug.Log("Jump Keep:" + context.ReadValueAsButton());
        //}
        //if(context.canceled)
        //{
        //    Debug.Log("Jump Release:" + context.ReadValueAsButton());
        //}
    }
    public void OnAttackInput(InputAction.CallbackContext context)
    {
        IsAttack = context.ReadValueAsButton();    
        //Debug.Log("Attack:" );
    }
    public void OnDashInput(InputAction.CallbackContext context)
    {
        IsDash = context.ReadValueAsButton();
    }
    public bool IsLightAttackButtonDowm()
    {
        return Input.GetKeyDown(KeyCode.J);
    }


}
