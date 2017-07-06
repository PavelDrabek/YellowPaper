﻿using UnityEngine;
using System.Collections;

public class GameData
{
	private static GameData instance;
	public static GameData Instance { 
		get { 
			if(instance == null) {
				instance = new GameData();
			}	
			return instance;
		}
	}

	public IControls Controller;
}
