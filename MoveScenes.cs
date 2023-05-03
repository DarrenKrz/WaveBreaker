using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{
	public void MoveToScene(int sceneID) {
		Debug.Log("changed scenes");
		SceneManager.LoadScene(sceneID);
	}
}
