using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingType : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Being being;
    public float speed = 10f;
    [HideInInspector] public Vector2 direction;
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        direction = Vector2.zero;
        rb = gameObject.GetComponent<Rigidbody2D>();
        being = gameObject.GetComponent<Being>();
    }
    public virtual void Update()
    {

        animator.SetFloat("xSpeed", direction.x);
        animator.SetFloat("ySpeed", direction.y);
    }
}
