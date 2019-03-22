using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerHandler : MonoBehaviour {

	private bool canHop = false;
	private bool jumped = false;

	private Score score;
	private CameraMovement camera;

	void Start() {
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.CompareTag("Player")) {
			canHop = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			canHop = false;
			if (jumped) {
				score.IncrementScore();
			}
			else {
				score.BreakCombo();
				Debug.Log("About to shake");
				StartCoroutine(camera.Shake(.1f, .25f));
			}
		}
	}

	private void Update() {
		if(canHop && Input.GetButtonDown("Jump")) {
			jumped = true;
		}
	}
}
