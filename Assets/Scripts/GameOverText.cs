using UnityEngine;
using System.Collections;

public class GameOverText : MonoBehaviour {
	
	void Start () {
		gameObject.SetActive (false);
	}
	
	public void Activate () {
		gameObject.SetActive (true);
	}
	
	public void Inactivate () {
		gameObject.SetActive (false);
		Debug.Log ("starting a new game");
	}
}
