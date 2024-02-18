using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction walkAction;

    private void OnEnable()
    {
        walkAction.Enable();
    }

    private void OnDisable()
    {
        walkAction.Disable();
    }

    Animator animator;
    SpriteRenderer spriteRenderer;
    PlayerInfo playerInfo;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerInfo = GetComponent<PlayerInfo>();
    }

    Vector2 moveValue;
    bool isMovingOnY = false;
    bool canMove = true;
    bool isLeft;

    public bool isTransitioning;
    public int transitionValue = 1;
    [SerializeField] Image transitionImage;


    int health = 6;

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            moveValue = walkAction.ReadValue<Vector2>();

            if (moveValue.y != 0)
            {
                if (!isMovingOnY)
                {
                    isMovingOnY = true;
                }
            }
            else
            {
                isMovingOnY = false;
            }

            if (isMovingOnY)
            {
                moveValue = new Vector2(0, moveValue.y);
            }
            else if (moveValue.x != 0)
            {
                moveValue = new Vector2(moveValue.x, 0);
            }

            moveValue.Normalize();

            animator.SetInteger("xSpeed", (int)moveValue.x);
            animator.SetInteger("ySpeed", (int)moveValue.y);

            if (moveValue.x < 0)
            {
                if (!spriteRenderer.flipX)
                {
                    spriteRenderer.flipX = true;
                }
            }
            else if (moveValue.x > 0)
            {
                if (spriteRenderer.flipX)
                {
                    spriteRenderer.flipX = false;
                }
            }

            //Check for attack
            if (Input.GetMouseButtonDown(0))
            {
                isLeft = spriteRenderer.flipX;
                if(isLeft)
                {
                    spriteRenderer.flipX = false;
                }
                animator.SetBool("isLeft", isLeft);
                animator.SetTrigger("Attack");
                canMove = false;
            }

        }

        if(isTransitioning)
        {
            transitionImage.fillAmount += Time.deltaTime * transitionValue;
            if(transitionImage.fillAmount >= 1)
            {
                isTransitioning = false;
            }
            else if (transitionImage.fillAmount <= 0)
            {
                isTransitioning = false;
                canMove = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (!canMove && !isTransitioning)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                spriteRenderer.flipX = isLeft;
                canMove = true;
            }
        }
    }

    public float moveSpeed = 1;
    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.Translate(moveValue * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void StartTransition()
    {
        canMove = false;
        moveValue = Vector2.zero;
        animator.SetInteger("xSpeed", (int)moveValue.x);
        animator.SetInteger("ySpeed", (int)moveValue.y);
        isTransitioning = true;
        transitionValue = 1;
    }

    public void EndTransition()
    {
        canMove = false;
        moveValue = Vector2.zero;
        animator.SetInteger("xSpeed", (int)moveValue.x);
        animator.SetInteger("ySpeed", (int)moveValue.y);
        isTransitioning = true;
        transitionValue = -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SlimeHitBox")
        {
            health--;
            playerInfo.DamagePlayer(1);
        }
    }
}
