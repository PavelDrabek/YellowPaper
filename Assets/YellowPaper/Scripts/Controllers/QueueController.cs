using UnityEngine;
using System.Collections;
using Data;
using System.Collections.Generic;

public class QueueController : MonoBehaviour {

	public QueueData data;
	public List<CharacterController> characters;

	public int PositionsCount { get { return data.spots.Length; } }
	public int TakenPositionsCount { get { return characters.Count; } }
	public int FreePositionsCount { get { return PositionsCount - TakenPositionsCount; } }

	public bool IsFull { get { return TakenPositionsCount == PositionsCount; } }
	public bool IsEmpty { get { return PositionsCount == 0; } }
}
