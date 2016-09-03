using UnityEngine;
using System.Collections;

public class Officer : Character {

	public PeopleQueue queue;

	public void CallNext() {
		queue.Next();
	}
}
