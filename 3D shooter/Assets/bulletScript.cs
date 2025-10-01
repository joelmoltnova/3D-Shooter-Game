using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{ 
    public Rigidbody body;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //body.AddForce(Vector3.forward * bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
