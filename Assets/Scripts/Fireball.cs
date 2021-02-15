using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int Damage = 20;
    public float BodySpeed = 20f;
    public GameObject ImpactEffect;
    public AudioClip ShootClip;
    public AudioClip ImpactClip;

    Rigidbody2D PhysicController;
    AudioSource m_AudioSource;

    void Start()
    {
        PhysicController = GetComponent<Rigidbody2D>();
        m_AudioSource = GetComponent<AudioSource>();

        PhysicController.velocity = transform.right * BodySpeed;
        m_AudioSource.PlayOneShot(ShootClip);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        m_AudioSource.PlayOneShot(ImpactClip);
        //Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
