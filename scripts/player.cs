using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    bool start;
    public Rigidbody2D pb;
    int xVelocity = 3;
    int direction = 1;
    double rotate = 0;
    bool up = false;
    bool end = false;
    public score sco;
    public static string hole = "";
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        pb = GetComponent<Rigidbody2D>();
        FindObjectOfType<score>().begin();
        pb.gravityScale = 0;

    }

    //when the ball bounces
    private void OnTriggerEnter2D(Collider2D other) 
    {
       if (other.gameObject.tag == "death")
       {
           end = true;
            hole = "This isn't Italian Plumber game, Try Again";
       }
        if (end == false)
        {
            direction *= -1;        //changes direction upon hitting the paddle
            if (xVelocity <= 7)
            {
                xVelocity += 1;    //increases the speed of the ball everytime it hits paddle
            }
            gameObject.transform.localScale = new Vector3(direction, 1, 1);
            FindObjectOfType<score>().addPoint();            //increase score

            rotate = -50;
            transform.rotation = Quaternion.Euler(0, 0, (float)rotate);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //waits until the player touches the screen before starting
        if (start == true)
        {
            //left
            if(direction == -1)
            {
                if (rotate <= 55)
                {
                    Debug.Log("Rotating downards 55");
                    rotate += 1;
                    transform.rotation = Quaternion.Euler(0, 0, (float)rotate);
                }
            }
            else if (rotate >= -55) 
            {
                Debug.Log("Rotating downards -55");
                rotate -= 1;
                transform.rotation = Quaternion.Euler(0, 0, (float)rotate);
            }
            if(up == true)
            {
                if (direction == -1)
                {
                    rotate = -90;
                    transform.rotation = Quaternion.Euler(0, 0, (float)rotate);
                    up = false;
                }
                else
                {
                    rotate = 90;
                    transform.rotation = Quaternion.Euler(0, 0, (float)rotate);
                    up = false;
                }
            }

            pb.velocity = new Vector2(xVelocity * direction, pb.velocity.y);

            if (Input.GetMouseButtonDown(0))
            {
                up = true;
                pb.velocity = new Vector2(xVelocity, 12);
            }
        }

        //if the ball hits one of the edges
        if(pb.position.x >= 5 || pb.position.x <= -5 || pb.position.y >= 9.5 || pb.position.y <= -9.5 || end == true)
        {
            start = false;
            xVelocity = 0;
            pb.velocity = new Vector2(xVelocity, 0);
            pb.gravityScale = 0;
            end = false;
            //FindObjectOfType<gameManager>().endGame();
            SceneManager.LoadScene("end");
        }

        //does nothing until the user clicks once
        if (Input.GetMouseButtonDown(0) && start == false)
        {
            hole = "";
            FindObjectOfType<score>().show();
            start = true;
            pb.gravityScale = 3;

        }
    }
}
