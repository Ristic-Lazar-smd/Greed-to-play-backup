using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    DamageableCharacter damageableCharacter;
    Rigidbody2D body;
    Animator animator;

    float horizontal;
    float vertical;
    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Position clamp
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.593f, 5.05f);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8.578f, 8.622f);
        transform.position = clampedPosition;
       
        animator.SetFloat("dirX", body.velocity.normalized.x);
        animator.SetFloat("dirY", body.velocity.normalized.y);
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed).normalized*runSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bouncy_script bc = collision.gameObject.GetComponent<bouncy_script>();
        damageableCharacter.OnPlayerHit(bc.damage);
    }
 


}
