using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerHandler : MonoBehaviour {

	private bool canHop = false;
	private bool jumped = false;

	private Score score;

	void Start() {
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
	}

	// If player enters trigger area, they can pick it up
	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.CompareTag("Player")) {
			canHop = true;
		}
	}

	// If they exit, they can't pick it up
	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			canHop = false;
			if (jumped) {
				score.IncrementScore();
			}
			else {
				score.BreakCombo();
			}
		}
	}

	// If they can pick it up and press E, item data is added to player inventory
	private void Update() {
		if(canHop && Input.GetButtonDown("Jump")) {
			jumped = true;
		}
	}
}
