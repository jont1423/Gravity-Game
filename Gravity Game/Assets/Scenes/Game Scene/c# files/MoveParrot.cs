using UnityEngine;
using System.Collections;

public class MoveParrot : MonoBehaviour {
	private int speed = 10;
	private float moveX = -1;
	public GameObject parrot;
	//public bool alive = true;

	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * speed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
		if (gameObject.GetComponent<Rigidbody2D> ().position.x < -8) {
			//alive = false;
			Instantiate (parrot, new Vector2 (7.35f,Random.Range(-4.0f, 4.0f)),Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
