using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public static GameManager instance;  
	public static bool GameIsOver;
	public static bool StartGame;
	public int Money;
	public  bool goGame;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;
	public GameObject startGameUI;
	public static int countEnemy;
	public  int totalEnemyWave;

	[SerializeField] int totalWaves;
	[SerializeField] Text totalManey;
	[SerializeField] Text currentWave;
	[SerializeField] Text playBtnText;
	[SerializeField] Text totaEnemy;
	[SerializeField] Text textMoney;
	[SerializeField] Button playBtn;

	int waveNumber = 0;
	int totalMone = 10;
	int totalEscape = 0;
	int roundEscape = 0;
	int totalkilld = 0;
	int whichEnemies = 0;

	void Start ()
	{
		goGame = false;
        GameIsOver = true;
		instance = this;
		Money = PlayerPrefs.HasKey("Money") ? PlayerPrefs.GetInt("Money") :0;	
		textMoney.text = "Money: "+ Money.ToString()+"$";

		//Скрываем все панели!
		gameOverUI.SetActive(false);
		completeLevelUI.SetActive(false);
		startGameUI.SetActive(false);	
		countEnemy = 0;
		GameIsOver = true;	
	}

	void Update () {
		if (GameIsOver)
		{
			EndGame(); 
		}		
		
 		if(countEnemy >= totalEnemyWave && GameIsOver)
		{	
			GameIsOver = false;
			WinLevel();
		}
		totaEnemy.text ="Enemy: "+totalEnemyWave.ToString();
		textMoney.text = "Money: "+ Money.ToString()+"$";
	}
	public void startGame()
	{
		WaveSpawner.goGame = true;
		PlayerController.goGame = true;
		WeaponAvtomat.goGame = true;
		
	}
	public void WinLevel ()
	{
		gameOverUI.SetActive(false);
		startGameUI.SetActive(false);
		completeLevelUI.SetActive(true);
		totalManey.text = "Money: "+totalMone.ToString()+"$";
		Money += totalMone;

		PlayerPrefs.SetInt("Money",Money);
	}
	public void EndGame ()
	{
		
		//gameOverUI.SetActive(true);
	}
	
	public void Shop()
	{
		gameOverUI.SetActive(false);
		startGameUI.SetActive(false);
		completeLevelUI.SetActive(false);
		SceneManager.LoadScene("Shop");
	}
	public void totalEneme(int _value)
	{
		 totalEnemyWave +=_value;
	}
	public void countEnemyMoney(int _value,int _money)
	{
		countEnemy += _value;
		totalMone = countEnemy * _money;
	}

	public void closedWind()
	{
	    gameOverUI.gameObject.SetActive(false);
		startGameUI.gameObject.SetActive(false);
		completeLevelUI.gameObject.SetActive(false);	
	}

}
