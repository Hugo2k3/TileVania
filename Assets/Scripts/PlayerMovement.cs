using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(0f, 18f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;
    public bool isAlive = true;
    public static PlayerMovement instance;
   // AudioPlay audioPlay;
    void Awake()
    {
        //audioPlay = FindObjectOfType<AudioPlay>();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
        SoundBouncing();

    }
    void SoundBouncing()
    {
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Bouncing")))
        {
            //audioPlay.PlayBouncing();
            AudioPlay.instance.PlayBouncing();
        }
    }

    void OnMove(InputValue value)
    {

        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();

    }

    void OnFire(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        Instantiate(bullet, gun.position, transform.rotation);
        //audioPlay.PlayShootingClip();
        AudioPlay.instance.PlayShootingClip();



    }

    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            //audioPlay.PlayJumping();
            AudioPlay.instance.PlayJumping();
        }
    }
    void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;

        }

        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;
        bool playerHasVeticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVeticalSpeed);



    }
    void Run()
    {

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        //Abs lay gia tri tuyet doi
        // Epsilon gia tri gan bang 0 nhung lon hon 0;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2((Mathf.Sign(myRigidbody.velocity.x)), 1f);
        }


        // Mathf.Sign lay thong tin cua rigit neu rigit.velo.x >1 tra ve 1 else tra ve -1


    }
    void Die()
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            myAnimator.SetTrigger("Dying");
            myRigidbody.velocity = deathKick;
            isAlive = false;
            //audioPlay.PlayDie();
            AudioPlay.instance.PlayDie();
            GameSession.instance.ProcessPlayerDeath();
            //FindObjectOfType<GameSession>().ProcessPlayerDeath();

        }

    }


}
