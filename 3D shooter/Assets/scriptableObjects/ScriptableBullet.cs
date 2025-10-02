using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet", order = 0)]
public class BulletScriptableObjects : ScriptableObject {
    [SerializeField] private string bulletName;
    [SerializeField] private int bulletDamage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulRange;

    public string bName { get { return bulletName; } }
    public int bDamage { get { return bulletDamage; } }
    public float bSpeed { get { return bulletSpeed; } }
    public float bRange { get { return bulRange; } }
}


