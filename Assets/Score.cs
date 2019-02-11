using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public int score = 0;
	public int multiplier = 1;
	public int combo = 0;

	public void IncrementScore() {
		combo++;
		score += 100 * multiplier;
	}

	public void BreakCombo() {
		combo = 0;
	}

	private void Update() {
		if(combo < 10) {
			multiplier = 1;
		}
		else if(combo < 20) {
			multiplier = 2;
		}
		else if(combo < 30) {
			multiplier = 4;
		}
		else {
			multiplier = 8;
		}
	}
}
