using UnityEngine;
using System.Collections;

public class CrookedQueue : PeopleQueue {

	public float power;

	protected override Vector2 GetPosition (int index)
	{
		return base.GetPosition(index) + Random.insideUnitCircle * power;
	}
}
