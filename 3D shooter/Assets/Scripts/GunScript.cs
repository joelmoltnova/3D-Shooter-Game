using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] public BulletScriptableObjects Scriptable;
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
        bullet.GetComponent<bulletScript>().dmg = Scriptable.bDamage;
        bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * Scriptable.bSpeed;
        


    }
}
