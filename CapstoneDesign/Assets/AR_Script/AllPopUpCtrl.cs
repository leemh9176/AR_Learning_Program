using UnityEngine;
using System.Collections;

public class AllPopUpCtrl : MonoBehaviour {

	public GameObject RefriPopUp;
	public GameObject TVPopUp;
	public GameObject AirconPopUp;
	public GameObject IronPopUp;
	public GameObject LaundryPopUp;
	public GameObject RadiatorPopUp;
	public GameObject RicePopUp;



	// Use this for initialization
	void Start () {
		RefriPopUp.SetActive (false);
		TVPopUp.SetActive (false);
		AirconPopUp.SetActive (false);
		IronPopUp.SetActive (false);
		LaundryPopUp.SetActive (false);
		RadiatorPopUp.SetActive (false);
		RicePopUp.SetActive (false);
	}

	public void Refpopup(bool refpopactive) {
		RefriPopUp.SetActive (refpopactive);
	}
	public void TVpopup(bool tvpopactive) {
		TVPopUp.SetActive (tvpopactive);
	}
	public void Airconpopup(bool airpopactive) {
		AirconPopUp.SetActive (airpopactive);
	}
	public void Ironpopup(bool ironpopactive) {
		IronPopUp.SetActive (ironpopactive);
	}
	public void Laundrypopup(bool laupopactive) {
		LaundryPopUp.SetActive (laupopactive);
	}
	public void Radiatorpopup(bool radpopactive) {
		RadiatorPopUp.SetActive (radpopactive);
	}
	public void Ricepopup(bool ricpopactive) {
		RicePopUp.SetActive (ricpopactive);
	}


	// Update is called once per frame
	void Update () {

	}
}
