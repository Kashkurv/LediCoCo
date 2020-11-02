using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentBox : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private int speed;

    [SerializeField] int health;
    [SerializeField] Vector2 forceDir;
    [SerializeField] GameObject effectDestroy;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        speed = Random.Range(2,4);
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(-speed, 0);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        rigidbody.AddForce(forceDir);
        StartCoroutine(DamageAnimation());
        if (health <= 0)
        {
            //Instantiate(effectDestroy, transform.position, transform.rotation);
            //audio.PlaySound("HenDestroy");
            //PresentSpawner.instance.SpawnWeapont();
            Destroy(gameObject);
        }
    }
    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0.5f;
                sr.color = c;
            }
            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

}
