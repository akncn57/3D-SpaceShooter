using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    private Rigidbody rb;
    private float dirX;
    private float speed = 30f;
    private float horizontalMove;
    public GameObject bullet;
    public Transform muzzlePoint;
    private float coolDown;
    public AudioClip shotSound;

    private void Start()
    {
        // Spaceship Rigidbody component.
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // X possition values.
        horizontalMove = Input.acceleration.x;

        // Move function.
        Move();

        // Shoot function.
        Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BorderLimit"))
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
        }
    }

    private void Move()
    {
        
        rb.AddForce(new Vector3(horizontalMove, 0, 0) * speed);
    }

    private void Shoot()
    {
        // Cooldown
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        // Fire
        if (Input.GetMouseButtonDown(0) && coolDown <= 0)
        {
            // Shoot laser sound.
            this.GetComponent<AudioSource>().PlayOneShot(shotSound);

            // Create Bullet
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, 0));

            // Set Cooldown
            coolDown = 0.10f;
        }
    }
}
