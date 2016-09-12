using UnityEngine;
using System.Collections;

public class Officer : Character {

	public PeopleQueue queue;
	public float waitTimeMin = 5;
	public float waitTimeMax = 20;
	public float nextCallAt = 0;

	override protected void MyStart() {
		base.MyStart();
		StartCoroutine(Working());
	}

	public void CallNext() {
		queue.Next();
	}

	IEnumerator Working() {
		while(true) {
			if(nextCallAt < Time.realtimeSinceStartup) {
				nextCallAt = Time.realtimeSinceStartup + Random.Range(waitTimeMin, waitTimeMax);
				CallNext();
			}

			yield return null;
		}
	}
}
