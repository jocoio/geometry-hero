using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    public IEnumerator Shake(float duration, float magnitude) {
        Debug.Log("Shaking");

        Vector2 originalPosition = transform.localPosition;
        float elapsed = 0;
        audio.Play();
        while(elapsed < duration) {
            float x = Random.Range(-1, 1) * duration;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector2(x, y);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
