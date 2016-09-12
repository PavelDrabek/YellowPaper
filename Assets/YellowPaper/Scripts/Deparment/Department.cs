using UnityEngine;
using System.Collections;

public class Department : MonoBehaviour {

	public Character prefabCharacter;

	public Transform[] exits;
	public PeopleQueue[] queues;

	public float nextPersonTimeMin = 10;
	public float nextPersonTimeMax = 15;

	void Start() {
		StartCoroutine(NewCharacters());
	}

	IEnumerator NewCharacters() {
		while(true) {
			AddCharacterToQueue();
			yield return new WaitForSeconds(Random.Range(nextPersonTimeMin, nextPersonTimeMax));
		}
	}

	public Vector2 GetExitPosition() {
		return exits[Random.Range(0, exits.Length)].position.ToVector2();
	}

	public PeopleQueue GetRandomQueue() {
		return queues[Random.Range(0, queues.Length)];
	}

	public void AddCharacterToQueue() {
		Character c = Instantiate(prefabCharacter, GetExitPosition(), Quaternion.identity) as Character;
		c.department = this;
		GetRandomQueue().AddCharacter(c);
	}
}
