using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingTreshold = 3f;
	public float distanceToRaise = 40f;
	
	private AudioSource audioSource;
	private Rigidbody rigidBody;
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody>();
	}
	
	void OnCollisionEnter () {
		audioSource.Play();
	}
	
	public bool IsStanding () {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		// Pins start with 0, but rest at x = 359.977, y = 0.008905 and z = 0.01333
		float tiltInX;
		if (transform.rotation.eulerAngles.x > 359f) {
			tiltInX = Mathf.Abs(359f - rotationInEuler.x);
		} else {
			tiltInX = Mathf.Abs(0f - rotationInEuler.x);
		}

		float tiltInZ = Mathf.Abs(0f - rotationInEuler.z);
		if (tiltInX < standingTreshold && tiltInZ < standingTreshold) {
			return true;
		} else {
		 	return false;
		}
	}
	
	public void RaiseIfStanding() {
		// Raise standing pins only by distanceToRaise
		if (IsStanding()) {
			rigidBody.useGravity = false;
			CorretPinRotation();
			transform.Translate (new Vector3 (0, distanceToRaise, 0), Space.World);
		}
	}

	public void Lower() {
		rigidBody.useGravity = true;
		Invoke("CorretPinRotation", 1);
	}
	
	void CorretPinRotation () {
		transform.rotation = Quaternion.Euler (0, 0, 0);
	}
}
