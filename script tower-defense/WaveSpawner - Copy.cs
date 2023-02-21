using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;
    [SerializeField] float timeBethwenWaves = 5f;

    float coutnDown = 2f;//debut de manche

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coutnDown <= 0f)
        {
            SpawnWave();
            coutnDown = timeBethwenWaves;
        }
        coutnDown -= Time.deltaTime;

    }


    void SpawnWave()
    {
        Debug.Log("C'est bon!!");
    }
}
