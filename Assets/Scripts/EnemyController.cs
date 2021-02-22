using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health = 20f;
    public float Speed = 1f;

    private Animator m_Animator;
    private GameObject m_Player;

    private Vector2 m_MovementVector;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetDamage(int value)
    {
        Health -= value;
    }

    void Update()
    {
        if (Health <= 0)
        {
            m_Animator.Play("enemy_creep_die");
            Destroy(gameObject, m_Animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, m_Player.transform.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Player.transform.position, Speed * Time.fixedDeltaTime);
        }
    }
}
