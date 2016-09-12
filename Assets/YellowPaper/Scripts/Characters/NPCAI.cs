using UnityEngine;
using System.Collections;
using System;

public class NPCAI : MonoBehaviour {

	public NPC character;

	void OnEnable() {
		character.OnCanExit += Exit;
		character.OnCanMoveInQueue += MoveInQueue;
	}

	public void Exit(object sender, EventArgs args) {
		character.MoveToPosition(character.department.GetExitPosition());
	}

	public void MoveInQueue(object sender, PositionArgs args) {
		character.MoveToPosition(args.position);
	}

	void OnDestroy() {
		character.OnCanExit -= Exit;
		character.OnCanMoveInQueue -= MoveInQueue;
	}
}
