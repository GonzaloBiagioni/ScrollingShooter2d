using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jefe : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float tiempoDestruccion = 0f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public int maxHealth = 10;
    public float detectionRange = 10f;
    public Transform player;
    public CanvasHPJefe bossHealthBar;
    private int currentHealth;
    private bool isActive = false;
    private float nextFireTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        bossHealthBar.UpdateHealthBar(currentHealth);
    }

    void Update()
    {
        if (isActive)
        {            
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); 
            
            if (Time.time > nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) <= detectionRange)
            {
                isActive = true;
            }
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            isActive = true;
        }

        else if (otro.CompareTag("Bala Player"))
        {
            TakeDamage(1);
            Destroy(otro.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        bossHealthBar.UpdateHealthBar(currentHealth);
        if (currentHealth <= 0)
        {
            DestruirEnemigo();
        }
    }

    void DestruirEnemigo()
    {
        Destroy(gameObject, tiempoDestruccion);
        SceneManager.LoadScene(2);
    }
}