using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public int Damage = 20;
    public float Speed = 20f;

    //public GameObject ImpactEffect;
    public AudioClip ShootClip;
    public AudioClip ImpactClip;

    Rigidbody2D PhysicController;
    AudioSource m_AudioSource;
    SpriteRenderer m_SpriteRenderer;
    Collider2D m_Collider2D;

    void Start()
    {
        PhysicController = GetComponent<Rigidbody2D>();
        m_AudioSource = GetComponent<AudioSource>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Collider2D = GetComponent<Collider2D>();

        PhysicController.velocity = transform.right * Speed;
        m_AudioSource.PlayOneShot(ShootClip);

        Destroy(gameObject, 15f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Bullet")
            return;

        m_AudioSource.Stop();
        m_AudioSource.PlayOneShot(ImpactClip);

        m_Collider2D.enabled = false;
        m_SpriteRenderer.enabled = false;

        Destroy(gameObject, 3f);
    }
}
