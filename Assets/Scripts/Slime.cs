using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Animator animator;
    Transform target;
    public float minAttackDelay = 1, maxAttackDelay = 3;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
        Invoke("Attack", Random.Range(minAttackDelay, maxAttackDelay));
    }

    public float speed;
    private void FixedUpdate()
    {
        transform.Translate((target.position - transform.position).normalized * speed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Invoke("Attack", Random.Range(minAttackDelay, maxAttackDelay));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerSword")
        {
            animator.SetTrigger("Die");
            this.enabled = false;
        }
    }
}
