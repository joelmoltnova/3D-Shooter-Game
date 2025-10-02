using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{ 
    public Rigidbody body;
    public float bulletSpeed;
    public int dmg;
    // Start is called before the first frame update
    void Start()
    {
        //body.AddForce(Vector3.forward * bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<playerHealth>().health -= dmg;
            Debug.Log(collision.gameObject.GetComponent<playerHealth>().health);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= dmg;
            //Debug.Log(collision.gameObject.GetComponent<playerHealth>().health);
        }
        Destroy(this.gameObject);
    }
}
