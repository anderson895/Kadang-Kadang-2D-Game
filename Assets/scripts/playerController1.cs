using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController1 : MonoBehaviour {
	public float MovementSpeed = 5;
	public float JumpForce = 7;
	private Rigidbody2D _rigidbody;
	private Animator anim;
	private bool facingright=true;
	private bool Grounded=false;


	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

	}

	private void Update()
	{
		var movement = Input.GetAxis("Horizontal");
		transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

		if(Input.GetKeyDown(KeyCode.A))
			{
				anim.SetInteger("state",1);
			}
		if(Input.GetKeyUp(KeyCode.A))
			{
				anim.SetInteger("state",0);
			}
		if(Input.GetKeyDown(KeyCode.D))
		{
			anim.SetInteger("state",1);
		}
		if(Input.GetKeyUp(KeyCode.D))
		{
			anim.SetInteger("state",0);
		}
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger ("shoot");
		}



		if (movement > 0 && !facingright) {
			flip ();
		} else if (movement < 0 && facingright) {
			flip ();
		}
			


		if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y)<0.001f)
		{
			_rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
			anim.SetTrigger ("jump");
			Grounded = false;
		}	
	}

	private void flip()
	{
		facingright = !facingright;
		Vector3 theScale = transform.localScale;
		//theScale.x *= -1;
		//transform.localScale = theScale;
		transform.Rotate(0f,180f,0f);
	}

}
