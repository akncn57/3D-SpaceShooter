using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLimit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Asteroid hit border limit.
        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
        }
    }
}
