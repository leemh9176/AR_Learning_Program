using UnityEngine;
using System.Collections;

public class InterfaceCtrl : MonoBehaviour {
	public GameObject AirObj;
	public GameObject MicObj;
	public GameObject RefObj;
	public GameObject TVObj;
	public GameObject LauObj;
	public GameObject RadObj;
	public GameObject RicObj;
	public GameObject IronObj;
	public GameObject ElecObj;
	public GameObject TotObj;
	public GameObject TempLbl;
	public GameObject[] InformMakers = new GameObject[6];
	public GameObject LawImage;
	public GameObject LawEX;
	public GameObject ElecShow;
	public GameObject ElecPerHour;



	// Use this for initialization
	void Start () {
		TVObj.SetActive (false);
		AirObj.SetActive (false);
		MicObj.SetActive (false);
		RefObj.SetActive (false);
		LauObj.SetActive (false);
		RadObj.SetActive (false);
		RicObj.SetActive (false);
		IronObj.SetActive (false);
		ElecObj.SetActive (false);
		TotObj.SetActive (true);
		TempLbl.SetActive (true);
		LawImage.SetActive (false);
		LawEX.SetActive (false);
		ElecShow.SetActive (false);
		ElecPerHour.SetActive (false);
		for (int i = 0; i < InformMakers.Length; i++) {
			InformMakers[i].SetActive(false);
		}
	}
	public void activeTV(bool TVactive) {
		TVObj.SetActive (TVactive);
	}
	public void activeAir(bool Airactive) {
		AirObj.SetActive (Airactive);
	}
	public void activeMic(bool Micactive) {
		MicObj.SetActive (Micactive);
	}
	public void activeRef(bool Refactive) {
		RefObj.SetActive (Refactive);
	}
	public void activeLau(bool Lauactive) {
		LauObj.SetActive (Lauactive);
	}
	public void activeRad(bool Radactive) {
		RadObj.SetActive (Radactive);
	}
	public void activeRic(bool Ricactive) {
		RicObj.SetActive (Ricactive);
	}
	public void activeIron(bool Ironactive) {
		IronObj.SetActive (Ironactive);
	}
	public void activeElec(bool Elecactive) {
		ElecObj.SetActive (Elecactive);
	}
	public void activeTot(bool Totactive) {
		TotObj.SetActive (Totactive);
	}
	public void activeM0(bool Mactive) {
		InformMakers [0].SetActive (Mactive);
	}
	public void activeM1(bool Mactive) {
		InformMakers [1].SetActive (Mactive);
	}
	public void activeM2(bool Mactive) {
		InformMakers [2].SetActive (Mactive);
	}
	public void activeM3(bool Mactive) {
		InformMakers [3].SetActive (Mactive);
	}
	public void activeM4(bool Mactive) {
		InformMakers [4].SetActive (Mactive);
	}
	public void activeM5(bool Mactive) {
		InformMakers [5].SetActive (Mactive);
	}
	public void activeLaw(bool Lawactive) {
		LawImage.SetActive (Lawactive);
	}
	public void activeTemp (bool Tempactive) {
		TempLbl.SetActive (Tempactive);
	}
	public void activeEX (bool EXactive) {
		LawEX.SetActive (EXactive);
	}
	public void activeShow (bool Showactive) {
		ElecShow.SetActive (Showactive);
	}
	public void activeEPH (bool EPHactive) {
		ElecPerHour.SetActive (EPHactive);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
