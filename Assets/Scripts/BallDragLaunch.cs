using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private float launchSpeedLimit = 1000f;
	private PinCounter pinCounter;
	
	void Start () {
		ball = GetComponent<Ball>();
		pinCounter = FindObjectOfType<PinCounter>();
	}
	
	public void MoveRightAtStart (float xNudge) {
		if (!ball.inPlay && ball.transform.position.x < 49) {
			ball.transform.Translate (xNudge, 0, 0, Space.World);
		}
	}
	
	public void MoveLeftAtStart (float xNudge) {
		if (!ball.inPlay && ball.transform.position.x > -49) {
			ball.transform.Translate (xNudge, 0, 0, Space.World);
		}
	}
	
	public void DragStart () {
		// Capture time & position of the drag start
		if (!ball.inPlay && !pinCounter.swiperIsMoving) {
			startTime = Time.time;
			dragStart = Input.mousePosition;
		}
	}
	
	public void DragEnd () {
		// Launch the ball
		if (!ball.inPlay && !pinCounter.swiperIsMoving) {
			endTime = Time.time;
			dragEnd = Input.mousePosition;
			
			float dragDuration = endTime - startTime;
			
			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
			
			if (launchSpeedZ < 0) {							// Avoids backwards launchs
				ball.inPlay = true;
				Invoke("ResetBallWithExample", 1);
			} else if (launchSpeedZ >= launchSpeedLimit) { 	// Limits the ball speed
				launchSpeedZ = launchSpeedLimit;
				Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
				ball.Launch(launchVelocity);
			} else {										// Normal launch
				Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
				ball.Launch(launchVelocity);
			}
		}
	}
	
	public void TestLaunch () {
		if (!ball.inPlay && !pinCounter.swiperIsMoving) {
			ball.Launch(new Vector3(3, 0, 750));
		}
	}
	
	void ResetBallWithExample () {
		ball.ResetWithExample();
	}
	
}
