using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

	public float fadeTime;

	public float alphaStart;
	public float alphaDest;

	public bool fading;
	public UnityEngine.UI.Image screenColor;

	private float fadeTimer;

	public static ScreenFader Instance;

	void Awake() {
		Instance = this;
	}

	void Start() {
		FadeIn ();
	}

	public void FadeOut() {
		fadeTimer = 0;
		fading = true;
		alphaStart = screenColor.color.a;
		alphaDest = 1.0f;
	}

	public void FadeIn() {
		fadeTimer = 0;
		fading = true;
		alphaStart = screenColor.color.a;
		alphaDest = 0.0f;
	}

	void Update () {
		if (fading) {
			fadeTimer += Time.deltaTime;
			Color color = screenColor.color;
			if (fadeTimer >= fadeTime) {
				color.a = alphaDest;
				fading = false;
			} else {
				color.a = Mathf.Lerp (alphaStart, alphaDest, fadeTimer / fadeTime);
			}
			screenColor.color = color;
		}
	}
}
