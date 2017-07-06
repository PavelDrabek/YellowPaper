using UnityEngine;
using System.Collections;

namespace Data 
{
	public class SpotData : MonoBehaviour 
	{
		public Vector3 Position { get { return transform.position; } set { transform.position = value; } }

		void OnDrawGizmos() 
		{
			Gizmos.color = Color.red;
			Gizmos.DrawCube(transform.position, Vector3.one * 0.2f);
		}
	}
}