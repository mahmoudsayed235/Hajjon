using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getLandAndLit : MonoBehaviour {
	private float longitude,latitude;
	// Use this for initialization
	AudioSource[] allAudioSources;
	void Awake () {
		allAudioSources = GameObject.FindObjectsOfType<AudioSource> ();

		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocationService());
	}
	private IEnumerator StartLocationService(){
		if (!Input.location.isEnabledByUser) {
			print ("gps is closed");
			yield break;
		}
		Input.location.Start ();
		int max = 1;
		while(Input.location.status==LocationServiceStatus.Initializing&&max>0){
			yield return new WaitForSeconds (1);
			max--;
		}
		if (max == 0) {
			print ("timed out");
			yield break;
		}
		if (Input.location.status == LocationServiceStatus.Failed) {
			yield break;
		} 
		longitude = (Input.location.lastData.longitude%0.1F)*100000;
		latitude = (Input.location.lastData.latitude%0.1F)*100000;
		//gameObject.transform.localPosition =new Vector3(longitude,this.transform.position.y,latitude+int.Parse( gameObject.name));
		//label.text = "long : " + gameObject.transform.localPosition.x + "   lat : " + gameObject.transform.localPosition.z;
		yield break;
	}
	// Update is called once per frame
	void Update () {
			
	}
	public void X()
	{
		StopAllAudio ();
		this.GetComponent<AudioSource> ().Play ();
	}
	public GameObject canvas;
	void OnMouseDown()
	{
		if(PlayerPrefs.GetString("mode")=="shaer"){
		canvas.SetActive (true);
		}
	}


	void StopAllAudio() {
		foreach (AudioSource audioS in allAudioSources) {
			audioS.Stop ();
		}
	}
}
