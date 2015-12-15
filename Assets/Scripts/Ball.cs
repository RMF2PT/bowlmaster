using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public float velocityLowerLimit = 300;
	public bool inPlay = false;
	
	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startPos;
	public FingerExample fingerExample;
	
	void Awake () {
		fingerExample = (FingerExample) FindObjectOfType (typeof(FingerExample));
	}
	
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
		if (velocity.z <= velocityLowerLimit) {
			Invoke ("ResetWithExample", 1);
		}
	}

	void StartBallPosition ()
	{
		transform.position = startPos;
		transform.rotation = Quaternion.Euler (3, -236, 67);
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}
	
	public void Reset () {
		inPlay = false;
		StartBallPosition ();
	}
	
	public void ResetWithExample () {
		fingerExample.LaunchFingerAnimation();
		StartBallPosition ();
	}
}
