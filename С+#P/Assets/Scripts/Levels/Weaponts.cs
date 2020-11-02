using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponts : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private int indexWeapoints;
    private int speed =3;

    [SerializeField] GameObject effectDestroy;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(-speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeponSwitch _weapontSwitch = collision.GetComponent<WeponSwitch>();
        if (_weapontSwitch != null)
        {
            _weapontSwitch.SelectWeapon(indexWeapoints);
            //Instantiate(effectDestroy, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
