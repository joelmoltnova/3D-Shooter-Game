using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] public BulletScriptableObjects gunA, gunB, Scriptable;
    public GameObject Bullet;
    public Transform lookCamera;

    public MeshFilter meshFilter;
    public MeshRenderer MeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Scriptable = gunA;
        meshFilter.mesh = Scriptable.bModel;
        MeshRenderer.material = Scriptable.bMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bulletFire();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Scriptable == gunA)
            {
                Scriptable = gunB;
            }
            else
            {
                Scriptable = gunA;
            }
        }
    }
    void bulletFire()
    {
        Vector3 positie = lookCamera.position + lookCamera.forward * 2;
        
        GameObject bullet = Instantiate(Bullet, positie, Quaternion.identity);
        bullet.GetComponent<bulletScript>().dmg = Scriptable.bDamage;
        bullet.GetComponent<bulletScript>().range = Scriptable.bRange;
        bullet.GetComponent<Rigidbody>().linearVelocity = lookCamera.forward * Scriptable.bSpeed;
        


    }
}
