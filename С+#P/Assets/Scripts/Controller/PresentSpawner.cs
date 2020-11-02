using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PresentSpawner : MonoBehaviour
{
    public static PresentSpawner instance;

    [SerializeField] Transform[] spawnPoint;

    [SerializeField] GameObject[] Weaponts;
    [SerializeField] GameObject[] View;
    [SerializeField] GameObject[] Bullet;
    [SerializeField] GameObject Box;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }
    public void SpawnPesentBox()
    {
        Transform sp = spawnPoint[Random.Range(0, spawnPoint.Length)];
        Instantiate(Box, sp.transform.position, sp.transform.rotation);
    }
   public  void SpawnWeapont()
    {
        int rd = Random.Range(0,Weaponts.Length);
        Transform sp = spawnPoint[Random.Range(0, spawnPoint.Length)];
        Instantiate(Weaponts[rd],sp.transform.position,sp.transform.rotation);
    }
    void SpawnView(Transform view)
    {
        Transform sp = spawnPoint[Random.Range(0, spawnPoint.Length)];
        Instantiate(view, sp.transform.position, sp.transform.rotation);
    }
}
