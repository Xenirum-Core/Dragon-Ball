using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2f;
    public GameObject PrimaryAttack;
    public GameObject UltimateAttack;
    public GameObject SpawnPosition;

    SpriteRenderer m_SpriteRenderer;
    Rigidbody2D m_RigidBody2D;
    Animator m_Animator;
    bool m_FacingRight = true;

    private float m_HorizontalAxis;
    private float m_VerticalAxis;

    Vector2 movementVector;

    void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void SpawnBullet(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, SpawnPosition.transform.position, transform.rotation);
    }

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        m_HorizontalAxis = Input.GetAxisRaw("Horizontal");
        m_VerticalAxis = Input.GetAxisRaw("Vertical");

        if (movementVector.x == 0 && movementVector.y == 0)
        {
            m_Animator.Play("Idle");
        }

        if (movementVector.x != 0 || movementVector.y != 0)
        {
            m_Animator.Play("Walk");
        }

        if (m_HorizontalAxis > 0 && !m_FacingRight) Flip();
        if (m_HorizontalAxis < 0 && m_FacingRight) Flip();
        
        if (Input.GetButtonDown("Fire"))
        {
            SpawnBullet(PrimaryAttack);
        }

        if (Input.GetButtonDown("Ultimate"))
        {
            SpawnBullet(UltimateAttack);
        }
    }

    void FixedUpdate()
    {
        movementVector = new Vector2(m_HorizontalAxis, m_VerticalAxis) * Speed * Time.fixedDeltaTime;
        m_RigidBody2D.velocity = movementVector;
    }
}
