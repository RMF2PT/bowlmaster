using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	public GameObject pinSet;
	
	private Animator animator;
	private PinCounter pinCounter;
	
	private float clipLenght;
	
	void Start () {
		animator = GetComponent<Animator>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
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
	
	public void PerfomAction (ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMaster.Action.EndGame) {
			
			Debug.Log ("END OF GAME!");

			//  TODO erase this code when end of game is coded
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset();
			//throw new UnityException ("Don't know how to handle end of game yet");
		}
	}
	
	public void SetSwiperMovingFalse () {
		pinCounter.swiperIsMoving = false;
	}
}
