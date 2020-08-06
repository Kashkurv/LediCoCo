using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponSwitch : MonoBehaviour
{   
   
    void Start()
    {
        SelectWeapon();
    }
    void Update()
    {       
        
    }
    void SelectWeapon()
    {
        int i = 0;
        int indexWeapon = PlayerPrefs.HasKey("Weapon") ? PlayerPrefs.GetInt("Weapon") :0;
        foreach(Transform weapon in transform)
        {            
            if(i==indexWeapon)
            {
                weapon.gameObject.SetActive(true);
            }else{
                weapon.gameObject.SetActive(false);
            }
           i++;
        } 
    }
}
