using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera PlayerCamera;
    public GameObject PlayerSkin;
    public GameObject ProjectileSpawnPoint;
    public GameObject PrimaryAttack;
    public GameObject UltimateAttack;
    
    public float Health = 100f;
    public float Speed = 80f;
    public float FollowCameraSmooth = 2f;
    public int RagePoints = 0;

    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;
    
    private bool m_FacingRight = true;
    private float m_HorizontalAxis;
    private float m_VerticalAxis;

    private Vector2 m_MovementVector;

    // Spawn projectile owned by player
    void SpawnBullet(GameObject ProjectilePrefab)
    {
        m_Animator.Play("player_attack");
        Instantiate(ProjectilePrefab, ProjectileSpawnPoint.transform.position, ProjectileSpawnPoint.transform.rotation);
    }

    void UltimateAbuse()
    {
        if (RagePoints >= 10)
        {
            SpawnBullet(UltimateAttack);
            RagePoints -= 10;
        }
    }

    public void SetDamage(int value)
    {
        if (Health <= 0)
        {
            Health = 0f;
        }
        else
        {
            Health -= value;
        }
    }

    void Start()
    {
        m_Rigidbody2D = PlayerSkin.GetComponent<Rigidbody2D>();
        m_Animator = PlayerSkin.GetComponent<Animator>();
    }

    void Update()
    {
        if (Health <= 0f)
        {
            Time.timeScale = 0;
        }

        // Getting values from Input Manager
        m_HorizontalAxis = Input.GetAxisRaw("Horizontal");
        m_VerticalAxis = Input.GetAxisRaw("Vertical");

        // Player play animation
        if (m_MovementVector.x != 0) m_Animator.SetFloat("MovementSpeed", Mathf.Abs(m_HorizontalAxis));
        if (m_MovementVector.y != 0) m_Animator.SetFloat("MovementSpeed", Mathf.Abs(m_VerticalAxis));

        // Player skin direction by X-axis
        if ((m_HorizontalAxis > 0 && !m_FacingRight) || (m_HorizontalAxis < 0 && m_FacingRight))
        {
            m_FacingRight = !m_FacingRight;
            PlayerSkin.transform.Rotate(0f, 180f, 0f);
        }
        
        if (Input.GetButtonDown("Fire"))
        {
            SpawnBullet(PrimaryAttack);
        }

        if (Input.GetButtonDown("Ultimate"))
        {
            UltimateAbuse();
        }
    }

    void FixedUpdate()
    {
        // Camera follow player
        PlayerCamera.transform.position = Vector2.Lerp(PlayerCamera.transform.position, PlayerSkin.transform.position, FollowCameraSmooth);

        // Player movement
        m_MovementVector = new Vector2(m_HorizontalAxis, m_VerticalAxis) * Speed * Time.fixedDeltaTime;
        m_Rigidbody2D.velocity = m_MovementVector;
    }
}