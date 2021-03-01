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
            collider.SendMessage("SetDamage", Damage);
            collider.GetComponent<Animator>().Play("enemy_creep_hurt");
        }

        m_Collider2D.enabled = false;
        m_SpriteRenderer.enabled = false;

        //m_AudioSource.Stop();
        m_ImpactEffectInst = Instantiate(ImpactPrefab, transform.position, transform.rotation);
        m_AudioSource.PlayOneShot(ImpactClip);

        Destroy(gameObject, 4f);
        Destroy(m_ImpactEffectInst, 0.2f);
    }
}