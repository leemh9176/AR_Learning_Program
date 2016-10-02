using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ARManager : MonoBehaviour {

	int TVhitCount = 1;					//TV클릭 수
	int AirhitCount = 1;
	int MichitCount = 1;
	int RefhitCount = 1;
	int LauhitCount = 1;
	int RadhitCount = 1;
	int RichitCount = 1;
	int IronhitCount = 1;
	private InterfaceCtrl AllInterface;




	// Use this for initialization
	void Start () {
		//인터페이스 변수
		AllInterface = GameObject.Find ("Interface").GetComponent<InterfaceCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
		//Application 종료
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
		//카메라에서 마우스를 따라 레이를 이용하여 오브젝트 인식
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * 1000.0f, Color.green);

		RaycastHit hit;

		//PC에서 Raycast를 이용한 조작
		if (Input.GetMouseButtonDown (0)) {
			if(Physics.Raycast (ray,out hit, 1000.0f)){
				if(hit.collider.gameObject.name == "Television"){	//Collider인식
					++TVhitCount;
					if(TVhitCount % 2 == 0) {
						AllInterface.activeTV(true);	//인터페이스 active
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeTV(false);
				}

				if(hit.collider.gameObject.name == "Airconditioner"){
					++AirhitCount;
					if(AirhitCount % 2 ==0) {
						AllInterface.activeAir(true);
						AllInterface.activeTV(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					
					} else
						AllInterface.activeAir(false);

				}

				if(hit.collider.gameObject.name == "MicroWave"){
					++MichitCount;
					if(MichitCount % 2 ==0) {
						AllInterface.activeMic(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeMic(false);
					
				}
				if(hit.collider.gameObject.name == "Refrigerator"){
					++RefhitCount;
					if(RefhitCount % 2 ==0) {
						AllInterface.activeRef(true);
						
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeRef(false);
					
				}
				if(hit.collider.gameObject.name == "Laundry"){
					++LauhitCount;
					if(LauhitCount % 2 == 0) {
						AllInterface.activeLau(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeLau(false);
				}
				if(hit.collider.gameObject.name == "Radiator"){
					++RadhitCount;
					if(RadhitCount % 2 == 0) {
						AllInterface.activeRad(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeRad(false);
				}
				if(hit.collider.gameObject.name == "RiceMachine"){
					++RichitCount;
					if(RichitCount % 2 == 0) {
						AllInterface.activeRic(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
					}
					else
						AllInterface.activeRic(false);
				}
				if(hit.collider.gameObject.name == "Iron"){
					++IronhitCount;
					if(IronhitCount % 2 == 0) {
						AllInterface.activeIron(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeIron(false);
				}

			}
		}
#elif UNITY_ANDROID
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
		//안드로이드에서 Raycast를 이용한 터치 조작
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Ray ray = Camera.main.ScreenPointToRay (Input.touches[0].position);
													//배열을 통해 터치 Position 저장
			RaycastHit hit;

			if(Physics.Raycast (ray,out hit, 1000.0f)) {
				if(hit.collider.gameObject.name == "Television"){	//Collider인식
					++TVhitCount;
					if(TVhitCount % 2 == 0) {
						AllInterface.activeTV(true);  //인터페이스active
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeTV(false);
				}
				if(hit.collider.gameObject.name == "Airconditioner"){
					++AirhitCount;
					if(AirhitCount % 2 ==0) {
						AllInterface.activeAir(true);
						AllInterface.activeTV(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeAir(false);
				}
				if(hit.collider.gameObject.name == "MicroWave"){
					++MichitCount;
					if(MichitCount % 2 ==0) {
						AllInterface.activeMic(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeMic(false);
					
				}
				if(hit.collider.gameObject.name == "Refrigerator"){
					++RefhitCount;
					if(RefhitCount % 2 ==0) {
						AllInterface.activeRef(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeRef(false);
					
				}
				if(hit.collider.gameObject.name == "Laundry"){
					++LauhitCount;
					if(LauhitCount % 2 == 0) {
						AllInterface.activeLau(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeLau(false);
				}
				if(hit.collider.gameObject.name == "Radiator"){
					++RadhitCount;
					if(RadhitCount % 2 == 0) {
						AllInterface.activeRad(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeRad(false);
				}
				if(hit.collider.gameObject.name == "RiceMachine"){
					++RichitCount;
					if(RichitCount % 2 == 0) {
						AllInterface.activeRic(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeIron(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
					}
					else
						AllInterface.activeRic(false);
				}
				if(hit.collider.gameObject.name == "Iron"){
					++IronhitCount;
					if(IronhitCount % 2 == 0) {
						AllInterface.activeIron(true);
						AllInterface.activeTV(false);
						AllInterface.activeAir(false);
						AllInterface.activeLau(false);
						AllInterface.activeMic(false);
						AllInterface.activeRad(false);
						AllInterface.activeRef(false);
						AllInterface.activeRic(false);
					}
					else
						AllInterface.activeIron(false);
				}
			}
		}
#endif
	}

}

