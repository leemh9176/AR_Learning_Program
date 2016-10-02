using UnityEngine;
using System.Collections;

public class ManualCtrl : MonoBehaviour {

	//Manual 시작 버튼
	public void StartTestBtn() {
		Application.LoadLevel ("CapstoneDesign");
		Application.LoadLevelAdditive ("Interface");
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
