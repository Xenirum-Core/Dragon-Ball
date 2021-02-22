using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health = 20f;
    public GameObject Healthbar;

    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;
    private Vector2 m_MovementVector;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    public void SetDamage(int value)
    {
        if (Health <= 0f)
        {
            Health = 0f;
        }
        else
        {
            Healthbar.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            Health -= value;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //m_MovementVector = new Vector2(0.5f, 0.5f);
        m_Rigidbody2D.velocity = m_MovementVector;
    }
}
