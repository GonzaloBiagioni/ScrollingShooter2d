using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasHPJefe : MonoBehaviour
{
    public GameObject heartPrefab;
    public Jefe boss;
    public Transform heartContainer;

    private Image[] hearts;

    void Start()
    {
        hearts = new Image[boss.maxHealth];
        for (int i = 0; i < boss.maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartContainer);
            hearts[i] = heart.GetComponent<Image>();
        }
    }

    void Update()
    {
       
        if (Vector3.Distance(boss.transform.position, boss.player.position) <= boss.detectionRange)
        {
            heartContainer.gameObject.SetActive(true);
        }
        else
        {
            heartContainer.gameObject.SetActive(false);
        }
    }

    public void UpdateHealthBar(int currentHealth)
    {
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true; 
            }
            else
            {
                hearts[i].enabled = false; 
            }
        }
    }
}