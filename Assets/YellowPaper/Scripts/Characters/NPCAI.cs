using UnityEngine;
using System.Collections;
using System;

public class NPCAI : MonoBehaviour {

	public NPC character;

	void Start() {
		character.OnCanExit += Exit;
	}

	public void Exit(object sender, EventArgs args) {
		character.MoveToPosition(character.department.GetExitPosition());
	}
}
