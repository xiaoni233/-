using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MyConponent
{
    protected NewPlayerController controller;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        controller=GetComponentInParent<NewPlayerController>();
    }
    
}
