using UnityEngine;
using System.Collections;
using System;

public class PositionArgs : EventArgs {
	public Vector3 position;
}

public class Character : MonoBehaviour {

	public float speed = 1;
	public Department department;

	private CharacterAnimator animator;
	public Vector2 destination;
	public bool moving = false;

	public Vector2 Position { get { return transform.position.ToVector2(); } private set { transform.position = new Vector3(value.x, value.y, 0); } }

	public event EventHandler<EventArgs> OnCanExit = (sender, e) => {};
	public event EventHandler<PositionArgs> OnCanMoveInQueue = (sender, e) => {};
	public event EventHandler<EventArgs> OnMovingStarted = (sender, e) => {};
	public event EventHandler<EventArgs> OnMovingStopped = (sender, e) => {};
	public event EventHandler<EventArgs> OnMovingChanged = (sender, e) => {};

	void Awake() {
		MyAwake();
	}

	void Start() {
		MyStart();
	}

	virtual protected void MyAwake() {
		animator = GetComponentInChildren<CharacterAnimator>();
	}

	virtual protected void MyStart() {
		UpdateSortLayer();
	}

	public void MoveToPosition(Vector2 position) {
		destination = position;
		if(!moving) {
			StartCoroutine(Move());
		} else {
			OnMovingChanged(this, EventArgs.Empty);
		}
	}

	public void CanExit() {
		OnCanExit(this, EventArgs.Empty);
	}

	public void CanMoveInQueue(Vector3 position) {
		OnCanMoveInQueue(this, new PositionArgs() { position = position });
	}

	private IEnumerator Move() {
		moving = true;
		OnMovingStarted(this, EventArgs.Empty);

		Vector2 distance;
		Debug.Log("start moving: " + (destination - Position).magnitude + ", speed: " + speed * Time.deltaTime);

		while((distance = (destination - Position)).magnitude > speed * Time.deltaTime) {
//			Debug.Log("move");

			Vector2 direction = distance.normalized;
			Position = Position + direction * speed * Time.deltaTime;
			animator.SetDirection(direction);
			UpdateSortLayer();
			yield return null;
		}

		animator.SetDirection(Vector2.zero);

		Debug.Log("stop moving");


		moving = false;
		OnMovingStopped(this, EventArgs.Empty);
	}

	private void UpdateSortLayer() {
		animator.SetLayerOrder((int)(Position.y * -100));
	}
}
