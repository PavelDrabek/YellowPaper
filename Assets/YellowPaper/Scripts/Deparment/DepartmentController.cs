using UnityEngine;
using System.Collections;
using Data;

public class DepartmentController : MonoBehaviour {

	public DepartmentData data;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnNewNPC() {
		GameObject go = Resources.Load("NPC") as GameObject;
	}
}
