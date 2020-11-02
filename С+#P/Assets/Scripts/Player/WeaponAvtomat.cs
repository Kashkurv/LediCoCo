using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAvtomat : MonoBehaviour
{
    public static bool isFire;
    public static bool goGame;
    [SerializeField] GameObject bulletAvtomat;
    [SerializeField] GameObject muzzelEffects;
    [SerializeField] GameObject gilzaEffects;
    [SerializeField] Transform shootDir;
    [SerializeField] Transform gilzaDir;
    [SerializeField] String nameAudio;


    private float timeShoot;
    [SerializeField] float startTimeShoot;
    [SerializeField] int maxAmmo;
    [SerializeField] int currentAmmo;
    [SerializeField] float reloadTime;
    private bool isReloading = false;
    [SerializeField] Text currenAmmoText;
    
    private AudioMenager audioMenager;
    private Animator animator;
    private GameManager gameManager;
    void Start()
    {
       animator = GetComponent<Animator>();
       audioMenager = AudioMenager.instance;
       gameManager = GameManager.instance;
       isFire = false;  
       isReloading = false;
       currentAmmo = maxAmmo;
       currenAmmoText.text ="Bullet:" + currentAmmo.ToString();
    }

    void Update()
    { 
        currenAmmoText.text = "Bullet:" + currentAmmo.ToString();
        if(isReloading)
           return;
      
        if(currentAmmo <= 0)
        {
          StartCoroutine(Reload());
          return;
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isFire = true;
        }else if(Input.GetKeyUp(KeyCode.Space)){
            isFire = false;
        }

        if(isFire && goGame)
        {
            if(timeShoot <=0){
            animator.Play("Attack");
            timeShoot = startTimeShoot;
            audioMenager.PlaySound(nameAudio);
            currentAmmo--;
            Instantiate(bulletAvtomat,shootDir.position,shootDir.rotation);
            Instantiate(muzzelEffects,shootDir.position,shootDir.rotation);
            Instantiate(gilzaEffects,gilzaDir.position,gilzaDir.rotation);            
            }else{
            timeShoot -=Time.deltaTime;
            }  
        }
    }   

    public void onFire()
    {
        isFire = true;
    }
    public void offFire()
    {
        isFire = false;
    }

    IEnumerator Reload()
    {
        Debug.Log("Realoding...");
        animator.Play("Reloading");
        yield return new WaitForSeconds(reloadTime);
        //currentAmmo = maxAmmo;
        timeShoot = startTimeShoot;
        isFire = false;
    }
}
