using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField] public BulletScriptableObjects scriptable;
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
            collision.gameObject.GetComponent<PlayerHealth>().health -= dmg;
            Debug.Log(collision.gameObject.GetComponent<PlayerHealth>().health);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemyhealth>().health -= dmg;
            Debug.Log(collision.gameObject.GetComponent<Enemyhealth>().health);
        }
        Destroy(this.gameObject);
    }
}
