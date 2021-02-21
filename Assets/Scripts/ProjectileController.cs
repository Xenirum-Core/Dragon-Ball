using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public int Damage = 20;
    public float Speed = 20f;

    public GameObject ImpactEffect;
    public AudioClip ShootClip;
    public AudioClip ImpactClip;

    Rigidbody2D m_Rigidbody2D;
    AudioSource m_AudioSource;
    SpriteRenderer m_SpriteRenderer;
    Collider2D m_Collider2D;
    GameObject m_ImpactEffectInst;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_AudioSource = GetComponent<AudioSource>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Collider2D = GetComponent<Collider2D>();

        m_Rigidbody2D.velocity = transform.right * Speed;
        m_AudioSource.PlayOneShot(ShootClip);

        Destroy(gameObject, 8f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
            return;

        m_AudioSource.Stop();
        m_AudioSource.PlayOneShot(ImpactClip);

        m_Collider2D.enabled = false;
        m_SpriteRenderer.enabled = false;

        if (col.tag == "Enemy")
        {
            // Implement damage for enemy
        }

        m_ImpactEffectInst = Instantiate(ImpactEffect, transform.position, transform.rotation);

        Destroy(gameObject, 4f);
        Destroy(m_ImpactEffectInst, 0.5f);
    }
}
