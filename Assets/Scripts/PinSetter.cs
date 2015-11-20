using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	public GameObject pinSet;
	public Text standingDisplay;
	
	private int lastStandingCount = -1;
	private int lastSettleCount = 10;
	private bool ballOutOfPlay = false;
	private float lastChangeTime;
	private float clipLenght;
	
	private Ball ball;
	private Animator animator;
	private ActionMaster actionMaster;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		animator = GetComponent<Animator>();
		actionMaster = new ActionMaster();
	}
	
	void Update () {
		standingDisplay.text = CountStanding().ToString();
		
		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle();
			standingDisplay.color = Color.red;
		} else {
			standingDisplay.color = Color.green;
		}
	}
	
	void UpdateStandingCountAndSettle () {
		int currentStanding = CountStanding();	
		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time; // Logs the time this check happens
			lastStandingCount = currentStanding;
			return;
		}
		
		float settleTime = 3f; // How long to wait to consider pins settled (3 seconds)
		if ((Time.time - lastChangeTime) > settleTime) { // If last change happened > settleTime
			PinsHaveSettled ();
		}
	}
	
	void PinsHaveSettled () {
		int standing = CountStanding();
		int pinFall = lastSettleCount - standing;		
		lastSettleCount = standing;
		
		ActionMaster.Action action = actionMaster.Bowl(pinFall);
		Debug.Log ("Pinfall: " + pinFall + " " + action);
		
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			lastSettleCount = 10;
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			lastSettleCount = 10;
		} else if (action == ActionMaster.Action.EndGame) {
			
			//  TODO erase this code
			animator.SetTrigger ("resetTrigger");
			lastSettleCount = 10;
			
			//throw new UnityException ("Don't know how to handle end of game yet");
		}
		
		lastStandingCount = -1; // Indicates pins have settled and ball not in box
		ballOutOfPlay = false;
		
		foreach ( AnimationClip clip in animator.runtimeAnimatorController.animationClips) {
			if (clip.name == "Swipe") {
				clipLenght = clip.length;
			}
		}
		Invoke("BallReset", clipLenght);
	}
	
	void BallReset () {
		ball.Reset();
	}
	
	public void SetBallOutOfPlay () {
		ballOutOfPlay = true;
	}
	
	int CountStanding () {
		int standing = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()) {
				standing++;
			}
		}
		return standing;
	}
	
	public void RaisePins () {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding();
		}
	}
	
	public void LowerPins() {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower();
		}
	}
	
	public void RenewPins() {
		Instantiate(pinSet, new Vector3(0f, 0f, 1829f), Quaternion.identity);
	}
}
