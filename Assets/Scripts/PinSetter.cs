using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	public int lastStandingCount = -1;
	public GameObject pinSet;
	
	private bool ballEnteredBox = false;
	private float lastChangeTime;
	//private Ball ball;
	
	void Start () {
		//ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update () {
		standingDisplay.text = CountStanding().ToString();
		
		if (ballEnteredBox) {
			UpdateStandingCountAndSettle();
		}
	}
	
	void UpdateStandingCountAndSettle () {
		int currentStanding = CountStanding();	
		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time; // Logs the time this check happens
			lastStandingCount = currentStanding;
			return;
		}
		
		float settleTime = 3f; // How long to wait to consider pins settled (3 seconds?)
		if ((Time.time - lastChangeTime) > settleTime) { // If last change happened > settleTime
			PinsHaveSettled ();
		}
	}
	
	void PinsHaveSettled () {
		lastStandingCount = -1; // Indicates pins have settled and ball not in box
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
		//ball.Reset();
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
	
	void OnTriggerEnter (Collider collider) {
		GameObject thingHit = collider.gameObject;
		
		// Ball enters play box
		if (thingHit.GetComponent<Ball>()) {
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}
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
