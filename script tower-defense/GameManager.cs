using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int startGold = 100;
    [SerializeField] int startHealth = 50;
    [SerializeField] GameObject goldText;
    [SerializeField] GameObject HpText;
    static public int gold;
////////////////////////////////////////////////////////
    TextMeshProUGUI txt;
    public static int playerHealth;
//////////////////////////////////////////////////////////////
    TextMeshProUGUI gpldUI;
    TextMeshProUGUI healthUI;
//////////////////////////////////////////////////////////
    public static bool gameFinish = false;
    public GameObject statutLoose;
    public GameObject statutWin;


    // Start is called before the first frame update
    void Start()
    {
        gold = startGold;
        playerHealth = startHealth;
        txt = goldText.GetComponent<TextMeshProUGUI>();

    gpldUI = goldText.GetComponent<TextMeshProUGUI>();
    healthUI = HpText.GetComponent<TextMeshProUGUI>();

    turretToBuild = turretBasicPrefab; //donne la turret standard au tout début
    
    Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Gold : " + gold.ToString();
        healthUI.text = "Health : " + playerHealth.ToString();

        if(Input.GetKeyDown(KeyCode.W))//|| gameFinish
        {
           //visible = !visible;
           Time.timeScale = 0f;
           Win();
           //Debug.Log("Ta gagner");

           
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
           //visible = !visible;
           Time.timeScale = 0f;
           Loose();
           //Debug.Log("Ta perdu");
           
        }

        if(statutLoose)
        {
            return;
        }
        if(playerHealth <= 0)
        {
            Loose();
        }

        //  if(statutLoose)
        // {
        //     return;
        // }
        // if(gameObject.GetComponent<EnemySpawner>().waveIndex > gameObject.GetComponent<EnemySpawner>().waves.Lenght)
        // {
        //     Win();
        // }



    }

    public static void AddGold(int value)
    {
        gold += value;
        
        
    }

    public static void LooseHP (int value)
    {
        playerHealth -= value;
        
    }

    public static GameManager instance; //stoc GameManager

    GameObject turretToBuild; //variable permet de contenir la turret choisit

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("il y a deja un GameManager in scene");
            return;
        }
        instance = this;
    }

    
    public GameObject turretBasicPrefab;
    public GameObject turretSnakePrefab;
    public GameObject turretRangePrefab;


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public void ToggleFast()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 4;
        }
        else
            Time.timeScale = 1;
    }




    public void Win()
    {
        statutWin.SetActive(true);
        gameFinish = true;
        Debug.Log("winnerrrrr");
    }

    public void Loose()
    {
        statutLoose.SetActive(true);
        gameFinish = true;
        Debug.Log("Loooserrrrrrrrrr");
    }

    // public void Restart()
    // {
    //     SceneManager.LoadScene("tower-defence");
    // }
}
