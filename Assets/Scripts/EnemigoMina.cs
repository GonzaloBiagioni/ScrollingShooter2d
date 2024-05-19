using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMina : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public GameObject prefabMoneda;
    public float tiempoDestruccion = 0f;
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
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
