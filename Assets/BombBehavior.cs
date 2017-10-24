using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour {

	private Timer explodeTimer;
	[SerializeField]
	GameObject explosion;

	public void Explode ()
	{
		Instantiate(explosion, this.transform.position, this.transform.rotation);
		Destroy(gameObject);
	}
}
