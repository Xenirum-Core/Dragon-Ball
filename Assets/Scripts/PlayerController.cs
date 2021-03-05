using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Camera PlayerCamera;
    public GameObject PlayerSkin;
    public GameObject ProjectileSpawnPoint;
    public GameObject PrimaryAttack;
    public GameObject UltimateAttack;

    public float Health = 100f;
    public float Speed = 80f;
    public int Rage = 0;
    public int Score = 0;

    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;

    private bool m_FacingRight = true;
    private float m_HorizontalAxis;
    private float m_VerticalAxis;
    private bool IsDie = false;

    private Vector2 m_MovementVector;

    #region Custom functions
    private IEnumerator SpawnBullet(GameObject ProjectilePrefab)
    {
        m_Animator.Play("player_attack");
        Instantiate(ProjectilePrefab, ProjectileSpawnPoint.transform.position, ProjectileSpawnPoint.transform.rotation);
        yield return null;
    }

    public IEnumerator AddRage()
    {
        Rage++;
        yield return null;
    }

    public IEnumerator AddScore(int value)
    {
        Score += value;
        PlayerPrefs.SetInt("Score", Score);
        yield return null;
    }

    private IEnumerator UltimateAbuse()
    {
        if (Rage >= 10)
        {
            StartCoroutine(SpawnBullet(UltimateAttack));
            Rage -= 10;
        }

        yield return null;
    }

    public IEnumerator SetHealth(int value)
    {
        m_Animator.Play("player_hurt");
        Health -= value;
        yield return null;
    }

    public IEnumerator Die()
    {
        SceneManager.LoadScene("GameOver");
        yield return null;
    }
    #endregion

    private void Start()
    {
        m_Rigidbody2D = PlayerSkin.GetComponent<Rigidbody2D>();
        m_Animator = PlayerSkin.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!IsDie)
        {
            if (Health <= 0f && !IsDie)
            {
                StartCoroutine("Die");
            }

            // HUD poor performance
            GameObject.Find("HP").GetComponentInChildren<Text>().text = "HP " + Health + "/100";
            GameObject.Find("Rage").GetComponentInChildren<Text>().text = "ЯРОСТЬ " + Rage;
            GameObject.Find("Score").GetComponentInChildren<Text>().text = "ОЧКИ " + Score;

            // Get values from Input Manager
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
                StartCoroutine(SpawnBullet(PrimaryAttack));
            }

            if (Input.GetButtonDown("Ultimate"))
            {
                StartCoroutine("UltimateAbuse");
            }

            if (Input.GetButtonDown("Cancel"))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    private void LateUpdate()
    {
        PlayerCamera.transform.position = PlayerSkin.transform.position;
    }

    private void FixedUpdate()
    {
        m_MovementVector = new Vector2(m_HorizontalAxis, m_VerticalAxis) * Speed * Time.fixedDeltaTime;
        m_Rigidbody2D.velocity = m_MovementVector;
    }
}