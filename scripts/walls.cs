using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walls : MonoBehaviour
{
    float yPos;
    Vector2 target;
    bool moving = false;
    bool hard = false;
    public static bool moveCheck = false;   //to check if the wall is moving to ignore collision with bird
    public float speed;
    void Start()
    {
        speed = 20;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        moving = true;
        yPos = Random.Range((float)-8.4, (float)8.4);   //goes to a random position when colliding with the bird
        target = new Vector2(transform.position.x, yPos);   
    }
    // Update is called once per frame
    void Update()
    {
        if(moving == true)
        {
            moveCheck = true;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if((Vector2)transform.position == target)
            {
                moving = false;
                moveCheck = false;
            }
        }
    }
}
