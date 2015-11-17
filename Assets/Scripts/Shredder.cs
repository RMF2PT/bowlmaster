using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerExit (Collider collider) {
		GameObject thingLeft = collider.gameObject;
		
		// Pin exits play box
		if (thingLeft.GetComponent<Pin>()) {
			Destroy(thingLeft);
		}
	}
}
