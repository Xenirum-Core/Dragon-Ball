using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health = 20f;
    public float Speed = 1f;
    public AudioClip[] MeleeAttack; 

    private Animator m_Animator;
    private GameObject m_PlayerController;
    private GameObject m_Player;
    private AudioSource m_AudioSource;
    private Rigidbody2D m_Rigidbody2D;

    private float m_MeleeCooldown = 1f;
    private float m_PlayerDistance;
    private bool IsDie = false;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_PlayerController = GameObject.FindGameObjectWithTag("MainCamera");
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_AudioSource = GetComponent<AudioSource>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public IEnumerator SetDamage(int value)
    {
        Health -= value;
        m_Animator.Play("enemy_creep_hurt");
        yield return null;
    }

    private IEnumerator Die()
    {
        m_Animator.Play("enemy_creep_die");
        m_PlayerController.SendMessage("AddRage");
        m_PlayerController.SendMessage("AddScore", 10);
        IsDie = true;

        Destroy(gameObject, m_Animator.GetCurrentAnimatorStateInfo(0).length);
        yield return null;
    }

    public IEnumerator Attack()
    {
        m_MeleeCooldown -= Time.deltaTime;
        if (m_MeleeCooldown <= 0f)
        {
            m_PlayerController.SendMessage("SetHealth", Random.Range(10, 20));
            m_Animator.Play("enemy_creep_attack");
            m_AudioSource.clip = MeleeAttack[Random.Range(0, MeleeAttack.Length)];
            m_AudioSource.Play();
            m_MeleeCooldown = 1f;
        }

        yield return null;
    }

    private void Update()
    {
        m_PlayerDistance = Vector2.Distance(transform.position, m_Player.transform.position);

        if (Health <= 0f && !IsDie)
        {
            StartCoroutine("Die");
        }
    }

    private void FixedUpdate()
    {
        if (m_PlayerDistance > 1.5f)
        {
            m_Animator.SetBool("IsMove", true);
            transform.position = Vector2.MoveTowards(transform.position, m_Player.transform.position, Speed * Time.fixedDeltaTime);
        }
        else
        {
            m_Animator.SetBool("IsMove", false);
            StartCoroutine("Attack");
        }
    }
}
