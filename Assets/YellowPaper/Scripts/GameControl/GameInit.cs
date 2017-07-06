using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

	void Awake() {
		Init();
	}

	void Init() 
	{
		DontDestroyOnLoad(gameObject);
		GameData.Instance.Controller = gameObject.GetComponent<IControls>();
	}
}
