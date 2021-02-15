using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public float BodySpeed = 20f;
    private Rigidbody2D m_Rigidbody2D;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.velocity = transform.right * BodySpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
