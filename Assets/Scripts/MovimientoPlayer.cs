using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject bala;
    public Transform firepoint;
    public float fireRate = 15f;
    private float nextFireTime = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical).normalized;

        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            AudioManager.Instance.PlaySFX(0);
            Shoot();
            nextFireTime = Time.time + 2f / fireRate;
        }
    }
    private void Shoot()
    {
        Instantiate(bala, firepoint.position, firepoint.rotation);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
