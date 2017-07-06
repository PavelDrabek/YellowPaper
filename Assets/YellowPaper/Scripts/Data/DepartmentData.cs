using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Data 
{
	public class DepartmentData : MonoBehaviour 
	{
		public int id;
		public string name;
		public CounterData[] counters;
		public List<CharacterData> characters;

		public int npcCountMin, npcCountMax;
		public float waitTimeMin, waitTimeMax;
	}

}
