using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	void Start () {
		InitializeScoresTexts();
	}

	void Update () {
	
	}

	void InitializeScoresTexts () {
		for (int i = 0; i < 21; i++) {
			rollTexts[i].text = "10";
		}

		for (int i = 0; i < 10; i++) {
			frameTexts[i].text = "300";
		}
	}

	public void FillRollCard (List<int> rolls) {
		rolls [-1] = 1;
	}
}
