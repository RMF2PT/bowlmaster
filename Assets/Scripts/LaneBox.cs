using UnityEngine;
using System.Collections;

public class LaneBox : MonoBehaviour {

	private PinSetter pinSetter;
	
	void OnTriggerExit (Collider collider) {
		GameObject thingLeft = collider.gameObject;
		
		// Ball exits lane box
		if (thingLeft.GetComponent<Ball>()) {
			pinSetter = GameObject.FindObjectOfType<PinSetter>();
			pinSetter.SetBallOutOfPlay();
		}
	}
}
