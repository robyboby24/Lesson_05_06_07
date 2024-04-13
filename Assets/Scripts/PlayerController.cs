using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Weapon;

    //basic movements
    public float movementSpeed = 20f;
    public float jumpForce = 400f;
    public float horizontalMove;
    public bool jump = false;
    Rigidbody2D rb;

    string PlayerClass = "player";
    int PlayerHealth;
    int PlayerStrength;
    int PlayerIntelligent;
    int PlayerAgility;
    int PlayerDamage;
    bool PlayerShoot;

    void WarriorClass()
    {
        if (!GetComponent<BaseWarrior>())
        {
            var klassz = gameObject.AddComponent<BaseWarrior>();
            PlayerClass = klassz.ClassName;
            PlayerHealth = klassz.Health;
            PlayerStrength = klassz.Strength;
            PlayerIntelligent = klassz.Intelligent;
            PlayerAgility = klassz.Agility;
            PlayerDamage = klassz.Damage;
        }

        var weapon = Instantiate(Weapon, gameObject.transform);
        weapon.transform.position += new Vector3(0.6f, 0.3f, 0);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WarriorClass();
    }
    private void Update()
    {
        //moving direction
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;

        //rotating
        if (horizontalMove < 0f) transform.localEulerAngles = new Vector3(0, 180, 0);
        if (horizontalMove > 0f) transform.localEulerAngles = new Vector3(0, 0, 0);

        //jumping
        if (Input.GetButtonDown("Jump")) jump = true;
    }
    private void FixedUpdate()
    {
        //we create our moving function
        Moving(horizontalMove, jump);
    }
    void Moving(float movement, bool canjump)
    {
        rb.velocity = new Vector2(movement * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if (canjump && GetComponent<CircleCollider2D>().IsTouchingLayers())
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = !canjump;
        }
    }
}
