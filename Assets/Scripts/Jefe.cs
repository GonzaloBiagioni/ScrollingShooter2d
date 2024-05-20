using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jefe : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float detectionRange = 10f;
    public int maxHealth = 10;
    private int currentHealth;
    private bool isActive = false;
    private float nextFireTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;        
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
        }

        if (other.CompareTag("Bala Player"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(2);
    }
}