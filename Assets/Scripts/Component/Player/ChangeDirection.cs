using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : PlayerComponent
{
     public void ChangeDirX(int direcX)
    {
        controller.transform.localScale =new Vector3(direcX, controller.transform.localScale.y, controller.transform.localScale.z);
    }
}
