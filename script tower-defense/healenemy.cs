using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healenemy : MonoBehaviour
{
    [SerializeField] public float health = 100f;
    // public float starthealth;
    [SerializeField] int goldEnemy = 30;
    //[SerializeField] SkinnedMsehRenderer renderer;
    [SerializeField] GameObject mortAnnimation;//affiche annimation mort
    
    public Image healthBarre;

    // Start is called before the first frame update
    void Start()
    {
        //health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            //gagner des golds
            GameManager.AddGold(goldEnemy);

            Instantiate(mortAnnimation, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        
    }

   public void DoDamage(float value)
   {
       health = health - value;
       // health -= 10;

    //    healthBarre.fillAmount = 

   }

   public void Regenheal(float value)
   {
        health = health + value;
   }
    
    


    int i;
    bool isPoisonned;
    public void DoPoisonDommage(float value)
    {
        if(!isPoisonned)
        {
            isPoisonned = true;
            StartCoroutine(Poison(value));
        }
        else
        {
            i =0;
        }
    }

    IEnumerator Poison(float damage)
    {
        //renderer.material.color = color.green;
        float duration = 5f;//durer
        int tickNumber = 10;//salve chaque tick enleve le nombre donner dans DoPoisonDamage
        for(i = 0; i < tickNumber; i++)
        {
            DoDamage(damage);
            yield return new WaitForSeconds(duration/tickNumber);
        }

        isPoisonned = false;
        //renderer.material.color = color.white;
    }


    private void OnDestroy()
    {
        EnemySpawner.instance.EnemyDied();
    }
}
