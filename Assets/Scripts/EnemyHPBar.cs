using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public Image fillBar;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        fillBar.fillAmount = 1;
    }

    private void OnEnable()
    {
        fillBar.fillAmount = 1;
    }


    private void LateUpdate()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform);
            
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 180f, 0f);
        }
    }

    public void DecreaseHealthBar(int hp)
    {
        float amountToDecrease = 1f / hp;
        fillBar.fillAmount -= amountToDecrease;
    }
            
}
