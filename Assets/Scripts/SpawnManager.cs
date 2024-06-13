using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private int intervalOfZ = 20;
    private int spawnPosZ = 10; 
    private float randomX;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        int randomX = Random.Range(-intervalOfZ, intervalOfZ);

        Vector3 posPrefab = new Vector3(randomX, 1, spawnPosZ);

        Instantiate(enemyPrefab, posPrefab, enemyPrefab.transform.rotation);
    }
}
