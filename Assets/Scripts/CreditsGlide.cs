using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsGlide : MonoBehaviour
{
    public float GlideSpeed = 20f;

    void Update()
    {
        transform.position += new Vector3(0f, GlideSpeed * Time.deltaTime, 0f);
    }
}