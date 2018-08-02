using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AugmentedScript : MonoBehaviour
{


	private float originalLatitude;
	private float originalLongitude;
	private float currentLongitude;
	private float currentLatitude;

	public Text distanceTextObject;
	private float distance;

	private bool setOriginalValues = true;

	private Vector3 targetPosition;
	private Vector3 originalPosition;

	private float speed = .1f;

	IEnumerator GetCoordinates()
	{
		//while true so this function keeps running once started.
		while (true) {
			// check if user has location service enabled
		
			if (!Input.location.isEnabledByUser)
				yield break;

			// Start service before querying location
			Input.location.Start();

			// Wait until service initializes
			int maxWait = 2;
			while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
			{
				yield return new WaitForSeconds(1);
				maxWait--;
			}


			distanceTextObject.text = "max wait : " + maxWait;
			// Connection has failed
			if (Input.location.status == LocationServiceStatus.Failed)
			{
				distanceTextObject.text = ("Unable to determine device location");
					print("Unable to determine device location");
				yield break;
			}else {
				// Access granted and location value could be retrieved

				distanceTextObject.text =("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
				print ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

				//if original value has not yet been set save coordinates of player on app start
				if (setOriginalValues) {
					originalLatitude = Input.location.lastData.latitude;
					originalLongitude = Input.location.lastData.longitude;
					setOriginalValues = false;
				}

				//overwrite current lat and lon everytime
				currentLatitude = Input.location.lastData.latitude;
				currentLongitude = Input.location.lastData.longitude;

				//calculate the distance between where the player was when the app started and where they are now.
				Calc (originalLatitude, originalLongitude, currentLatitude, currentLongitude);

			}

			Input.location.Stop();
		}

	}

	//calculates distance between two sets of coordinates, taking into account the curvature of the earth.
	public void Calc(float lat1, float lon1, float lat2, float lon2)
	{

		float R = 6378.137f; // Radius of earth in KM
		float dLat = lat2 * Mathf.PI / 180f - lat1 * Mathf.PI / 180f;
		float dLon = lon2 * Mathf.PI / 180f - lon1 * Mathf.PI / 180f;
		float a = Mathf.Sin(dLat / 2f) * Mathf.Sin(dLat / 2f) +
		Mathf.Cos(lat1 * Mathf.PI / 180f) * Mathf.Cos(lat2 * Mathf.PI / 180f) *
		Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2f);
		float c = 2f * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1f - a));
		distance = R * c;
		distance = distance * 1000f; // meters
		//set the distance text on the canvas
		distanceTextObject.text = "Distance: " + distance.ToString();
		//convert distance from double to float
		float distanceFloat = (float)distance;
		//set the target position of the ufo, this is where we lerp to in the update function
		targetPosition = originalPosition - new Vector3 (0, 0, distanceFloat);
		//targetPosition = originalPosition - new Vector3 (0, 0, distanceFloat * 12);
		//distance was multiplied by 12 so I didn't have to walk that far to get the UFO to show up closer

	}

	void Start(){
		//get distance text reference
		//distanceTextObject = GameObject.FindGameObjectWithTag ("distanceText");
		//start GetCoordinate() function 

		distanceTextObject.text = "Start";
		StartCoroutine ("GetCoordinates");
		//initialize target and original position
		targetPosition = transform.position;
		originalPosition = transform.position;

	}

	void Update(){
		//linearly interpolate from current position to target position
		//transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
		//rotate by 1 degree about the y axis every frame
		//transform.eulerAngles += new Vector3 (0, 1f, 0);

	}
}