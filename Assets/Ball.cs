using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    public bool dropped = false;
    Vector2 moveDirection = Vector2.right;
    public Rigidbody2D rb;

    private GameObject borderLeft;
    private GameObject borderRight;


    private bool firstCollision = true;
    // Start is called before the first frame update
    void Start()
    {
        int rand = (new System.Random()).Next(0, 4);
        GetComponent<Image>().sprite = GameManager.instance.ballSprites[rand];

        rb = GetComponent<Rigidbody2D>();
        borderLeft = GameObject.FindGameObjectWithTag("border_left");
        borderRight = GameObject.FindGameObjectWithTag("border_right");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            dropped = true;
            rb.velocity = new Vector2(0f, -0.01f);
            rb.gravityScale = 0.5f;
        }


        if (!dropped)
            transform.Translate(moveDirection * Time.deltaTime * 2);


        checkBorderReached();


    }

    private void checkBorderReached()
    {
        if(transform.position.x <= borderLeft.transform.position.x)
        {
//            moveDirection = moveDirection * -1;
            moveDirection = Vector2.right;

        }
        else if (transform.position.x >= borderRight.transform.position.x)
        {
  //          moveDirection = moveDirection * -1;
            moveDirection = Vector2.left;

        }

    }


    /*    private void OnCollisionEnter2D(Collision2D collision)
        {
            
            if (collision.collider.CompareTag("border"))
            {
                
                moveDirection = moveDirection * -1;
            }
        }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (firstCollision && Helper.isVibrationON() && !collision.gameObject.CompareTag("cleaner_trap"))
        {
            Handheld.Vibrate();
            firstCollision = false;
        }
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {

    }*/
}
