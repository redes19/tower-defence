using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiemovement : MonoBehaviour
{
    [SerializeField] public GameObject path;//empty qui contient tout les enfant empty
    [SerializeField] float MoveSpeed = 5f;

    [SerializeField] Vector3[] waypoints;//tableau


    int indexDestination;//quand j'ai atteint un point de passage l'index augment pour aller au suivant
    bool isInit;


    [SerializeField] float value = 500f; //check heal



    // Start is called before the first frame update
    void Start()
    {
        
    

    }

    // Update is called once per frame
    void Update()
    {
        if(!isInit)// !isinit = isinit == false//tant que je suis pas initialiser je fait pas l'update
        {
            return;

        }
        //transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, 10f * Time.deltaTime);
        //if(transform.position == pointB.transform.position){Destroy(gameObject);}
        //deplacement
        transform.position = Vector3.MoveTowards(transform.position, waypoints[indexDestination], MoveSpeed * Time.deltaTime);
        //rotation
        transform.LookAt(waypoints[indexDestination]);

        if(transform.position == waypoints[indexDestination])
        {

            if(indexDestination < waypoints.Length -1)
            {
                indexDestination++;// je vais a la prochaine position
            }   
            else //si je suis arrivé a la fin
            {
                //s'il arrive a la fin enemy enlève points de vie au joueur
                GameManager.LooseHP(5);


                Destroy(gameObject);
            }

            if(transform.position.x == -21 && transform.position.y == 1.5 && transform.position.z == 4.5) //position du waitpoint3 pour la regen
            {
                GetComponent<healenemy>().Regenheal(value);
            }
        }

    }

    public void Init()
    {
        //transform.position = pointA.transform.position;
        //Créer un tableau avec un nbr d'élément identique au nbr d'enfant de mon path
        waypoints = new Vector3[path.transform.childCount];

        //waypoints[0] = path.transform.GetChild(0).position;
        // je rentre toutes les Position de mes waypoints dans mon tableau
        //boucle for pour repeter un certain nbr de fois un mvt
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = path.transform.GetChild(i).position;
        }
        transform.position = waypoints[0];
        indexDestination = 1;

        isInit = true;
    }
}
