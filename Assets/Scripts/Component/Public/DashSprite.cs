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

    [Header("ʱ����Ʋ���")]
    public float activeTime;//��ʾʱ��
    public float activeStart;//��ʼ��ʾ��ʱ���

    [Header("��͸���ȿ���")]
    private float alpha;//��͸����
    public float alphaSet;
    public float alphaMultiplier;

    private void OnEnable()
    {
        dashOj = GameObject.FindGameObjectWithTag(dashOjTag).transform;//���dash��������
        thisSprite = GetComponent<SpriteRenderer>();
        dashOjSprite = dashOj.GetComponent<SpriteRenderer>();//���Ŀ�������SpriteRenderer,����ʱ�ͻḴ��dash�����renderͼƬ
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
            //���ض����
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }

}
