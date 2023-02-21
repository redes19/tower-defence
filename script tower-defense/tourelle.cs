using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourelle : MonoBehaviour
{
    [SerializeField] GameObject enemy; //target
    [SerializeField] GameObject bulletPreFab;// pour placer le prefabriquer de la bullet
    [SerializeField] GameObject boutCanon;//créer une place pour le spawn de la balle
    [SerializeField] GameObject rotationCanon;
    GameObject currentBullet;

    [SerializeField] float reloadTime = 0.5f;
    float timeToSpawn;
    [SerializeField] float towerRange = 15f;
    [SerializeField] LayerMask enemyLayer;
    public int prixTurretB = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si j'ai une target
        if(enemy != null)
        {   
            //regarde l'enemy
            rotationCanon.transform.LookAt(enemy.transform.position); 

            //check si enemy toujours in range
            float distance = Vector3.Distance(transform.position ,enemy.transform.position);
            distance -= 0.5f;//when un bout du collider de l'enemy touche la range de la tour il est pris pour cible
            if(distance > towerRange)
            {
                enemy = null;
                return;//le retourn le code en dessus n'est pas exécuter et remonte la boucle
            }

            Tire();
            
        }
        else
        {
            SeekNewEnemy();
        }
    }

    void SeekNewEnemy()
    {
        //je cherche un new enemy
            Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, towerRange, enemyLayer);
            
        if(enemiesInRange.Length > 0)
        {
            enemy = enemiesInRange[0].gameObject;
        }


    }

    void Tire()
    {

        //je tire sur mon enemy
            if(Time.time >= timeToSpawn)//time.time = chronomètre
            {
                //fonction pour créer une balle
                currentBullet = Instantiate(bulletPreFab, boutCanon.transform.position, boutCanon.transform.rotation);

                currentBullet.GetComponent<bulletdamage>().enemy = enemy;

                timeToSpawn = Time.time + reloadTime ;
            }
    }









}
