using UnityEngine;
using System.Collections;

public class TestController : MonoBehaviour {

	public Department department;

	public PeopleQueue queue;
	public Character prefabCharacter;

	public Transform spawnPoint;
	public Officer officer;

	public bool addCharacterToQueue = false;
	public bool callNext = false;

	// Update is called once per frame
	void Update () {
		if(addCharacterToQueue) {
			addCharacterToQueue = false;
			Character c = Instantiate(prefabCharacter, spawnPoint.position, Quaternion.identity) as Character;
			c.department = department;
			queue.AddCharacter(c);
		}

		if(callNext) {
			callNext = false;
			queue.Next();
		}
	}
}
