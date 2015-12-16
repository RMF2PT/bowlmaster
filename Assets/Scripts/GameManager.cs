using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	private List<int> bowls = new List<int>();
	
	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;
	
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
	public void Bowl (int pinFall) {
		try {
			bowls.Add (pinFall);
			ball.Reset ();

			pinSetter.PerfomAction (ActionMaster.NextAction (bowls));
		} catch {
			Debug.LogWarning ("Something went wrong");
		}

		try {
			scoreDisplay.FillRollCard (bowls);
			scoreDisplay.FillFrames (ScoreMaster.ScoreCumulative(bowls));
		} catch {
			Debug.LogWarning ("Something went wrong in scoredisplay.cs");
		}

	}
}
