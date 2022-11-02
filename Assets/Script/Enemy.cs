using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    protected static Animator Anim;
    protected static AudioSource music;
    // Start is called before the first frame update
public virtual void Start()
    {
                Anim = GetComponent <Animator>();
                music = GetComponent<AudioSource>();
    }
    // Update is called once per frame
        public static void Hit()
      {
        music.Play();
        Anim.SetTrigger("death");
      }
  }