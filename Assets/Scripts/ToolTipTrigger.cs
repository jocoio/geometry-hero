using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipTrigger : MonoBehaviour
{
    public string tipText;

    public CanvasGroup tooltip;

    private Text text;
    private float timeout = 5;

    void Start() {
        tooltip.alpha = 0;
        text = tooltip.GetComponentInChildren<Text>();
    }

    void Update() {
        if(tooltip.alpha > 0) {
            timeout -= Time.deltaTime;
        }
        if (timeout < 0) {
            tooltip.alpha = 0;
            timeout = 5;
        }
    }


    void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.CompareTag("Player")) {
            text.text = tipText;
            tooltip.alpha = 1;
		}
	}


}
