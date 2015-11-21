using UnityEngine;
using System.Collections;

public class FingerExample : MonoBehaviour {

	private Animator animator;
	private float clipLenght;
	private Vector3 StartPos;
	private Ball ball;
	
	void Start () {
		animator = GetComponent<Animator>();
		gameObject.SetActive (false);
		StartPos = transform.position;
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	public void LaunchFingerAnimation () {
		gameObject.SetActive (true);
		animator.SetTrigger("LaunchExampleTrigger");
		Invoke("ResetAnimation", 2f);
	}
	
	private void ResetAnimation () {
		transform.position = StartPos;
		gameObject.SetActive (false);
		ball.inPlay = false;
	}
}
