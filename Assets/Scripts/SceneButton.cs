using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public string to;
    public string level;

    private Text text;

    void Start() {
        text = GetComponentInChildren<Text>();

        text.text = level;
    }

    public void GoToScene() {
        SceneManager.LoadScene(to);
    }
}
