using UnityEngine;
using System.Collections;
using Data;

public class CharacterController : MonoBehaviour {

	public NavMeshAgentWithEvents NavMeshAgent { get; private set; }
	public CharacterData CharacterData { get; private set; }

	void Awake() 
	{
		CharacterData = GetComponent<CharacterData>();
		NavMeshAgent = GetComponent<NavMeshAgentWithEvents>();
	}

	void Start() 
	{
		NavMeshAgent.OnDestinationChanged += NavMeshAgent_OnDestinationChanged;
		NavMeshAgent.OnDestinationReached += NavMeshAgent_OnDestinationReached;
	}

	void OnDestroy() {
		NavMeshAgent.OnDestinationChanged -= NavMeshAgent_OnDestinationChanged;
		NavMeshAgent.OnDestinationReached -= NavMeshAgent_OnDestinationReached;
	}

	void NavMeshAgent_OnDestinationReached (object sender, System.EventArgs e)
	{
		Debug.Log("Destination reached");
	}

	void NavMeshAgent_OnDestinationChanged (object sender, System.EventArgs e)
	{
		Debug.Log("Destination changed");
	}

	public void GoToPosition(Vector3 position) 
	{
		NavMeshAgent.Destination = position;
	}
}
