using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    //public GameObject panel;
    //bool visible = false;
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //visible = !visible;
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
            //panel.SetActive(visible);
        }
    }

    void Paused()
    {
        //activer le menu pause
        pauseMenuUi.SetActive(true);

        //arreter le temps
        Time.timeScale = 0f;

        //changer le statu du jeu
        gameIsPaused = true;
    }

    public void Resume()
    {
        //desactiver le menu pause
        pauseMenuUi.SetActive(false);

        //remettre le temps
        Time.timeScale = 1f;

        //changer le statu du jeu
        gameIsPaused = false;
    }


    public void Play()
    {
        //if(PauseMenu.gameIsPaused);//pause sound
    }

    public void LoadMenu()
    {
        //Time.timeScale = 1f;//code si on a une interface qui bouge
        SceneManager.LoadScene("interface");//code pour changer de scene 
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
