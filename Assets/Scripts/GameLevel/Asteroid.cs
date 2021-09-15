using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject AsteroidDestroyEffect;
    public GameObject SpaceshipDestroyEffect;
    private Rigidbody rb;
    public float rotationSpeed = 2f;
    public float moveSpeed = -3f;

    private void Start()
    {
        // Rigidbody component.
        rb = GetComponent<Rigidbody>();

        // Asteroid move function.
        MoveAsteroid();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player hit asteroid.
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Instantiate(AsteroidDestroyEffect, transform.position, transform.rotation);
            Instantiate(SpaceshipDestroyEffect, transform.position, transform.rotation);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
        }

        // Bullet hit asteroid.
        if (other.CompareTag("Bullet"))
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().ExplosionAsteroid();
            Instantiate(AsteroidDestroyEffect, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void MoveAsteroid()
    {
        rb.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        rb.velocity = transform.forward * moveSpeed;
    }
}
