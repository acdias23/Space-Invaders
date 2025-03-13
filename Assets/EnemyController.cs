using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 5.0f;
    private float speed = -1.0f;

    private bool ShouldGoDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  

        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Math.Abs(speed)*waitTime){
            ChangeState();
            timer = 0.0f;
        }
    }

    void ChangeState(){
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
        
        if (ShouldGoDown) {
            rb2d.position = new Vector2(rb2d.position.x, rb2d.position.y - 1);
            speed *= 2;
        }
            
        ShouldGoDown = !ShouldGoDown;
        
    }

}

