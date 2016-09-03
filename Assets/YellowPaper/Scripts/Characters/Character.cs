using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float speed = 1;
	public Department department;

	private CharacterAnimator animator;
	public Vector2 destination;
	public bool moving = false;

	public Vector2 Position { get { return transform.position.ToVector2(); } private set { transform.position = new Vector3(value.x, value.y, 0); } }


	void Awake() {
		animator = GetComponentInChildren<CharacterAnimator>();
	}

	void Start() {
		UpdateSortLayer();
	}

	public void Exit() {
		MoveToPosition(department.GetExitPosition());
	}

	public void MoveToPosition(Vector2 position) {
		destination = position;
		if(!moving) {
			StartCoroutine(Move());
		}
	}

	private IEnumerator Move() {
		moving = true;
		Vector2 distance;

		Debug.Log("start moving: " + (destination - Position).magnitude + ", speed: " + speed * Time.deltaTime);

		while((distance = (destination - Position)).magnitude > speed * Time.deltaTime) {
			Debug.Log("move");

			Vector2 direction = distance.normalized;
			Position = Position + direction * speed * Time.deltaTime;
			animator.SetDirection(direction);
			UpdateSortLayer();
			yield return null;
		}

		animator.SetDirection(Vector2.zero);

		Debug.Log("stop moving");


		moving = false;
	}

	private void UpdateSortLayer() {
		animator.SetLayerOrder((int)(Position.y * -100));
	}
}
