using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isInvincible;
    public GameObject attackBoxPrefab;
    public Vector2 speed;
    public float timeInvincible;
    public int currentHealth;
    public int maxHealth;
    
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    float horizontal;
    float invincibleTimer;
    float vertical;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
                
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
                
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                OwlKing king = hit.collider.GetComponent<OwlKing>();
                if (king != null)
                {
                    king.DisplayKingDialog();
                }
            }
        }
    }

    void FixedUpdate() 
    {
        Move(speed);
    }

    public void Move(Vector2 moveSpeed){
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector2 position = rb.position;
        position.x = position.x + moveSpeed.x * horizontal * Time.deltaTime;
        position.y = position.y + moveSpeed.y * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            // animator for being hit?
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    public void Attack()
    {
        GameObject attackBox = Instantiate(attackBoxPrefab, rb.position + Vector2.up * 0.5f, Quaternion.identity);
        
        animator.SetTrigger("Attack");
    }
}
