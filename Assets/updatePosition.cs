using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updatePosition : MonoBehaviour {
	private float longitude,latitude;
	// Use this for initialization
	void Start () {
		StartCoroutine (StartLocationService());
	}
	private IEnumerator StartLocationService(){
		while (true) {
			if (!Input.location.isEnabledByUser) {
				print ("gps is closed");
				yield break;
			}
			Input.location.Start ();
			int max = 1;
			while (Input.location.status == LocationServiceStatus.Initializing && max > 0) {
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
			gameObject.transform.localPosition = new Vector3 (longitude , this.transform.position.y, latitude);
		
			Input.location.Stop();

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
