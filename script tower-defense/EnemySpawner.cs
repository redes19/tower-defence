using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public static EnemySpawner instance;

    void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject path;
    [SerializeField] GameObject spwanPoint;
    [SerializeField] GameObject enemyPreFab;
    [SerializeField] int enemyNumber;
    [SerializeField] float interval;
    //[SerializeField] int[] waves;
    [SerializeField] public int waveIndex;
    [SerializeField] int[] enemyAlive;

    ///////////////////////////////////////////
    public Waves[] waves;



    // Start is called before the first frame update
    void Start()
    {
       
        for(int i = 0; i < waves.Length; i++)
        {
            enemyAlive[waveIndex] = waves[waveIndex].count;
            waveIndex++;
        }
         waveIndex = 0;
        StartCoroutine(SpawnEnemies());// fonction ou l'on met des pauses
    }


    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(5f);

        

        for (int i = 0; i < waves[waveIndex].count; i++)
        {
            GameObject go = Instantiate(waves[waveIndex].enemy1, spwanPoint.transform.position, spwanPoint.transform.rotation);
            go.GetComponent<enemiemovement>().path = path;
            go.GetComponent<enemiemovement>().Init();


            yield return new WaitForSeconds(interval);
        }
        //j'attend que les ennemy sois tous morts
        while(enemyAlive[waveIndex] > 0)
        {
            yield return null;
        }


        //wave suivante
        waveIndex++;
        if(waveIndex < waves.Length)
        {
        StartCoroutine(SpawnEnemies());   
        }
        else
        {
            Debug.Log("END");
        }

    }

    public void EnemyDied()
    {
        enemyAlive[waveIndex]--;
    }

    

}

