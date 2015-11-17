using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool inPlay = false;
	
	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startPos;
	
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.useGravity = false;
		startPos = transform.position;
	}
	
	public void Launch (Vector3 velocity) {
		inPlay = true;
		
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		Invoke("Reset", (audioSource.clip.length + 3));
	}
	
	public void Reset () {
		inPlay = false;
		transform.position = startPos;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}
}
