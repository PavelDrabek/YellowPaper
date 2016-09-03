using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour
{

	private Animator animator;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake()
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
//	void Update()
//	{
//		Vector2 direction;
//		direction.x = Input.GetAxisRaw("Horizontal");
//		direction.y = Input.GetAxisRaw("Vertical");
//		direction.Normalize();
//
//		SetDirection(direction);
//	}

	public void SetLayerOrder(int order) {
		spriteRenderer.sortingOrder = order;
	}

	public void SetDirection(Vector2 direction) {
		animator.SetFloat("X", Mathf.Round(direction.x));
		animator.SetFloat("Y", Mathf.Round(direction.y));
		animator.SetBool("walk", direction.sqrMagnitude > 0);
	}
}
