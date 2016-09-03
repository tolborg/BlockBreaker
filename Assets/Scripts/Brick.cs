using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;

	private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;


	void Start() {
		isBreakable = (this.tag == "Breakable");

		if (isBreakable) {
			breakableCount++;
		}

		timesHit = 0;
		maxHits = hitSprites.Length + 1;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
		

	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.2f);
		if (isBreakable) {
			HandleHits();
		}
	}


	void HandleHits() {
		timesHit++;

		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		else {
			LoadSprites();
		}
	}


	void LoadSprites() {
		int spriteIndex = timesHit - 1;

		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}


	// TODO Remove this method once we can actually win!
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}


}
