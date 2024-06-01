using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public void StartWave()
    {
        if (EnemyPooler.SharedInstance.AllEnemiesDisabled())
        {
            EnemyPooler.SharedInstance.IncreaseEnemiesToActivate();
            EnemyPooler.SharedInstance.ActivateEnemies();
        }
    }
}
