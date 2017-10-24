using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBombPressedBehavior : MonoBehaviour {

	private Timer explodeTimer;
	bool pressed;

	[SerializeField]
	GameObject explosion, bossDamageExplosion;
	CircleCollider2D myCollider;
	Animator myAnim;

	[SerializeField]
	GameObject pickupCollider;

	void Start ()
	{
		myCollider = GetComponent<CircleCollider2D>();
		myAnim = GetComponent<Animator>();
		Invoke("Press", 1);
	}

	void FixedUpdate ()
	{
		CheckBoss();
	}

	void CheckBoss ()
	{
		if (pressed)
		{
			Collider2D[] colliders = Physics2D.OverlapCircleAll(
				(Vector2) transform.position + myCollider.offset, 
				myCollider.radius);

			for (int i=0; i<colliders.Length; i++) {
				string tag = colliders[i].gameObject.tag;
				if (tag.Equals("Boss"))
				{
					BossDamageExplode();
				}
			}
		}
	}

	public void Press ()
	{
		CancelInvoke();
		pressed = true;
		myAnim.SetTrigger("press");
		tag = "Untagged";
		pickupCollider.GetComponent<CircleCollider2D>().enabled = true;
	}

	public void Explode ()
	{
		if (!pressed)
		{
			Instantiate(explosion, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
		}
	}

	public void BossDamageExplode ()
	{
		Instantiate(bossDamageExplosion, this.transform.position, this.transform.rotation);
		Destroy(gameObject);
	}
}
