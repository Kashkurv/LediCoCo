using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAvtomat : MonoBehaviour
{
    public static bool goGame;
    public GameObject bulletAvtomat;
    public GameObject muzzelEffects;
    public GameObject gilzaEffects;
    public Transform shootDir;
    public Transform gilzaDir;
    public String nameAudio;

    private float timeShoot;
    public float startTimeShoot;
    private AudioMenager audioMenager;

    private Animator animator;
    private GameManager gameManager;
    void Start()
    {
       audioMenager = AudioMenager.instance;
       animator = GetComponent<Animator>();
       gameManager = GameManager.instance;
       goGame = false;
    }

    void Update()
    {   
        
        if(timeShoot <=0){  
         if(Input.GetKey(KeyCode.Space))
           {
            animator.Play("Attack");
            timeShoot = startTimeShoot;
            audioMenager.PlaySound(nameAudio);
            Instantiate(bulletAvtomat,shootDir.position,shootDir.rotation);
            Instantiate(muzzelEffects,shootDir.position,shootDir.rotation);
            Instantiate(gilzaEffects,gilzaDir.position,gilzaDir.rotation);
           }
        }else
        {
            timeShoot -=Time.deltaTime;
        }
    
    }   
}
