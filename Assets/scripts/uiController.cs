using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiController : MonoBehaviour {
	public Texture2D[] texture;
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject four;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void shaer(){
		PlayerPrefs.SetString ("mode","shaer");
		one.GetComponent<MeshRenderer> ().material.mainTexture = texture [0];
		two.GetComponent<MeshRenderer> ().material.mainTexture = texture [1];
		three.GetComponent<MeshRenderer> ().material.mainTexture = texture [2];
		four.GetComponent<MeshRenderer> ().material.mainTexture = texture [3];
	}
	public void hospital(){
		PlayerPrefs.SetString ("mode","hospital");
		one.GetComponent<MeshRenderer> ().material.mainTexture = texture [4];
		two.GetComponent<MeshRenderer> ().material.mainTexture = texture [5];
		three.GetComponent<MeshRenderer> ().material.mainTexture = texture [6];
		four.GetComponent<MeshRenderer> ().material.mainTexture = texture [7];
	}public void restaurant(){
		PlayerPrefs.SetString ("mode","restaurant");
		one.GetComponent<MeshRenderer> ().material.mainTexture = texture [8];
		two.GetComponent<MeshRenderer> ().material.mainTexture = texture [9];
		three.GetComponent<MeshRenderer> ().material.mainTexture = texture [10];
		four.GetComponent<MeshRenderer> ().material.mainTexture = texture [11];
	}public void mall(){
		PlayerPrefs.SetString ("mode","mall");
		one.GetComponent<MeshRenderer> ().material.mainTexture = texture [12];
		two.GetComponent<MeshRenderer> ().material.mainTexture = texture [13];
		three.GetComponent<MeshRenderer> ().material.mainTexture = texture [14];
		four.GetComponent<MeshRenderer> ().material.mainTexture = texture [15];
	}public void bank(){
		PlayerPrefs.SetString ("mode","bank");
		one.GetComponent<MeshRenderer> ().material.mainTexture = texture [16];
		two.GetComponent<MeshRenderer> ().material.mainTexture = texture [17];
		three.GetComponent<MeshRenderer> ().material.mainTexture = texture [18];
		four.GetComponent<MeshRenderer> ().material.mainTexture = texture [19];
	}
}
