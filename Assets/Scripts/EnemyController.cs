
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health = 20f;
    public float Speed = 1f;

    private Animator m_Animator;
    private GameObject m_PlayerController;
    private GameObject m_Player;

    private float m_Cooldown = 1f;
    private float m_PlayerDistance;
    private bool IsDie = false;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_PlayerController = GameObject.FindGameObjectWithTag("MainCamera");
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
            m_PlayerController.SendMessage("AddRage");
            Destroy(gameObject, m_Animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    void FixedUpdate()
    {
        if (Health <= 0f)
            return;

        m_PlayerDistance = Vector2.Distance(transform.position, m_Player.transform.position);

        if (m_PlayerDistance > 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Player.transform.position, Speed * Time.fixedDeltaTime);
        }

        if (m_PlayerDistance <= 1.2f)
        {
            m_Cooldown -= Time.deltaTime;
            if (m_Cooldown <= 0f)
            {
                m_PlayerController.SendMessage("SetDamage", 40f);
                m_Animator.Play("enemy_creep_attack");
                m_Cooldown = 1f;
            }
        }
    }
}
