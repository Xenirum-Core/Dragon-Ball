using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject SpawnPoint;

    public float TimeToShoot = 2f;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Bullet")
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0f);
        }
    }

    void Update()
    {
        TimeToShoot -= Time.deltaTime;

        if (TimeToShoot < 0)
        {
            var tmp = Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            tmp.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 0f);
            TimeToShoot = 2f;
        }
    }
}
