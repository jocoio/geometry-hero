using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipTrigger : MonoBehaviour
{
    public string tipText;

    public CanvasGroup tooltip;

    private Text text;
    public float timeout = 5;
    private bool isActive = false;

    void Start() {
        tooltip.alpha = 0;
        text = tooltip.GetComponentInChildren<Text>();
    }

    void Update() {
        if(isActive) {
            if (timeout < 0) {
                tooltip.alpha = 0;
                isActive = false;
            }
            else {
                tooltip.alpha = 1;
                timeout -= Time.deltaTime;
            }

        }

    }


    void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.CompareTag("Player")) {
            text.text = tipText;
            tooltip.alpha = 1;
            isActive = true;
		}
	}


}
