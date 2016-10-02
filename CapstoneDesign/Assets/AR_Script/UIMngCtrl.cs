using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMngCtrl : MonoBehaviour {
	public GameObject TVdisplay;
	public GameObject AIRdisplay;
	public GameObject MICdisplay;
	public GameObject REFdisplay;
	public GameObject LAUdisplay;
	public GameObject RADdisplay;
	public GameObject RICdisplay;
	public GameObject IRONdisplay;
	int TVCountBtn;
	int AIRCountBtn;
	int MICCountBtn;
	int REFCountBtn;
	int LAUCountBtn;
	int RADCountBtn;
	int RICCountBtn;
	int IRONCountBtn;
	int TVpopCountBtn;
	int AIRpopCountBtn;
	int MICpopCountBtn;
	int REFpopCountBtn;
	int LAUpopCountBtn;
	int RADpopCountBtn;
	int RICpopCountBtn;
	int IRONpopCountBtn;
	bool TVactive;
	bool AIRactive;
	bool MICactive;
	bool REFactive;
	bool LAUactive;
	bool RADactive;
	bool RICactive;
	bool IRONactive;
//	int telec = 0;
	public Text txtTotelec;
	public Text txtTotCost;
	public Text txtTotTime;
	public Text txtShadeTemp;
	public Text txtAIRTemp1;
	public Text txtAIRTemp2;
	public Text txtCostText;
	public Text txtElecShow;
	float tvkw = 0.15f / 240.0f;	//TV의 초당 전력(kW)
	float airkw = 1.85f / 240.0f;
	float mickw = 1.0f / 240.0f;
	float refkw = 0.15f / 240.0f; 
	float laukw = 0.5f / 240.0f;
	float radkw = 2.0f / 240.0f;
	float rickw = 0.1f / 240.0f;
	float ironkw = 1.0f / 240.0f;
	float tvelec = 0.0f;			//TV의 총 사용 전력량
	float airelec = 0.0f;
	float micelec = 0.0f;
	float refelec = 0.0f;
	float lauelec = 0.0f;
	float radelec = 0.0f;
	float ricelec = 0.0f;
	float ironelec = 0.0f;
//	float tvcost = 0.0f;
//	float aircost = 0.0f;
//	float miccost = 0.0f;
//	float refcost = 0.0f;
//	float laucost = 0.0f;
	private UIMngCtrl UIMng;
	float totelecEnergy1 = 0.0f;
	float totelecEnergy2 = 0.0f;
	float Cost = 0.0f;
	float BasicCost = 0.0f;			//기본 사용 요금
	float VAT = 0.1f;				//부가세
	float ElecIndustryCost = 0.037f;
	float totCost = 0.0f;
	public float TimeCtrl = 0.1f;
	int Tothour = 0;				//총 사용 시간
	int Totmin = 0;					//총 사용 분
	int Totsec = 0;					//총 사용 초
	int thour;
	int tmin;
	int tsec;
	int airTemp = 25;
	int ShadeTemp;
	public Transform airCap;
	public float moveSpeed = 0.0f;
	private RefriPopUpCtrl RefriPop;
//	private Animator _animator;
	public Transform LeftPoint;
	public Transform RightPoint;
	public GameObject LeftDoor;
	public GameObject RightDoor;
	public GameObject laundrycover;
	public GameObject laundryroll;
	public Transform laurotpoint;
	int lauCount1 = 1;
	int lauCount2 = 0;
	bool laubool1 = true;
	bool laubool2 = false;
	bool laubool3 = false;
	public GameObject[] radWings = new GameObject[9];
	bool radbool1 = true;
	bool radbool2 = false;
	public Transform ricepoint;
	public GameObject ricetop;
	bool ricbool1 = true;
	bool ricbool2 = false;
	public GameObject Iron;
	bool ironbool1 = true;
	bool ironbool2 = false;
	bool ironbool3 = false;
	private AllPopUpCtrl AllPopUp;
	public GameObject[] Pointers = new GameObject[7];
	bool movebool1 = true;
	bool movebool2 = false;
	public float PointerSpeed = 0.2f;
	private InterfaceCtrl ElecInform;
	int informCountBtn = 1;
	//public GameObject[] InformMakers = new GameObject[6];


	//TV 상호작용
	public void TVOnBtn() {
		Debug.Log ("Click Button");
		TVCountBtn++;
		Debug.Log (TVCountBtn);
		if (TVCountBtn % 2 != 0) {
			TVactive = true;
			StartCoroutine (this.TVDisplay ());
			StartCoroutine (this.TVelec ());
			//StartCoroutine (this.TVcost ());
			//StartCoroutine (this.TotTime ());
		} else {
			TVactive = false;
		}
	}
	public void TVPopUpBtn() {
		TVpopCountBtn++;
		if (TVpopCountBtn % 2 != 0) {
			AllPopUp.TVpopup (true);
		} else {
			AllPopUp.TVpopup (false);
		}
	}
	//TV화면
	IEnumerator TVDisplay() {
		while (TVactive) {
			yield return null;
			TVdisplay.renderer.material.color = Color.red;
			Pointers[0].renderer.material.color = Color.red;
			//tvpower = true;
			if(TVactive == false) {
				TVdisplay.renderer.material.color = Color.black;
				Pointers[0].renderer.material.color = Color.blue;
			}
		}
	}
	//TV전력량
	IEnumerator TVelec() {
		while (TVactive && Tothour < 24.0f) {
			yield return new WaitForSeconds(TimeCtrl);
			tvelec += tvkw;
			Debug.Log(tvelec + "----------------------");
			//UIMng.TotalElectronic(tvelec);
		}
	}


	//에어컨 상호작용
	public void AIROnBtn() {
		//Debug.Log ("Click Button");
		AIRCountBtn++;
		//Debug.Log (AIRCountBtn);
		if (AIRCountBtn % 2 != 0) {
			AIRactive = true;
			RADactive = false;
			StartCoroutine (this.AIRDisplay ());
			StartCoroutine (this.AIRelec ());
			StartCoroutine (this.AIRTemper());
		} else {
			AIRactive = false;
		}
	}
	public void AIRPopUpBtn() {
		AIRpopCountBtn++;
		if (AIRpopCountBtn % 2 != 0) {
			AllPopUp.Airconpopup (true);
		} else {
			AllPopUp.Airconpopup (false);
		}
	}
	//에어컨 화면과 덮개 움직임
	IEnumerator AIRDisplay() {
		while (AIRactive) {
			yield return null;
			AIRdisplay.renderer.material.color = Color.green;
			Pointers[6].renderer.material.color = Color.red;
			if(airCap.localPosition.y > 138.0f)
				airCap.Translate (Vector3.back * moveSpeed * Time.deltaTime);

			if(AIRactive == false) {
				AIRdisplay.renderer.material.color = Color.black;
				Pointers[6].renderer.material.color = Color.blue;
			}
		}
		while (AIRactive == false) {
			yield return null;
			if(airCap.localPosition.y < 163.07f)
				airCap.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
	}
	//에어컨 전력량
	IEnumerator AIRelec() {
		while (AIRactive&& Tothour < 24.0f) {
			yield return new WaitForSeconds (TimeCtrl);
			airelec += airkw;
			if (ShadeTemp != airTemp)
				airelec += (airkw * 1.1f);
		}
	}
	IEnumerator AIRTemper() {	//5초 간격으로 온도 변화
		while (AIRactive || RADactive) {
			yield return new WaitForSeconds(5.0f);
			if(ShadeTemp > airTemp) {
				ShadeTemp--;
				txtShadeTemp.text = "현재 온도 : " + ShadeTemp;
			}
			else if(ShadeTemp < airTemp) {
				ShadeTemp++;
				txtShadeTemp.text = "현재 온도 : " + ShadeTemp;
			}
			else {
				ShadeTemp = airTemp;
				txtShadeTemp.text = "현재 온도 : " + ShadeTemp;
			}
		}
	}
	//에어컨 온도 상승
	public void AIRTempUp() {
		airTemp++;
		txtAIRTemp1.text = "희망 온도 : " + airTemp;
		txtAIRTemp2.text = "희망 온도 : " + airTemp;
	}
	//에어컨 온도 하강
	public void AIRTempDown() {
		airTemp--;
		txtAIRTemp1.text = "희망 온도 : " + airTemp;
		txtAIRTemp2.text = "희망 온도 : " + airTemp;
	}

	//전자렌지상호작용
	public void MICOnBtn() {
		Debug.Log ("Click Button");
		MICCountBtn++;
		Debug.Log (MICCountBtn);
		if (MICCountBtn % 2 != 0) {
			MICactive = true;
			StartCoroutine (this.MICDisplay ());
			StartCoroutine (this.MICelec ());
		} else {
			MICactive = false;
		}
	}
	//전자렌지 화면
	IEnumerator MICDisplay() {
		while (MICactive) {
			yield return null;
			MICdisplay.renderer.material.color = Color.yellow;
			if(MICactive == false)
				MICdisplay.renderer.material.color = Color.clear;
		}
	}
	//전자렌지 전력량
	IEnumerator MICelec() {
		while (MICactive&& Tothour < 24.0f) {
			yield return new WaitForSeconds(Time.deltaTime);
			micelec += mickw;
		}
	}

	//냉장고 상호작용
	public void REFInfoBtn() {
		Debug.Log ("Click Button");
		REFCountBtn++;
		Debug.Log (REFCountBtn);
		if (REFCountBtn % 2 != 0) {
			REFactive = true;
			StartCoroutine (this.REFDisplay ());
		} else {
			REFactive = false;
		}
	}
	//냉장고 화면
	IEnumerator REFDisplay() {
		while (REFactive) {
			yield return null;
			AllPopUp.Refpopup(true);
			REFdisplay.renderer.material.color = Color.yellow;
			Pointers[5].renderer.material.color = Color.red;
			//_animator.SetBool ("IsActive", true);
			if(LeftDoor.transform.localPosition.z > -36) {
				LeftDoor.transform.RotateAround(LeftPoint.position,Vector3.up,moveSpeed*90*Time.deltaTime);
				RightDoor.transform.RotateAround(RightPoint.position,Vector3.down, moveSpeed*90*Time.deltaTime);
			}
			if (REFactive == false) {
				//REFactive = false;
				AllPopUp.Refpopup(false);
				REFdisplay.renderer.material.color = Color.clear;
				Pointers[5].renderer.material.color = Color.blue;
				//_animator.SetBool ("IsActive", false);
			}
		}
		while (REFactive == false) {
			yield return null;
			if(LeftDoor.transform.localPosition.z < -21) {
				LeftDoor.transform.RotateAround(LeftPoint.position,Vector3.down,moveSpeed*90*Time.deltaTime);
				RightDoor.transform.RotateAround(RightPoint.position,Vector3.up, moveSpeed*90*Time.deltaTime);
			}
		}
	}
	//냉장고 전력량
	IEnumerator REFelec() {
		//yield return null;	
		yield return new WaitForSeconds (TimeCtrl);
		//refelec += refkw;
		if (REFactive == true && Tothour < 24.0f) {
			refelec += (refkw * 1.1f);
		} else {
			refelec += refkw;
		}

	}

	//세탁기 상호작용
	public void LaundryOnBtn() {	//세탁기 On/Off 버튼 인식
		LAUCountBtn++;
		Debug.Log (LAUCountBtn);
		if (LAUCountBtn % 2 != 0) {
			LAUactive = true;
			StartCoroutine (this.LAUDisplay ());//세탁기 작동 구현
			StartCoroutine (this.LAUelec ());	//세탁기 전력량 누적
		} else {
			LAUactive = false;
		}
	}
	public void LAUPopUpBtn() {		//세탁기 팝업 active
		LAUpopCountBtn++;
		if (LAUpopCountBtn % 2 != 0) {
			AllPopUp.Laundrypopup (true);
		} else {
			AllPopUp.Laundrypopup (false);
		}
	}
	//세탁기 작동 구현
	IEnumerator LAUDisplay() {
		while (LAUactive) {
			yield return null;
			LAUdisplay.renderer.material.color = Color.green;	//디스플레이 색 변환
			Pointers[1].renderer.material.color = Color.red;	//표시포인터 색 변환
			//해당 조건까지 기준점을 중심으로 세탁기 커버 움직임 구현 - 커버 열림
			if (laubool1 == true && laundrycover.transform.localPosition.x < -1) {
				laundrycover.transform.RotateAround (laurotpoint.position
				               , Vector3.up, moveSpeed * 60 * Time.deltaTime);
			} else {
				laubool1 = false;	//다음 동작으로 이어지게 하는 bool 변수
				break;
			}
		}
		while (!laubool1 && LAUactive) {
			yield return null;
			//커버 닫힘
			if (laundrycover.transform.localPosition.x > -11.145f) {
				laundrycover.transform.RotateAround (laurotpoint.position
				                , Vector3.down, moveSpeed * 60 * Time.deltaTime);
			} 
			//커버가 닫힌 후 드럼 통 회전
			else
				laundryroll.transform.Rotate (Vector3.forward * 700 * Time.deltaTime);
		}
		if (LAUactive == false) {	//종료 버튼 클릭시 디스플레이, 표시포인터 원상복구
			LAUdisplay.renderer.material.color = Color.black;
			Pointers[1].renderer.material.color = Color.blue;
			laubool1 = true;
		}		
	}
	//세탁기 전력량
	IEnumerator LAUelec() {
		while (LAUactive && Tothour < 24.0f) {
			yield return new WaitForSeconds(TimeCtrl);
			lauelec += laukw;
		}
	}

	//히터 상호작용
	public void RADOnBtn() {
		Debug.Log ("Click Button");
		RADCountBtn++;
		Debug.Log (RADCountBtn);
		if (RADCountBtn % 2 != 0) {
			RADactive = true;
			AIRactive = false;
			StartCoroutine (this.RADDisplay ());
			StartCoroutine (this.RADelec ());
			StartCoroutine (this.AIRTemper());
		} else {
			RADactive = false;
		}
	}
	public void RADPopUpBtn() {
		RADpopCountBtn++;
		if (RADpopCountBtn % 2 != 0) {
			AllPopUp.Radiatorpopup (true);
		} else {
			AllPopUp.Radiatorpopup (false);
		}
	}
	//히터 화면
	IEnumerator RADDisplay() {
		for (int k = 0;; k++) {
			while (RADactive && radbool1 == true || !RADactive) {
				yield return null;
				RADdisplay.renderer.material.color = Color.green;
				Pointers[2].renderer.material.color = Color.red;
				for (int i = 0; i < radWings.Length; i++) {
					if (radbool1 == true && radWings [i].transform.localRotation.y > -0.1f && RADactive) {
						radWings [i].transform.Rotate (Vector3.right * Time.deltaTime * 50);
					}else if (radbool1 == true && radWings [i].transform.localRotation.y < 0.49f && !RADactive) {
						radWings [i].transform.Rotate (Vector3.left * Time.deltaTime * 50);
					} else {
						radbool1 = false;
					}
				}
				if (RADactive == false) {
					RADdisplay.renderer.material.color = Color.black;
					Pointers[2].renderer.material.color = Color.blue;
				}
				if (radbool1 == false) {
					radbool2 = true;
					break;
				}
			}

			while (radbool2 == true && RADactive == true || !RADactive) {
				RADdisplay.renderer.material.color = Color.green;
				yield return null;
				for (int j = 0; j < radWings.Length; j++) {
					if (radbool2 == true && radWings [j].transform.localRotation.y < 0.49f) {
						radWings [j].transform.Rotate (Vector3.left * Time.deltaTime * 50);
					} else {
						radbool2 = false;
					}
				}
				if (RADactive == false) {
					RADdisplay.renderer.material.color = Color.black;
					Pointers[2].renderer.material.color = Color.blue;
				}
				if (radbool2 == false) {
					radbool1 = true;
					break;
				}
			}
			if(!RADactive) 
				break;
		}
	}

	//히터 전력량
	IEnumerator RADelec() {
		while (RADactive && Tothour < 24.0f) {
			yield return new WaitForSeconds(TimeCtrl);
			radelec += radkw;
			//Debug.Log(radelec + "----------------------");
			//UIMng.TotalElectronic(tvelec);
		}
	}

	//밥솧 상호작용
	public void RICOnBtn() {
		Debug.Log ("Click Button");
		RICCountBtn++;
		Debug.Log (RICCountBtn);
		if (RICCountBtn % 2 != 0) {
			RICactive = true;
			StartCoroutine (this.RICDisplay ());
			StartCoroutine (this.RICelec ());
		} else {
			RICactive = false;
		}
	}
	public void RICEPopUpBtn() {
		RICpopCountBtn++;
		if (RICpopCountBtn % 2 != 0) {
			AllPopUp.Ricepopup (true);
		} else {
			AllPopUp.Ricepopup (false);
		}
	}
	//밥솥 화면
	IEnumerator RICDisplay() {
		while (RICactive && ricbool1) {
			yield return null;
			RICdisplay.renderer.material.color = Color.red;
			Pointers[4].renderer.material.color = Color.red;
			if(ricbool1 && ricetop.transform.rotation.x < 0.0f) {
				ricetop.transform.RotateAround(ricepoint.position,Vector3.right,moveSpeed*40*Time.deltaTime);
				Debug.Log(ricetop.transform.rotation.x);
			}
			else {
				ricbool1 = false;
				ricbool2 = true;

			}
			if(!ricbool1)
				break;
			//tvpower = true;
			/*
			if(RICactive == false)
				RICdisplay.renderer.material.color = Color.black;
            */
		}
		while (RICactive && ricbool2) {
			yield return null;
			if(!ricbool1 && ricetop.transform.rotation.x > -0.649f) {
				ricetop.transform.RotateAround(ricepoint.position,Vector3.left,moveSpeed*40*Time.deltaTime);
				Debug.Log(ricetop.transform.rotation.x);
			}
			else {
				ricbool1 = true;
				ricbool2 = false;
			}
			RICdisplay.renderer.material.color = Color.red;
			Pointers[4].renderer.material.color = Color.red;
			if(!ricbool2 || !RICactive)
				break;
		}
		while (RICactive) {
			yield return new WaitForSeconds(20);
			RICdisplay.renderer.material.color = Color.green;
			Pointers[4].renderer.material.color = Color.red;
		}
		while (!RICactive) {
			yield return null;
			RICdisplay.renderer.material.color = Color.black;
			Pointers[4].renderer.material.color = Color.blue;
		}
	}
	//밥솥 전력량
	IEnumerator RICelec() {
		while (RICactive && Tothour < 24.0f) {
			yield return new WaitForSeconds(TimeCtrl);
			if(RICdisplay.renderer.material.color == Color.green) {
				ricelec += rickw;
				Debug.Log(ricelec);
			} else if(RICdisplay.renderer.material.color == Color.red) {
				ricelec += (rickw * 10);
				Debug.Log(ricelec);
			}
		}
	}

	//다리미 상호작용
	public void IRONOnBtn() {		//다리미 On/Off 버튼 인식
		IRONCountBtn++;
		Debug.Log (IRONCountBtn);
		if (IRONCountBtn % 2 != 0) {
			IRONactive = true;
			StartCoroutine (this.IRONDisplay ());	//다리미 작동 구현
			StartCoroutine (this.IRONelec ());		//다리미 전력량 누적
		} else {
			IRONactive = false;
		}
	}
	public void IRONPopUpBtn() {		//다리미 팝업 active
		IRONpopCountBtn++;
		if (IRONpopCountBtn % 2 != 0) {
			AllPopUp.Ironpopup (true);
		} else {
			AllPopUp.Ironpopup (false);
		}
	}
	IEnumerator IRONelec() {			//다리미 전력량 누적
		while (IRONactive && Tothour < 24.0f) {
			yield return new WaitForSeconds(TimeCtrl);
			ironelec += ironkw;
		}
	}

	//다리미 작동 구현
	IEnumerator IRONDisplay() {
		for (int i = 0;; i++) {
			while (IRONactive && ironbool1) {
				yield return null;
				IRONdisplay.renderer.material.color = Color.blue;
				Pointers[3].renderer.material.color = Color.red;
				if (Iron.transform.rotation.x < -0.01f) {	//해당 위치까지 다리미 회전
					Iron.transform.Rotate (Vector3.right, moveSpeed * 70 * Time.deltaTime);
				} else {
					ironbool1 = false; ironbool2 = true;	//다음 동작을 이어지게 하는 bool변수
					break;
				}
				if (IRONactive == false) {
					IRONdisplay.renderer.material.color = Color.clear;
					Pointers[3].renderer.material.color = Color.blue;
				}
				if (!ironbool1) 
					break;
			}
			while (IRONactive && ironbool2) {
				yield return null;
				if (Iron.transform.position.z < 62) {	//해당 위치까지 다리미 이동
					Iron.transform.Translate (Vector3.forward * 10 * moveSpeed * Time.deltaTime);
				} else {
					ironbool2 = false; ironbool3 = true;	//다음 동작을 이어지게 하는 bool변수
					break;
				}
				if (!ironbool2)
					break;
			}
			while (IRONactive && ironbool3) {
				yield return null;
				if (Iron.transform.position.z > 50.678f) {	//해당 위치까지 다리미 이동
					Iron.transform.Translate (Vector3.back * 10 * moveSpeed * Time.deltaTime);
				} else {
					ironbool3 = false; ironbool2 = true;	//두 번째 while문 작동시키는 bool변수
				}
				if (!ironbool3) 
					break;
			}
			while(!IRONactive) {	//전원 Off시 다리미 세움
				yield return null;
				Pointers[3].renderer.material.color = Color.blue;
				if (Iron.transform.rotation.x > -0.7f) {	//해당 위치까지 다리미 회전
					Iron.transform.Rotate (Vector3.left, moveSpeed * 70 * Time.deltaTime);
				} else {
					ironbool1 = true; ironbool2 = false; ironbool3 = false;	//모든 bool변수 초기화
					break;
				}
			}
			if(!IRONactive && ironbool1 && !ironbool2 && !ironbool3){
				Pointers[3].renderer.material.color = Color.blue;
				break;	//for문 종료
			}
		}
	}

	//총 사용 전력량
	public void TotalElectronic(float tvelec, float airelec, float micelec, float refelec, float lauelec, float radelec, float ricelec, float ironelec) {
		if (Tothour < 24.0f) {
			totelecEnergy1 = (int)(tvelec + airelec + micelec + refelec + lauelec + radelec + ricelec + ironelec);
			totelecEnergy2 = tvelec + airelec + micelec + refelec + lauelec + radelec + ricelec;
			txtTotelec.text = "총 사용 전력량 : " + totelecEnergy1.ToString () + " kWh";
		}
	}

	//총 사용 비용 받아오는 함수
	public void TotCost(float totelecEnergy2) {
		//누진제도에 맞는 기본 요금 변경
		if (totelecEnergy2 == 0.0f) {	//총 사용 전력량
			BasicCost = 0.0f;	//기본 요금
			Cost = 0.0f;		//누적 요금
		}
		else if (totelecEnergy2 <= 100.0f) {
			BasicCost = 410.0f;
			Cost = totelecEnergy2 * 60.7f;
		}
		else if (totelecEnergy2 <= 200.0f) {
			BasicCost = 910.0f;
			Cost = (6070.0f) + (totelecEnergy2 - 100.0f) * 125.9f;
		}
		else if (totelecEnergy2 <= 300.0f) {
			BasicCost = 1600.0f;
			Cost = (18660.0f) + (totelecEnergy2 - 200.0f) * 187.9f;
		}
		else if (totelecEnergy2 <= 400.0f) {
			BasicCost = 3850.0f;
			Cost = (37450.0f) + (totelecEnergy2 - 300.0f) * 280.6f;
		}
		else if (totelecEnergy2 <= 500.0f) {
			BasicCost = 7300.0f;
			Cost = (65510.0f) + (totelecEnergy2 - 400.0f) * 417.7f;
		}
		else {
			BasicCost = 12940.0f;
			Cost = (107280.0f) + (totelecEnergy2 - 500.0f) * 709.5f;
		}
		//부가세 & 전력산업기반기금 합산
		totCost = (int) ((BasicCost)+((Cost) * (1.0f + VAT + ElecIndustryCost)));
		txtTotCost.text = "총 사용 비용 : " + totCost.ToString() + " 원";
	}
	//사용 시간 계산

	IEnumerator TotTime() {
		while (Tothour < 24.0f) {
			yield return new WaitForSeconds(TimeCtrl);
			Totsec += 15;
			if(Totsec == 60) {
				Totmin += Totsec / 60;
				Totsec = 0;
			}
			if(Totmin == 60) {
				Tothour += Totmin / 60;
				Totmin = 0;
			}
			UIMng.TotSec(Totsec);
			UIMng.TotMin(Totmin);
			UIMng.TotHour(Tothour);
		}
	}


	//총 사용 시간 받아오는 함수
	public void TotHour(int Tothour) {
		thour = Tothour;
	}
	//총 사용 분 받아오는 함수
	public void TotMin(int Totmin) {
		tmin = Totmin;
	}
	//총 사용 초 받아오는 함수
	public void TotSec(int Totsec) {
		tsec = Totsec;
		if(tsec < 10) {
			txtTotTime.text = "총 사용 시간 : " + thour.ToString() + " : " + tmin.ToString() + " : 0" + tsec.ToString();
		} else
			txtTotTime.text = "총 사용 시간 : " + thour.ToString() + " : " + tmin.ToString() + " : " + tsec.ToString();
	}

	IEnumerator PointersMove() {
			while (Tothour < 24.0f && movebool1) {
				yield return null;
				for (int j = 0; j < Pointers.Length; j++) {
					if (Pointers [j].transform.localPosition.y > 0.09f) {
						Pointers [j].transform.Translate (Vector3.forward * PointerSpeed * Time.deltaTime);

					} else {
						movebool1 = false;
						movebool2 = true;
					}
				}
				if(!movebool1) {
					movebool2 = true;
					break;
				}
			}
			while (Tothour < 24.0f && movebool2) {
				yield return null;
				for (int j = 0; j < Pointers.Length; j++) {
					if (Pointers [j].transform.localPosition.y < 0.12f) {
						Pointers [j].transform.Translate (Vector3.back * PointerSpeed * Time.deltaTime);

					} else {
						movebool1 = true;
						movebool2 = false;
					}
				}
				if(!movebool2) {
					movebool1 = true;
					break;
				}
			}
			//Debug.Log (i);
			//Debug.Log (Pointers [0].transform.localPosition.y);

	}

	public void elecInform() {
		ElecInform.activeElec (true);
		ElecInform.activeLaw (true);
		ElecInform.activeShow (true);
		ElecInform.activeEX (true);
		ElecInform.activeEPH (true);
		ElecInform.activeTV (false);
		ElecInform.activeAir (false);
		ElecInform.activeMic (false);
		ElecInform.activeRef (false);
		ElecInform.activeRad (false);
		ElecInform.activeLau (false);
		ElecInform.activeIron (false);
		ElecInform.activeRic (false);
		ElecInform.activeTot (false);
		ElecInform.activeTemp (false);
		totelecEnergy1 = totelecEnergy1 * 30.0f;
		totelecEnergy2 = totelecEnergy2 * 30.0f;

		if (totelecEnergy2 == 0.0f) {
			BasicCost = 0.0f;
			Cost = 0.0f;
			ElecInform.activeM0(true);
		}
		else if (totelecEnergy2 <= 100.0f) {
			BasicCost = 410.0f;
			Cost = totelecEnergy2 * 60.7f;
			ElecInform.activeM0(true);
		}
		else if (totelecEnergy2 <= 200.0f) {
			BasicCost = 910.0f;
			Cost = (6070.0f) + ((totelecEnergy2 - 100.0f) * 125.9f);
			ElecInform.activeM1(true);
		}
		else if (totelecEnergy2 <= 300.0f) {
			BasicCost = 1600.0f;
			Cost = (18660.0f) + ((totelecEnergy2 - 200.0f) * 187.9f);
			ElecInform.activeM2(true);
		}
		else if (totelecEnergy2 <= 400.0f) {
			BasicCost = 3850.0f;
			Cost = (37450.0f) + ((totelecEnergy2 - 300.0f) * 280.6f);
			ElecInform.activeM3(true);
		}
		else if (totelecEnergy2 <= 500.0f) {
			BasicCost = 7300.0f;
			Cost = (65510.0f) + ((totelecEnergy2 - 400.0f) * 417.7f);
			ElecInform.activeM4(true);
		}
		else {
			BasicCost = 12940.0f;
			Cost = (107280.0f) + ((totelecEnergy2 - 500.0f) * 709.5f);
			ElecInform.activeM5(true);
		}
		totCost = (int) ((BasicCost)+((Cost) * (1.0f + VAT + ElecIndustryCost)));
		if (Tothour >= 24.0f) {
			txtCostText.text = "실험 시간을 하루를 기준으로 한달동안 <color=#ff0000>" + totelecEnergy1.ToString () + "kWh</color>의 전기를 사용하셧습니다.\n" +
				"누진제도에 의해 기본료 <color=#ff0000>" + BasicCost.ToString () + "원</color>과 전력요금 <color=#ff0000>" + Cost.ToString () + "원</color>이 부과되었습니다.\n" +
					"총 부과하실 금액은 사용요금과 부가세 10%, 전력기금 3.7%를 더해 <color=#ff0000>" + totCost.ToString () + "원</color> 입니다.";
		} else {
			txtCostText.text = "24시간동안 가전제품을 사용해 주세요";
		}
	}

	public void HomeBtn() {
		ElecInform.activeElec (false);
		ElecInform.activeTot (true);
		ElecInform.activeTemp (true);
		ElecInform.activeLaw (false);
		ElecInform.activeEX (false);
		ElecInform.activeShow (false);
		ElecInform.activeEPH (false);
		totelecEnergy1 = totelecEnergy1 / 30.0f;
		totelecEnergy2 = totelecEnergy2 / 30.0f;
	}

	// Use this for initialization
	void Start () {
		UIMng = GameObject.Find ("UIManager").GetComponent<UIMngCtrl> ();
		RefriPop = GameObject.Find ("Refrigerator").GetComponent<RefriPopUpCtrl> ();
		AllPopUp = GameObject.Find ("UIManager").GetComponent<AllPopUpCtrl> ();
		ShadeTemp = Random.Range (15, 35);
		txtShadeTemp.text = "현재 온도 : " + ShadeTemp;
		StartCoroutine (this.TotTime ());
		ElecInform = GameObject.Find ("Interface").GetComponent<InterfaceCtrl> ();
		//StartCoroutine (this.PointersMove ());
	}

	
	// Update is called once per frame
	void Update () {
		TotalElectronic (tvelec, airelec, micelec, refelec, lauelec, radelec, ricelec, ironelec);
		TotCost (totelecEnergy2);
		StartCoroutine (this.REFelec ());
		StartCoroutine (this.PointersMove ());
		txtElecShow.text = "24시간 사용 전력량 \nTV : " + string.Format("{0:N2}",tvelec) + "kWh\n" +
			"세탁기 : " + string.Format("{0:N2}",lauelec) + "kWh\n에어컨 : " + string.Format("{0:N2}",airelec) + "kWh\n" +
				"라디에이터 : " + string.Format("{0:N2}",radelec) + "kWh\n다리미 : " + string.Format("{0:N2}",ironelec) + "kWh\n" +
				"냉장고 : " + string.Format("{0:N2}",refelec) + "kWh\n전기밥솥 : " + string.Format("{0:N2}",ricelec) + "kWh";
		//Debug.Log (InformMaker.position.y);
	}
}
