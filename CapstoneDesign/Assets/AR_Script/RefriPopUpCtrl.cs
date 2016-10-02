using UnityEngine;
using System.Collections;

public class RefriPopUpCtrl : MonoBehaviour {

	public GameObject Refripopup;

	// Use this for initialization
	void Start () {
		Refripopup.SetActive (false);
	}

	public void REFRIactive(bool refpopactive) {
		Refripopup.SetActive (refpopactive);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
