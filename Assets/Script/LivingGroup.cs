using UnityEngine;
using System.Collections;

public class LivingGroup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject living_1 = (GameObject)Instantiate(Resources.Load("Prefabs/Living"));
		living_1.transform.position = new Vector3(-6,0,0);
		GameObject living_2 = (GameObject)Instantiate(Resources.Load("Prefabs/Living"));
		living_2.transform.position = new Vector3(6,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
