using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour, IControls {

	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			GameObject go = null;
			Vector3 position = GetClickedPosition(Input.mousePosition, out go);

			if(OnClicked != null) {
				OnClicked(this, new MoveEvent() { MousePosition = Input.mousePosition, WorldPosition = position, GameObject = go });
			}
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

	#region IController implementation

	public event System.EventHandler<MoveEvent> OnClicked;

	#endregion
}
