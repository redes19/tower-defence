using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private GameManager gameManager;//relie ce script au gameManager


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void AchatTurret()
    {
        Debug.Log("Turret classique choisit");
        gameManager.SelectTurretToBuild(gameManager.turretBasicPrefab);//dis au gameManager qu'on choisis la tourelle basic au spawn

        
    }


    public void AchatTurretSnake()
    {
        Debug.Log("Turret dégat poison choisi");
        gameManager.SelectTurretToBuild(gameManager.turretSnakePrefab);
    }

    public void AchatTurretRange()
    {
        Debug.Log("Turret dégat zone choisi");
        gameManager.SelectTurretToBuild(gameManager.turretRangePrefab);
    }


}
