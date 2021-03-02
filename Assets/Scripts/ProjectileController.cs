using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int Damage = 20;
    public float Speed = 20f;

    public GameObject ImpactPrefab;
    public AudioClip ImpactClip;

    private Rigidbody2D m_Rigidbody2D;
    private AudioSource m_AudioSource;
    private SpriteRenderer m_SpriteRenderer;
    private Collider2D m_Collider2D;
    private GameObject m_ImpactEffectInst;

    private void AoeDamage(Vector2 center, float radius)
    {
        Collider2D[] OverlappedCollider = Physics2D.OverlapCircleAll(center, radius);
        foreach (var HitCollider in OverlappedCollider)
        {
            if (HitCollider.CompareTag("Enemy"))
                HitCollider.SendMessage("SetDamage", Damage);
        }
    }

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_AudioSource = GetComponent<AudioSource>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Collider2D = GetComponent<Collider2D>();

        m_Rigidbody2D.velocity = transform.right * Speed;

        Destroy(gameObject, 8f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
            return;

        if (collider.tag == "Enemy")
        {
            if (Damage < 99)
                collider.SendMessage("SetDamage", Damage);
            else
                AoeDamage(transform.position, 20f);
        }

        m_Collider2D.enabled = false;
        m_SpriteRenderer.enabled = false;

        m_ImpactEffectInst = Instantiate(ImpactPrefab, transform.position, transform.rotation);
        m_AudioSource.PlayOneShot(ImpactClip);

        Destroy(gameObject, 4f);
        Destroy(m_ImpactEffectInst, 0.2f);
    }
}