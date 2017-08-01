using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Data 
{
	public class DepartmentData : MonoBehaviour 
	{
		public int id;
		public string name;

		public Transform entryTransform;
		public Vector3 EntryPosition { get { return entryTransform.position; } set { entryTransform.position = value; } }


		public int npcCountMin, npcCountMax;
		public float waitTimeMin, waitTimeMax;
	}

}
