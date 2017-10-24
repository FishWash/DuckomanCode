using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDieBehavior : MonoBehaviour {

	[SerializeField]
	GameObject explosion, victory;
	float explodeTime = 0.7f;

	// Use this for initialization
	void Start () {
		Invoke("DieExplode", 1);
		Invoke("ExplodeFaster", 3);
	}

	void ExplodeFaster ()
	{
		Debug.Log("FASTER");
		explodeTime = 0.3f;
	}

	void DieExplode () 
	{
		Vector2 randomPos = Random.insideUnitCircle + new Vector2(0, 0.5f);
		GameObject _explosion = Instantiate(explosion, (Vector2) transform.position + randomPos, transform.rotation);
		float randomScale = Random.value + 1;
		_explosion.transform.localScale = new Vector2(randomScale, randomScale);

		Invoke("DieExplode", explodeTime);
	}

	void Destroy ()
	{
		GameObject lastExplosion = Instantiate(explosion, transform.position, transform.rotation);
		lastExplosion.transform.localScale = new Vector2(4, 4);
		CancelInvoke();
		Instantiate(victory, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
