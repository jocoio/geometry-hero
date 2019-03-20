using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	public Button startButton;

	void Start() {
		startButton.onClick.AddListener(StartGame);
	}

	void StartGame() {
		SceneManager.LoadScene("LevelSelect");
	}
}
