using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public int damage;	
	public GameObject impactEffect;
	

	void Start () {
		
	}
    void Update() {

		transform.Translate(Vector2.right* speed * Time.deltaTime);
		Destroy(gameObject,2f);
	}
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
		if (enemy != null)
		{			
			enemy.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}		
		
	}
	
}
