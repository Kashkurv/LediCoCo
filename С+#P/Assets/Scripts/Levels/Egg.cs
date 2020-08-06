using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    float speed;
    float timeStamp;    

    Vector2 playerDerection;
    Rigidbody2D rigidbody;
    [SerializeField] GameObject player;
    private GameManager gameManager;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        speed = Random.Range(2, 3);
        gameManager = GameManager.instance;
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(-speed, 0);        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EndLevel"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            timeStamp = Time.time;
           // gameManager.setMoney(10);
            
            Destroy(gameObject);
        }
    }
}