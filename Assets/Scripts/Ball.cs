using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public Paddle paddle;
	private Vector3 paddleToBallVector;
	private Rigidbody2D rigi;
	private bool hasStarted = false;

	void Awake() {
		rigi = GetComponent<Rigidbody2D>();
	}


	void Start() {
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}


	void Update() {
		if (!hasStarted) {

			// Lock the ball.
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Handle launch of ball.
			if (Input.GetMouseButtonDown(0)) {
				print("Mouse clicked!");
				hasStarted = true;
				rigi.velocity = new Vector2(2f, 10f);
			}
		}
	}


}
