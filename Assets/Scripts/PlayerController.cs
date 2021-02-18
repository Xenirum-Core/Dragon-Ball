// TODO: Implement die animation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera PlayerCamera;
    public GameObject PlayerSkin;
    public GameObject SpawnPosition;
    public GameObject PrimaryAttack;
    public GameObject UltimateAttack;
    
    public float PlayerHealth = 100f;
    public float PlayerSpeed = 80f;

    Rigidbody2D m_RigidBody2D;
    Animator m_Animator;
    bool m_FacingRight = true;

    private float m_HorizontalAxis;
    private float m_VerticalAxis;

    Vector2 MovementVector;

    void Die()
    {
        PlayerSkin.SetActive(false);
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;
        PlayerSkin.transform.Rotate(0f, 180f, 0f);
    }

    void SpawnBullet(GameObject BulletPrefab)
    {
        Instantiate(BulletPrefab, SpawnPosition.transform.position, SpawnPosition.transform.rotation);
    }

    public void PlayerDamage(float damageValue)
    {
        PlayerHealth -= damageValue;
    }

    void Start()
    {
        m_RigidBody2D = PlayerSkin.GetComponent<Rigidbody2D>();
        m_Animator = PlayerSkin.GetComponent<Animator>();
    }

    void Update()
    {
        m_HorizontalAxis = Input.GetAxisRaw("Horizontal");
        m_VerticalAxis = Input.GetAxisRaw("Vertical");

       if (MovementVector.x == 0 && MovementVector.y == 0)
        {
            m_Animator.Play("Idle");
        }

        if (MovementVector.x != 0 || MovementVector.y != 0)
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

        if (PlayerHealth <= 0f)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        MovementVector = new Vector2(m_HorizontalAxis, m_VerticalAxis) * PlayerSpeed * Time.fixedDeltaTime;
        m_RigidBody2D.velocity = MovementVector;
    }
}
