using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0f);
    }
}
