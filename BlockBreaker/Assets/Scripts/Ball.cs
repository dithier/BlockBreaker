using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVeloc = 2f;
    [SerializeField] float yVeloc = 15f;
    [SerializeField] AudioClip[] ballSounds;

    // state
    Vector3 paddleToBallVector;
    bool hasStarted = false;

    // cached componenet references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        // if left mouse button clicked
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVeloc, yVeloc);
        }
    }

    private void LockBallToPaddle()
    {
        Vector3 paddlePos = new Vector3(paddle1.transform.position.x,
            paddle1.transform.position.y,
            paddle1.transform.position.z);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
        
    }
}
