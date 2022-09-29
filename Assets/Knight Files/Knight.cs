using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour {

	private Animator m_Anim; 
	private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;
    public float jumpPower;
    public bool grounded = false;

    // Use this for initialization
    void Start () {

		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

	}

    private void Update()
    {
        bool attack = Input.GetButtonDown("Fire1");

        if (attack)
        {
            print("attack");
            m_Anim.SetTrigger("Attack");
        }

        if (Input.GetKeyDown("space") && grounded)
        {
            print("jump");
            Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
            //m_Rigidbody2D.velocity = jumpMovement * 5;
            m_Rigidbody2D.AddForce(jumpMovement * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		//print (h);    
        if(Mathf.Abs(h) != 0)
		Move(h);
        else
            m_Anim.SetBool("Walk", false);

    }



	public void Move(float move)
	{
        print("walk");
        //m_Anim.SetFloat("Speed", Mathf.Abs(move));
        m_Anim.SetBool("Walk", true);
        m_Rigidbody2D.velocity = new Vector2(move* 2, m_Rigidbody2D.velocity.y);
        
        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        grounded = false;
    }
}

