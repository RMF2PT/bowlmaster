using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private Ball ball;
	private Vector3 offset;
//	private bool looseBall = false;
//	private float ballPosInYAtGround;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		offset =  transform.position - ball.transform.position;
//		ballPosInYAtGround = (ball.transform.localScale.y / 2);
	}
	
	void Update () {
		if (ball.transform.position.z <= 1600) {
			transform.position = ball.transform.position + offset;
		}
	}
	
//	void FixedUpdate () {
//		if (transform.position.z <= 1600 && !looseBall) {
//			transform.position = ball.transform.position + offset;
//		}
//		
//		if (ball.transform.position.y < ballPosInYAtGround || transform.position.z >= 1600 && !looseBall) {
//			looseBall = true;
//		}
//		
//		float maxCamHeight = 180;
//		if (looseBall) {
//			if (transform.position.y <= maxCamHeight) {
//				offset.y += 1;
//				offset.z *= -1;
//				transform.position += offset * Time.fixedDeltaTime;
//				transform.Rotate(Time.fixedDeltaTime * 20, 0, 0);
//			}
//		}
//		
//		if (!ball.hasLaunched) {
//			ResetCamera();
//		}
//	}
//	
//	void ResetCamera () {
//		transform.position = ball.transform.position + offset;
//	}
}
