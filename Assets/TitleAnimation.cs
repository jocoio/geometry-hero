using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour {

	public float frequency = 5f;
	public float amplitude = 0.5f;

	public float rotationTime = 2f;

	private RectTransform title;

	private float z = 0.0f;
	private int willRotate;

	// Use this for initialization
	void Start () {
		title = GetComponent<RectTransform>();
		willRotate = Random.Range(0, 100);

	}

	// Update is called once per frame
	void Update () {
		float change = Mathf.Sin(Time.time * frequency) * amplitude;
		title.localScale = title.localScale + new Vector3(change, change, change);

		if(willRotate > 90) {
			z = z + rotationTime;

			if(z >= 360) {
				z = 0;
			}
			transform.localRotation = Quaternion.Euler(0, 0, z);
		}


	}
}
