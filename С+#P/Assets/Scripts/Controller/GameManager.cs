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
	[SerializeField] Text scoreText;
	[SerializeField] Text hightScoreText;
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
        GameIsOver = false;
		instance = this;
		Money = PlayerPrefs.HasKey("Money") ? PlayerPrefs.GetInt("Money") :0;	
		textMoney.text = "Money: "+ Money.ToString()+"$";

		//startGame();
		countEnemy = 0;			
		StartGame = false;
		startGameUI.SetActive(true);
	}

	void Update () {
		if (GameIsOver)
		{
			EndGame(); 
		}		
		
 		if(countEnemy >= totalEnemyWave && GameIsOver)
		{	
			GameIsOver = false;
			LevelCompleted();
		}
		totaEnemy.text ="Enemy: "+totalEnemyWave.ToString();
		textMoney.text = "Money: "+ Money.ToString()+"$";
	}
	public void startGame()
	{
		PlayerController.goGame = true;
		WeaponAvtomat.goGame = true;
		WaveSpawner.goGame = true;
		//Скрываем все панели!
		gameOverUI.SetActive(false);
		completeLevelUI.SetActive(false);
		startGameUI.SetActive(false);

	}
	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
		ScoreManager.instance.ResetScore();
	}
	public void LevelCompleted ()
	{
		gameOverUI.SetActive(false);
		startGameUI.SetActive(false);
		completeLevelUI.SetActive(true);
		scoreText.text = ScoreManager.score.ToString();
		int hightScore = PlayerPrefs.GetInt("HightScore");
		hightScoreText.text = hightScore.ToString();
	}
	public void EndGame ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
