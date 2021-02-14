using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2f;

    private SpriteRenderer m_SpriteRenderer;
    private Rigidbody2D m_RigidBody2D;

    private float m_HorizontalAxis;
    private float m_VerticalAxis;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_HorizontalAxis = Input.GetAxisRaw("Horizontal");
        m_VerticalAxis = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (m_RigidBody2D.velocity.x < 0)
        {
            m_SpriteRenderer.flipX = true;
        }
        else if (m_RigidBody2D.velocity.x > 0)
        {
            m_SpriteRenderer.flipX = false;
        }

        m_RigidBody2D.velocity = new Vector2(m_HorizontalAxis * Speed, m_VerticalAxis * Speed);
    }
}
