using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private Vector3 spawnPos1 = new Vector3(25, 7, 0);
    private Vector3 spawnPosF = new Vector3(25, 5, 0);
    private Vector3 spawnPosF1 = new Vector3(25, 2, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }
    void Update()
    {
        
    }
    void spawnObstacle()
    {
        if (playerControllerScript.gameOver == false&&playerControllerScript.flyMode==false)
        {
          Instantiate(obstaclePrefab[2], spawnPos1, obstaclePrefab[2].transform.rotation);
          Instantiate(obstaclePrefab[Random.Range(0,2)], spawnPos, obstaclePrefab[Random.Range(0, 2)].transform.rotation);
        }
        if (playerControllerScript.gameOver == false && playerControllerScript.flyMode == true)
        {
            Instantiate(obstaclePrefab[2], spawnPosF1, obstaclePrefab[2].transform.rotation);
            Instantiate(obstaclePrefab[Random.Range(0, 2)], spawnPosF, obstaclePrefab[Random.Range(0, 2)].transform.rotation);
        }
       
    }
}
