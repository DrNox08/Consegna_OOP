using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static Action OnGameOver;
    
    [SerializeField] Image baseHealthBar;
    [SerializeField] GameObject loseScreen;
    public void StartWave()
    {
        if (EnemyPooler.SharedInstance.AllEnemiesDisabled())
        {
            EnemyPooler.SharedInstance.IncreaseEnemiesToActivate();
            EnemyPooler.SharedInstance.ActivateEnemies();
        }
    }

    private void Start()
    {
        baseHealthBar.fillAmount = 1;
        loseScreen.SetActive(false);
    }

    private void OnEnable()
    {
        Base.OnEnemyAttack += DecreaseBaseHealthBar;
        OnGameOver += GameOver;
    }
    private void OnDisable()
    {
        Base.OnEnemyAttack -= DecreaseBaseHealthBar;
        OnGameOver -= GameOver;
    }

    void DecreaseBaseHealthBar()
    {
        float damageAmount = 1f/ 20f;
        baseHealthBar.fillAmount -= damageAmount;
    }

    void GameOver()
    {
        Time.timeScale = 0;
        loseScreen.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
        
}
