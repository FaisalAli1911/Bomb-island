using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public float speed = 2.0f;
    public Rigidbody enemyrb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookDirection = (player.transform.position - transform.position).normalized;
        enemyrb.AddForce(LookDirection*speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
