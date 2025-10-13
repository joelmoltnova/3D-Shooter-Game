using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet", order = 0)]
public class BulletScriptableObjects : ScriptableObject {
    [SerializeField] private string bulletName;
    [SerializeField] private int bulletDamage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulRange;
    [SerializeField] private Mesh bulletModel;
    [SerializeField] public Material bulletMaterial;

    public string bName { get { return bulletName; } }
    public int bDamage { get { return bulletDamage; } }
    public float bSpeed { get { return bulletSpeed; } }
    public float bRange { get { return bulRange; } }
    public Mesh bModel { get { return bulletModel; } }
    public Material bMaterial { get { return bulletMaterial; } }
}


