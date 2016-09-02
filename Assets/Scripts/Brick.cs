using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	public int timesHit;


	void Start() {
	}
	

	void Update() {
	}
		

	void OnCollisionEnter2D(Collision2D collision) {
		timesHit++;
	}


}
