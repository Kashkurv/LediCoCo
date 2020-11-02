using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponSwitch : MonoBehaviour
{   
    [SerializeField] int indexWeapon;
    void Start()
    {
        SelectWeapon(0);
        indexWeapon = PlayerPrefs.HasKey("Weapon") ? PlayerPrefs.GetInt("Weapon") :0;
    }
    void Update()
    {       
        
        int currentWeapon = indexWeapon;
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            indexWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount>=2)
        {
            indexWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount>=3)
        {
            indexWeapon = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount>=4)
        {
            indexWeapon = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount>=5)
        {
            indexWeapon = 4;
        }
        if(Input.GetKeyDown(KeyCode.Alpha6) && transform.childCount>=6)
        {
            indexWeapon = 5;
        }
        if(currentWeapon != indexWeapon)
        {
            SelectWeapon(0);
        } 

    }

    public void BtnSlectWeapoint(int index)
    {
        if(index==0)
        {
            indexWeapon = 0;
            SelectWeapon(0);
        }
        if(index==1&& transform.childCount>=2)
        {
            indexWeapon = 1;
            SelectWeapon(1);
        }
        if(index==2&& transform.childCount>=3)
        {
            indexWeapon = 2;
            SelectWeapon(2);
        }
        if(index==3&& transform.childCount>=4)
        {
            indexWeapon = 3;
            SelectWeapon(3);
        }
        if(index==4&& transform.childCount>=5)
        {
            indexWeapon = 4;
            SelectWeapon(4);
        }
        if(index==5 && transform.childCount>=6)
        {
            indexWeapon = 5;
            SelectWeapon(5);
        }
    }
    public void SelectWeapon(int _value)
    {
        int i = 0;     
        foreach(Transform weapon in transform)
        {            
            if(i== _value)
            {
                weapon.gameObject.SetActive(true);
            }else{
                weapon.gameObject.SetActive(false);
            }
           i++;
        } 
    }
}
