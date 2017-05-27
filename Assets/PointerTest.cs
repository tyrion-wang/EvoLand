using UnityEngine;
using System.Collections;

public class PointerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print("PointerTest Start");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click(){
		print("PointerTest Click");
		Application.Quit();
	}
}
