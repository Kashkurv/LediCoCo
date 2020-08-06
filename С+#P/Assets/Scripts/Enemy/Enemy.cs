using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int damage;
    public int healch;

    private PlayerHealth player;
    public Vector3 attackOffset;
    private Rigidbody2D rigidbody;
    
    

	public float attackRange = 1f;
	public LayerMask attackMask;
    
   private float timeBtnAttack;
	public float StartBtnAttack;

   
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
       
    }
  
    void Update()
    {
       rigidbody.velocity = new Vector2(-speed,0);
        
        Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;
		
		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
            if(timeBtnAttack<=0){
                timeBtnAttack = StartBtnAttack;            
		        colInfo.GetComponent<PlayerHealth>().TakeDamage(damage);
            }else{
                timeBtnAttack-=Time.deltaTime;
            }
		}
    }

    
 
}
