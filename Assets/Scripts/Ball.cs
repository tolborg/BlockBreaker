using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private Rigidbody2D rigi;
	private AudioSource audi;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;


	void Start() {
		paddle = FindObjectOfType<Paddle>();
		rigi = GetComponent<Rigidbody2D>();
		audi = GetComponent<AudioSource>();

		paddleToBallVector = this.transform.position - paddle.transform.position;
	}


	void Update() {
		if (!hasStarted) {

			// Lock the ball.
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Unlock ball and launch it.
			if (Input.GetMouseButtonDown(0)) {
				hasStarted = true;
				rigi.velocity = new Vector2(1f, 10f);
			}
		}
	}


	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {
			audi.Play();
			rigi.velocity += tweak;
		}
	}


}
