﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Navigator : MonoBehaviour
{
    public void SlimeScene() {
		SceneManager.LoadScene("SlimeScene");
	}

	public void HelpScene() {
		SceneManager.LoadScene("HelpScene");
	}

	public void InventoryScene() {
		SceneManager.LoadScene("InventoryScene");
	}

	public void ShopScene() {
		SceneManager.LoadScene("ShopScene");
	}

    public void InBattleScene() {
        SceneManager.LoadScene("InBattleScene");
    }

    public void BattleLoseScene() {
        SceneManager.LoadScene("BattleLoseScene");
    }

    public void BattleWinScene() {
        SceneManager.LoadScene("BattleWinScene");
    }
    
	public void Exit() {
		SceneManager.LoadScene("LogoutScene");
	}
	
	public void Quit() {
	#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
	#else
	        Application.Quit();
	#endif
	}
}
