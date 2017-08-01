using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentWithEvents : MonoBehaviour 
{
	public NavMeshAgent Agent { get; private set; }

	public event EventHandler<EventArgs> OnDestinationReached;
	public event EventHandler<EventArgs> OnDestinationChanged;

	private Coroutine checkReach;

	void Awake() 
	{
		Agent = GetComponent<NavMeshAgent>();
		checkReach = null;
	}

	public Vector3 Destination {
		get { return Agent.destination; }
		set { 
			Agent.SetDestination(value); 
			if (checkReach == null) { 
				checkReach = StartCoroutine(CheckReach());
			} else {
				if(OnDestinationChanged != null) {
					OnDestinationChanged(this, EventArgs.Empty);
				}
			} 
		}
	}

	private IEnumerator CheckReach() {
		while (true) {
			if (!Agent.pathPending) {
				if (Agent.remainingDistance <= Agent.stoppingDistance) {
					if (Agent.hasPath || Agent.velocity.sqrMagnitude == 0f) {
						if (OnDestinationReached != null) {
							OnDestinationReached(this, EventArgs.Empty);
						}
						break;
					}
				}
			}
			yield return null;
		}

		checkReach = null;
	}
}
