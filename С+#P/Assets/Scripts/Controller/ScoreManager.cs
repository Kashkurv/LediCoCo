using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public static int score;
    public static int countDedEnemy;
    public int  hightScore;
    [SerializeField] Text scoreText, countDedEnemyText;
    void Start()
    {
        instance = this;
        countDedEnemy = 0;
        /*if(PlayerPrefs.HasKey("HightScore"))
        {
            hightScore = PlayerPrefs.GetInt("HightScore");
            hightScoreText.text = hightScore.ToString();
        }*/
    }
    void Update()
    {
        
    }
    public void AddScore(int _value)
    {
        score += _value;
        UpdateHightScore();
        scoreText.text = score.ToString();
    }
    public void AddDedEnemy(int _value)
    {
        countDedEnemy += _value;
        countDedEnemyText.text = countDedEnemy.ToString();
    }
    public void UpdateHightScore()
    {
       if(score > hightScore)
        {
           hightScore = score;
          // hightScoreText.text = hightScore.ToString();
           PlayerPrefs.SetInt("HightScore", hightScore);
        }
        if (score >= 10)
        {
            PresentSpawner.instance.SpawnWeapont();
        }
    }
    public void ResetScore()
    {
        score = 0;        
    }
    public void ClearHightScore()
    {
        PlayerPrefs.DeleteKey("HightScore");
        hightScore = 0;
    }

    
}
