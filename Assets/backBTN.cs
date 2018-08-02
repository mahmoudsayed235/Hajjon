using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backBTN : MonoBehaviour {

	AudioSource[] allAudioSources;
	void Awake () {
		allAudioSources = GameObject.FindObjectsOfType<AudioSource> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			this.gameObject.SetActive(false);
			StopAllAudio ();
		}
		
	}
	void StopAllAudio() {
		foreach (AudioSource audioS in allAudioSources) {
			audioS.Stop ();
		}
	}
}
