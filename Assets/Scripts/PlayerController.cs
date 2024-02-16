using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    Vector2 moveValue;
    bool isMovingOnY = false;
    bool canMove = true;
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
            Debug.Log(moveValue);

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
                animator.SetTrigger("Attack");
                canMove = false;
            }

        }
    }

    private void LateUpdate()
    {
        if (!canMove)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
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
}
