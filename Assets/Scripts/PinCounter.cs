using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
	public Text standingDisplay;
	public bool swiperIsMoving = false;
	
	private int lastStandingCount = -1;
	private int lastSettleCount = 10;
	private bool ballOutOfPlay = false;
	private float lastChangeTime;
	
	private GameManager gameManager;
	
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
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
	
	public void Reset () {
		lastSettleCount = 10;
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
		
		gameManager.Bowl (pinFall);
		
		// Indicates pins have settled and ball not in box
		lastStandingCount = -1; 
		ballOutOfPlay = false;
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
	
	void OnTriggerExit (Collider collider) {
		GameObject thingLeft = collider.gameObject;
		
		// Ball exits lane box
		if (thingLeft.GetComponent<Ball>()) {
			swiperIsMoving = true;
			ballOutOfPlay = true;
		}
	}
}
