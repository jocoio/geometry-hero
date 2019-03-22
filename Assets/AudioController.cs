using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.CompareTag("Player")) {
            audio.Play();
		}
	}
}
