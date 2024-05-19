using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject prefabMoneda;
    public float tiempoDestruccion = 0f;
    public float fireRate = 2f;
    public GameObject bulletPrefab;
    private float nextFireTime = 0f;

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        // Instancia una bala en la posición del enemigo
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            JugadorImpactado(otro.GetComponent<MovimientoPlayer>());
        }
        else if (otro.CompareTag("Bala Player"))
        {
            BalaImpactada(otro.gameObject);
        }
    }
    void JugadorImpactado(MovimientoPlayer jugador)
    {
        DestruirEnemigo();
    }
    void BalaImpactada(GameObject bala)
    {
        Destroy(bala);
        SoltarMonedas();
        DestruirEnemigo();
    }
    void SoltarMonedas()
    {
        if (prefabMoneda != null)
        {
            Instantiate(prefabMoneda, transform.position, Quaternion.identity);
        }
    }
    void DestruirEnemigo()
    {
        Destroy(gameObject, tiempoDestruccion);
    }
}
