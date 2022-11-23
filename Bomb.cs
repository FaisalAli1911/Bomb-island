using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 3f;
    bool hasExploded = false;
    float countdown;
    public GameObject explosionEffect;
    public float blastradius = 10f;
    public float force = 46f;
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

       


        Collider[] colliders2 = Physics.OverlapSphere(transform.position, blastradius);
        foreach (Collider nearbyObject in colliders2)
            {
            destroy other = nearbyObject.GetComponent<destroy>();
            if (other!=null)
            {
                   other.kill();
            }

            Destroy(gameObject);
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastradius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
           
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, blastradius);
            }
        }


    }
}
