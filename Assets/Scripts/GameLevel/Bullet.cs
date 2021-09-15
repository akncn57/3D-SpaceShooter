using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;

    private void Update()
    {
        // Bullet move function.
        BulletMove();
    }

    private void BulletMove()
    {
        transform.Translate(Vector3.up * -1 * Time.deltaTime * speed);
    }
}
