using UnityEngine;
using System.Collections;

namespace Data 
{
	public class CharacterData : MonoBehaviour 
	{
		public int id;

		public Vector3 Position { get { return transform.position; } set { transform.position = value; } }

	}
}