using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody2D;
    


    void Start()
    {
        myRigidbody2D =GetComponent<Rigidbody2D>(); 
    }
    void Update()
    {
        Move();
       
    }
    void Move()
    {
        if(transform.localScale.x > 0)
        {
           myRigidbody2D.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            myRigidbody2D.velocity = new Vector2(-moveSpeed, 0);
        }

    }
     void OnTriggerExit2D(Collider2D collision)
    {
        
        FlipEnemyFacing();
    }
 
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody2D.velocity.x)), 1f);
    }
}
