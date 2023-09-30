using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    Rigidbody2D penguinRB;
    Animator penguinAnimator;
    private bool isJump;

    public AudioClip jumpSound;
    public AudioClip eatBlackCloudSound;
    public AudioClip eatWhiteCloudSound;
    public AudioClip onGroundSound;

    void Start()
    {
        penguinRB = GetComponent<Rigidbody2D>();
        penguinAnimator = GetComponent<Animator>();
        GameManager.GameStartEvent += resetPosition;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //터치할 경우
        {
            if (GameManager.instance.isGameStart)
            {
                isJump = true;
                penguinRB.velocity = Vector2.up * 6;
                penguinAnimator.SetTrigger("Jump");

                AudioManager.instance.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "WhiteCloud")
        {
            GameManager.instance.score += 1;
            Destroy(collision.gameObject);

            AudioManager.instance.PlayOneShot(eatWhiteCloudSound);
        }
        else if(collision.transform.tag == "BlackCloud")
        {
            GameManager.instance.GameOver();

            AudioManager.instance.PlayOneShot(eatBlackCloudSound);
        }
        else if(collision.transform.tag == "Ground" && isJump)
        {
            isJump = false;
            penguinAnimator.SetTrigger("OnGround");

            AudioManager.instance.PlayOneShot(onGroundSound);
        }
    }

    private void resetPosition()
    {
        transform.position = new Vector2(-2f, -4);
        isJump = false;        
    }
}
