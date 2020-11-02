using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{

	[SerializeField] int health;
	[SerializeField] int money;
	[SerializeField] int score;
	[SerializeField] Slider slider;

	private AudioMenager audio;
	private Rigidbody2D rigidbody;
	[SerializeField] Vector2 forceDir;

	[SerializeField] GameObject effectDestroy;
	[SerializeField] GameObject eggSpawn;
	[SerializeField] GameObject scoreDamage;
	private GameManager gameManager;
	private ScoreManager scoreManager;
	private void Start() 
	{
		slider.value = health;
		slider.maxValue = health;
		slider.gameObject.SetActive(false);
		gameManager = GameManager.instance;
		rigidbody = GetComponent<Rigidbody2D>();
		audio = AudioMenager.instance;
		scoreManager = ScoreManager.instance;
	}
	public void TakeDamage(int damage)
	{
		slider.gameObject.SetActive(true);
		health -= damage;
		slider.value = health;		
		audio.PlaySound("Hit_Hen");
		rigidbody.AddForce(forceDir);
		StartCoroutine(DamageAnimation());
		if (health <= 0)
		{
			Instantiate(effectDestroy, transform.position, transform.rotation);
			//Instantiate(eggSpawn, transform.position, transform.rotation);
			Vector2 damageScore = new Vector2(transform.position.x,transform.position.y);
		    Instantiate(scoreDamage,damageScore,Quaternion.identity);
		    scoreDamage.GetComponentInChildren<FloatingScore>().score = score;
			gameManager.countEnemyMoney(1,money);
			scoreManager.AddScore(score);
			scoreManager.AddDedEnemy(1);
			//ScoreManager.instance.AddDedEnemy(1);
			audio.PlaySound("HenDestroy");
			Destroy(gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("EndLevel"))
        {
			GameManager.countEnemy++;
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
