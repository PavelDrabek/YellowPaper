using UnityEngine;
using System.Collections;

public class CharacterFactory {

	public static CharacterController CreateNPC() {
		GameObject prefab = Resources.Load("NPC") as GameObject;
		CharacterController character = GameObject.Instantiate(prefab).GetComponent<CharacterController>();

		return character;
	}

}
