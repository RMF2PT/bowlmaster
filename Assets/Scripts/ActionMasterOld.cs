using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMasterOld {
	public enum Action {Reset, Tidy, EndTurn, EndGame};
	
	private int[] bowlScore = new int[22];
	private int bowl = 1;
	
	public static Action NextAction (List<int> pinFalls) {
		ActionMasterOld am = new ActionMasterOld();
		Action currentAction = new Action();
		
		foreach (int pinFall in pinFalls) {
			currentAction = am.Bowl(pinFall);
		}
		
		return currentAction;
	}
	
	private Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {
			Debug.LogWarning (pins);
			throw new UnityException ("Invalid pins count");
		}
		
		bowlScore[bowl] = pins;
		
		// Last Frame
		if (bowl == 21) {
			return Action.EndGame;
		}
		
		if (bowl == 20) {
		 	if (bowlScore[19] == 10 && bowlScore[20] < 10) {	// Strike at bowl 19 and not strike at bowl 20
				bowl++;
				return Action.Tidy;
			}  else if ((bowlScore[19] + bowlScore[20]) == 10 || bowlScore[20] == 10) {	// Spare or strike at bowl 20
				bowl++;
				return Action.Reset;
			}  else {
				return Action.EndGame;
			}
		}
		
		if (bowl == 19 && bowlScore[19] == 10) {		// Strike at bowl 19
			bowl++;
			return Action.Reset;
		}
		
		// First Bowl of frames
		if (bowl % 2 != 0) { 
			if (pins == 10) {
				bowl += 2;
				return Action.EndTurn;
			} else {
				bowl++;
				return Action.Tidy;
			}
		// Second Bowl of frames	
		}  else if (bowl % 2 == 0) { 
			bowl++;
			return Action.EndTurn;
		}
		
		throw new UnityException ("Not sure what action to return");
	}
}

