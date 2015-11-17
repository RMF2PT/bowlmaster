using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	
	void Start () {
		ball = GetComponent<Ball>();
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
		startTime = Time.time;
		dragStart = Input.mousePosition;
	}
	
	public void DragEnd () {
		// Launch the ball
		if (!ball.inPlay) {
			endTime = Time.time;
			dragEnd = Input.mousePosition;
			
			float dragDuration = endTime - startTime;
			
			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
			// Limits the ball speed by 800
			if (launchSpeedZ >= 800) {
				launchSpeedZ = 800;
			}
			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
			ball.Launch(launchVelocity);
		}
	}
	
	public void TestLaunch () {
		if (!ball.inPlay) {
			ball.Launch(new Vector3(3, 0, 750));
		}
	}
	
}
