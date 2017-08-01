using UnityEngine;
using System.Collections;

namespace Controls {

	public class PlayerControls : MonoBehaviour {

		public CharacterController Player { get; set; }

		protected virtual void Awake() {
			Player = GetComponent<CharacterController>();
		}
	}
}