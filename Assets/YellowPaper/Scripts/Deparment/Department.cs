using UnityEngine;
using System.Collections;

public class Department : MonoBehaviour {

	public Transform[] exits;

	public Vector2 GetExitPosition() {
		return exits[Random.Range(0, exits.Length)].position.ToVector2();
	}
}
