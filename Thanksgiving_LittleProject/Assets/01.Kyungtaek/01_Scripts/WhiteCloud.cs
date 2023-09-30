using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCloud : MonoBehaviour
{
    const int SPEED = 5;

    void Update()
    {
        float screenX = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10.0f;

        if (transform.position.x < screenX)
        {
            Destroy(gameObject);
        }

        transform.position += Vector3.left * Time.deltaTime * SPEED;
    }
}
