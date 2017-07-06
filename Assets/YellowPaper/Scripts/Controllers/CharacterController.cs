using UnityEngine;
using System.Collections;
using Data;

public class CharacterController : MonoBehaviour {

	public NavMeshAgent NavMeshAgent { get; private set; }
	public CharacterData CharacterData { get; private set; }
	public IControls Controller { get; private set; }

	void Awake() {
		CharacterData = GetComponent<CharacterData>();
		Controller = GetComponent<IControls>();
		NavMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Start() {
		Controller.OnClicked += Controller_OnMove;		
	}

	void Controller_OnMove (object sender, MoveEvent e)
	{
		NavMeshAgent.destination = e.WorldPosition;
	}
}
