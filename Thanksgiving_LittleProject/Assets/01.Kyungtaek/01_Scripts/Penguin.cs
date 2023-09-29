using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    Rigidbody2D penguinRB;


    // Start is called before the first frame update
    void Start()
    {
        penguinRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //터치할 경우
        {
            penguinRB.velocity = Vector2.up * 10;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
