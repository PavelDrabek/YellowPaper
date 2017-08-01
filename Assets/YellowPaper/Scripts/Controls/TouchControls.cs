using UnityEngine;
using System.Collections;

namespace Controls {

	public class TouchControls : PlayerControls {

		void Update () {
			if(Input.GetMouseButtonDown(0)) {
				GameObject go = null;
				Vector3 position = GetClickedPosition(Input.mousePosition, out go);

				Player.GoToPosition(position);
				//OnClicked(this, new MoveEvent() { MousePosition = Input.mousePosition, WorldPosition = position, GameObject = go });
			}
		}

		private Vector3 GetClickedPosition(Vector3 mousePosition, out GameObject go) {
			RaycastHit hit; 
			go = null;
			Ray ray = Camera.main.ScreenPointToRay(mousePosition); 
			if (Physics.Raycast (ray, out hit)) {
				go = hit.transform.gameObject;
			}
			return hit.point;
		}
	}
}