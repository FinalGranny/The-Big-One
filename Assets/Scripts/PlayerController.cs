using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float maxSpeed = 5f;
	private bool facingRight = true;

	//Animator animator;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 350f;

	void Start () 
	{
		//animator = GetComponent<Animator> ();
	}
	

	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		//animator.SetBool ("Ground", grounded);

		//animator.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		//if (!grounded) return;

		float move = Input.GetAxis ("Horizontal");

		//animator.SetFloat ("Speed", Mathf.Abs (move));

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update()
	{
		if (grounded && Input.GetButtonDown ("Jump")) 
		{
			//animator.SetBool ("Ground", false);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
		}
	}

	//Flip the screen
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
