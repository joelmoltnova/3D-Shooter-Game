using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bulletFire();
        }
    }
    void bulletFire()
    {
        Vector3 positie = transform.position + Vector3.forward*2;
        
        GameObject bullet = Instantiate(Bullet, positie, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().linearVelocity = Vector3.forward * 100;


    }
}
