using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HudScripts : MonoBehaviour
{
    #region  in game variables
    public TextMeshProUGUI mAmmoText; // texto de la municion en cargador
    public TextMeshProUGUI tAmmoText; // texto de la municion total 
    public TextMeshProUGUI nLifeText; // text of number of life
    public Image dLife; // draw of life
    public Personaje5 punt; // puntero de script
    public bool cLife = false; // count life 
    public bool cAmmo = false; // count ammo
    float maxLife = 100f;  // max life of player
    float life = 0; // life of player
    string sLife; // string of life
    int mAmmo; // municion en cargador
    string SmAmmo; // string de municion en cargador
    int tAmmo; // municion total
    string StAmmo; // string de municion total
    #endregion
    bool isPause = false;
    public GameObject pauseMenu;
    public GameObject playerHUD;
    
    void Start() 
    {
        Time.timeScale = 1;
        LifeNumber();
        BulletsNumber();    
    }

    void Update() 
    {
        if(cLife == true)
        {
            LifeNumber();    
        }
        if(cAmmo == true)
        {
            BulletsNumber();    
        }
        TogglePause();
    }

    void LifeNumber()
    {
        life = punt.life;
        sLife = life.ToString();
        nLifeText.text = sLife;
        dLife.fillAmount = life / maxLife;
        cLife = false;
    }

    void BulletsNumber()
    {
            mAmmo = punt.mAmmo;
            SmAmmo = mAmmo.ToString();
            mAmmoText.text = SmAmmo;

            tAmmo = punt.tAmmo;
            StAmmo = tAmmo.ToString();
            tAmmoText.text = StAmmo;

            cAmmo = false;
    }

    void TogglePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause == true)
            {
                ResumeGame();
            }else
            {
                PauseGame();
            }
        }
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playerHUD.SetActive(true);
        isPause = false;
        Time.timeScale = 1;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        playerHUD.SetActive(false);
        isPause = true;
        Time.timeScale = 0;
    }

    public void salir()
    {
        SceneManager.LoadScene(0);
    }
}
