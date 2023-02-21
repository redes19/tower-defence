using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdamage : MonoBehaviour
{
    [SerializeField] public GameObject enemy;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Vector3 lastPosEnemy;
    [SerializeField] LayerMask LayerEnemy;
    [SerializeField] int degatBullet = 10;
    [SerializeField] float range = 0f;
    [SerializeField] int poisonDamage = 5; 


    public enum BulletMode
    {
        STANTARD,
        EXPLOSION,
        POISON,
    }

    [SerializeField] BulletMode bulletMode;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si enemy non nul
        if(enemy != null)
        {
            lastPosEnemy = enemy.transform.position;
        }
            // mouvement
            transform.position = Vector3.MoveTowards(transform.position, lastPosEnemy, moveSpeed * Time.deltaTime);

            //balle detruite a destination
            if(transform.position == lastPosEnemy)
            {
                if(enemy != null)
                {
                    if(range == 0)//si je ne fait pas des dégats de zones
                    {
                    //balle inflige degats
                    enemy.GetComponent<healenemy>().DoDamage(degatBullet);
                    }
                    if(bulletMode == BulletMode.POISON)
                    {
                        enemy.GetComponent<healenemy>().DoPoisonDommage(poisonDamage);
                    }
                }   



                 if(bulletMode == BulletMode.EXPLOSION)
                {
                    Collider[] enemies = Physics.OverlapSphere(transform.position, range,LayerEnemy);
                    for(int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<healenemy>().DoDamage(degatBullet);
                    }
                }




                //balle détruite
                Destroy(gameObject);
            }
        
        
        
    }



}