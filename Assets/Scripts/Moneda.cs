using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int value;
    void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.CompareTag("Player"))
        {
            Destroy(gameObject);
            MonedaContador.Instance.IncreaseCoin(value);
        }
    }
}
