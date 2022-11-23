using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerrb;
    private GameObject Camera;
    public bool hasPowerup;
    private float powerStrength = 10f;
    public GameObject Powerupindicator;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Focal Point");
        playerrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        Powerupindicator.transform.position = transform.position+ new Vector3(0f,-0.5f,0f);
        playerrb.AddForce(Camera.transform.forward * forwardInput*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Powerupindicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }


        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup=false;
            Powerupindicator.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody= collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromthePlayer=(collision.gameObject.transform.position-transform.position);
            enemyRigidbody.AddForce(awayFromthePlayer * powerStrength, ForceMode.Impulse);
        }
    }


}
