using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PeopleQueue : MonoBehaviour {

	private BoxCollider2D trigger;
	private List<Character> characters = new List<Character>();

	public float spaceRadius = 0.5f;
	public float minWaitTime = 0.05f;
	public float maxWaitTime = 0.3f;

	public int Count { get { return characters.Count; } }

	void Awake() {
		trigger = GetComponent<BoxCollider2D>();
		trigger.isTrigger = true;
	}

	public void Next() {
		if(characters.Count <= 0) {
			return;
		}

		characters[0].CanExit();
		characters.RemoveAt(0);

		StartCoroutine(SendNewPositions());
	}

	public void AddCharacter(Character c) {
		if(characters.Contains(c)) {
			return;
		}

		characters.Add(c);
		SendPosition(Count - 1);
	}

	public void SendPosition(int index) {
//		characters[index].MoveToPosition(GetPosition(index));
		characters[index].CanMoveInQueue(GetPosition(index));
	}

	protected virtual Vector2 GetPosition(int index) {
		Vector2 mypos = transform.position.ToVector2();
		return mypos + Vector2.down * trigger.bounds.extents.y + Vector2.up * index * spaceRadius;
	}

	protected IEnumerator SendNewPositions() {
		for (int i = 0; i < characters.Count; i++) {
			SendPosition(i);
			yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
		}
	}
}
