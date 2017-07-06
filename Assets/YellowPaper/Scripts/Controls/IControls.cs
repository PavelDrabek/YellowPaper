using UnityEngine;
using System.Collections;
using System;

public class MoveEvent : EventArgs {
	public Vector3 MousePosition { get; set; }
	public Vector3 WorldPosition { get; set; }
	public GameObject GameObject { get; set; }
}

public interface IControls {
	
	event EventHandler<MoveEvent> OnClicked;

}
