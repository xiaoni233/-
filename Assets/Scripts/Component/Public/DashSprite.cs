using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSprite : MonoBehaviour
{
    private Transform dashOj;
    private SpriteRenderer thisSprite;
    private SpriteRenderer dashOjSprite;
    public string dashOjTag;

    private Color color;

    [Header("时间控制参数")]
    public float activeTime;//显示时间
    public float activeStart;//开始显示的时间点

    [Header("不透明度控制")]
    private float alpha;//不透明度
    public float alphaSet;
    public float alphaMultiplier;

    private void OnEnable()
    {
        dashOj = GameObject.FindGameObjectWithTag(dashOjTag).transform;//获得dash物体引用
        thisSprite = GetComponent<SpriteRenderer>();
        dashOjSprite = dashOj.GetComponent<SpriteRenderer>();//获得目标物体的SpriteRenderer,激活时就会复制dash物体的render图片
        alpha = alphaSet;
        thisSprite.sprite = dashOjSprite.sprite;

        transform.position = dashOj.position;
        transform.localScale = dashOj.localScale;
        transform.rotation = dashOj.rotation;
        activeStart = Time.time;
    }
    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(0.5f, 0.5f, 1, alpha);//(,r,g,b)
        thisSprite.color = color;

        if(Time.time>=activeStart+activeTime)
        {
            //返回对象池
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }

}
