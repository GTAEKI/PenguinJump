using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCloud : MonoBehaviour
{
    const int SPEED = 6;
    float screenX;

    private void Start()
    {        
        screenX = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10.0f;
    }

    void Update()
    {

        if (transform.position.x < screenX)
        {
            Destroy(gameObject);
        }

        transform.position += Vector3.left * Time.deltaTime * SPEED;
    }
}
