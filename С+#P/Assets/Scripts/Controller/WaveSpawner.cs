using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
  public enum SpawnState{SPAWNING,WAITING,COUNTING}
  [System.Serializable]
  public class Wave
  {  
    public Transform[] enemy;
    public int count;
    public float rate;
  }
  public Wave[] waves;

  public Transform[] spawnPoint;
  public float timeBetweenWaves;
  public float startTimeWave;
  private float waveCountdown;

  private SpawnState state = SpawnState.COUNTING; 
  private int nextWave = 0;

  private float seachCountdown = 1f;
  public GameManager gameManager;

  public static bool goGame;
  [SerializeField] int totalEnemuWaves;
  private void Start()
 {
   waveCountdown = startTimeWave;  
   gameManager = GameManager.instance;
   //isStartGame = false;   
 }
  void Update()
  {
        if (goGame)
        {
            if (state == SpawnState.WAITING)
            {
                if (!EnemyIsAlive())
                {
                    WaveComplided();
                    return;
                }
                else
                {
                    return;
                }
            }
            if (waveCountdown <= 0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                    waveCountdown = timeBetweenWaves;
                    return;
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        } 
  }
  void WaveComplided()
  {
    state = SpawnState.COUNTING;
    waveCountdown = timeBetweenWaves;
     
    if(nextWave + 1 > waves.Length - 1)
    {
      nextWave = 0;
      this.enabled = false;  
      Debug.Log("!!!!!!!!!!LevelComoleted!!!!!!!!!!!!!");
      GameManager.instance.LevelCompleted();
    }else
    {
      Debug.Log("!!!!!!!!!!NextLEVEL!!!!!!!!!!!!!");
      nextWave++;
    }
  }
  bool EnemyIsAlive()
  {
    seachCountdown -= Time.deltaTime;
    if(seachCountdown<=0)
    {   
      seachCountdown =1f; 
       if(GameObject.FindGameObjectWithTag("Enemy") == null)
       {
         return false;
       }
    }
    return true;
  }
  IEnumerator SpawnWave(Wave _wave)
  {
	  state = SpawnState.SPAWNING;
	  for(int i=0;i<_wave.count;i++)
	  {
      Transform en= _wave.enemy[Random.Range(0, _wave.enemy.Length)];
      SpawnEnemy(en);
	  yield return new WaitForSeconds(_wave.rate);
	  }
	  state = SpawnState.WAITING;
    yield break;	  
  }
  void SpawnEnemy(Transform enemy)
  {    
    Transform sp= spawnPoint[Random.Range(0, spawnPoint.Length)];
    Instantiate(enemy,sp.transform.position,sp.transform.rotation);	  
  }
   

}
