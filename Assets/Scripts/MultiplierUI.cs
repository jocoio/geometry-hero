using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierUI : MonoBehaviour {

	private Text text;
	private Score score;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text>();
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();

	}

	// Update is called once per frame
	void Update () {
		text.text = score.multiplier.ToString() + "X";
	}
}
