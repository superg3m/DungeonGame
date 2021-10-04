using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    private float rollCoolDownTimer;
    public float rollCoolDown = 1f;
    private float attackCoolDownTimer;
    public float attackCoolDown = 1f;
    public int currentAttack = 1;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        // Handles Running animations based on the user input WASD
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        // Handles the Roll animation based off of the user input LeftShift
        if (rollCoolDownTimer == 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetTrigger("Roll");
                rollCoolDownTimer = rollCoolDown;
            }
        }
        
        // Handles the roll cooldown
        if (rollCoolDownTimer > 0)
        {
            rollCoolDownTimer -= Time.deltaTime;
        }
        if (rollCoolDownTimer < 0)
        {
            rollCoolDownTimer = 0;
        }
        // Handles the attack animations with cases
        if (attackCoolDownTimer > 0)
        {
            attackCoolDownTimer -= Time.deltaTime;
        }
        if (attackCoolDownTimer < 0)
        {
            attackCoolDownTimer = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            switch (currentAttack)
            {
                case 1:
                    anim.SetTrigger("Attack1");
                    currentAttack = 2;
                    break;
                case 2:
                    anim.SetTrigger("Attack2");
                    currentAttack = 3;
                    break;
                case 3:
                    anim.SetTrigger("Attack3");
                    currentAttack = 1;
                    break;
            }
        }
    }
}
