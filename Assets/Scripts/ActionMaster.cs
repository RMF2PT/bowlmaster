using UnityEngine;
using System.Collections;

public class ActionMaster {
	
	public enum Action {Reset, Tidy, EndTurn, EndGame};
	
	private int[] bowlScore = new int[22];
	private int bowl = 1;
	
	public Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {throw new UnityException ("Invalid pins count");}
		
		bowlScore[bowl] = pins;
		
		// Last frame
		if (bowl == 21) {
			return Action.EndGame;
		}
		
		// Strike at bowl 19
		if (bowl == 19 && bowlScore[19] == 10) {
			bowl++;
			return Action.Reset;
		}
		
		if (bowl == 20) {
			if ((bowlScore[19] + bowlScore[20]) < 10) { 	// Not strike nor spare at bowl 20
				return Action.EndGame;
			}  else if (bowlScore[19] == 10 && bowlScore[20] < 10) {	// Strike at bowl 19 and not strike at bowl 20
				bowl++;
				return Action.Tidy;
			}  else if ((bowlScore[19] + bowlScore[20]) == 10 || bowlScore[20] == 10) {	// Spare or strike at bowl 20
				bowl++;
				return Action.Reset;
			}  
		}
		
		if (pins == 10) {
			bowl += 2;
			return Action.EndTurn;
		}
		
		if (bowl % 2 != 0) { // Midle of frame (or last frame)
			bowl++;
			return Action.Tidy;
		}  else if (bowl % 2 == 0) { // End of frame
			bowl++;
			return Action.EndTurn;
		}
		
		throw new UnityException ("Not sure what action to return");
	}
}

