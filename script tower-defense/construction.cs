using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class construction : MonoBehaviour
{
    [SerializeField] bool isEmpty = true;
    public GameObject tourellePreFab;
    
    [SerializeField] public GameObject turret; //variable qui contitent la turret
    GameManager gameManager;

    [SerializeField] public int prixGold = 50;
    

    


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMouseDown()
    {

        

        if(gameManager.GetTurretToBuild() == null)
        {
            return;
        }


        if(turret != null) //construction turret
        {
            Debug.Log("impossible de construire");
            return;   
        }       

        if(isEmpty == true) //apparition turret
        {
            
            //Instantiate(turret, 
            //transform.position + new Vector3(0,1f,0),//surélève la tour
            //transform.rotation);
            //isEmpty = false;

            GameObject turretToBuild = gameManager.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + new Vector3(0,1f,0), transform.rotation);


            int turretCost = turret.GetComponent<tourelle>().prixTurretB;
            if(GameManager.gold >= turretCost)
            {
                GameManager.AddGold(-turretCost);
            }  

            if(GameManager.gold < 50)
            {
                Debug.Log("Tu n'a plus d'argent");
            }
        }

        
    }

    

    private Color startcolor;
     void OnMouseEnter()
     {
         startcolor = GetComponent<Renderer>().material.color;
         GetComponent<Renderer>().material.color = Color.grey;
     }
     void OnMouseExit()
     {
         GetComponent<Renderer>().material.color = startcolor;
     }




}
