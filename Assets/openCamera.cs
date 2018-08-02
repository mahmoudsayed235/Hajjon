using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openCamera : MonoBehaviour {

	// Use this for initialization

	WebCamTexture mCamera = null;
	public GameObject plane;
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Script has been started");

		mCamera = new WebCamTexture ();
		plane.GetComponent<MeshRenderer> ().material.mainTexture = mCamera;
		plane.transform.localScale = new Vector3 (mCamera.width*75,1,mCamera.height*75);
		mCamera.Play ();

	}
	// Update is called once per frame
	void Update () {
		
	}
}
