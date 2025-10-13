using UnityEngine;

public class healthBarScript : MonoBehaviour
{
    public PlayerHealth player;
    public float barLength;
    public float side;



    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindObjectOfType<player2>();
        //player = GetComponent<playerMovement>();
        transform.localScale = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float health = player.health;
        float maxHealth = player.maxHealth;
        barLength = (maxHealth - health) * side;
        transform.localScale = new Vector2(health / maxHealth, 1);
        transform.localPosition = new Vector2(barLength / maxHealth * 2, 0); //width * 0.25
        //transform.localScale = new Vector2(poss, 1f);
        //transform.localPosition = new Vector2(posp, 0);
    }
}
