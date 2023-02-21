using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public static bool gameFinish = false;
    public GameObject statutLoose;
    public GameObject statutWin;
    public GameObject gameUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W ))//|| gameFinish
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
    }

    // public void Recommencer()
    // {
    //     SceneManager.LoadScene(this);
    // }

}
