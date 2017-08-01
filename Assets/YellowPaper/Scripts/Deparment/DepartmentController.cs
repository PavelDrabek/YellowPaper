using UnityEngine;
using System.Collections;
using Data;
using System.Collections.Generic;

public class DepartmentController : MonoBehaviour {

	public DepartmentData data;
	public CounterController[] counters;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void CheckCounter(CounterController counter) {
		if(counter.queue.TakenPositionsCount < data.npcCountMin) {
			SpawnNewNPC();
		}
	}

	private void SpawnNewNPC() 
	{
		var npc = CharacterFactory.CreateNPC();
		npc.transform.position = data.EntryPosition;

	}
}
