using UnityEngine;
using System.Collections;

public class Living : MonoBehaviour {

	// Use this for initialization
	public Vector3 position =new Vector3(0,0,0);
	public DNA dna = new DNA();
	private bool goRight = true;
	void Start () {
		position = transform.position;
		print(dna.body);
		transform.localScale = new Vector3(dna.body, dna.body, dna.body);

		if(position.x>0){
			goRight = true;
		}else{
			goRight = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = position;
	}
	void FixedUpdate () {
		Move();
	}
	
	void Move(){
		RandomPosition();
		
	}

	void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("碰撞到的物体的名字是：" + collisionInfo.gameObject.name);
		if(dna.sex[1] == collisionInfo.gameObject.GetComponent<Living>().dna.sex[1]){
			attack(collisionInfo.gameObject.GetComponent<Living>());
		}
    }

	public void attack(Living other){
		if(dna.body < other.dna.body){
			die();
		}
	}

	public int[] RandomPosition(){
		int [] move = new int[2]  {0, 0};
		int direction = Random.Range(1,5);
		if(goRight){
			position.x--;
		}else{
			position.x++;
		}
		// switch(direction){
		// 	case 1  :
		// 		position.x++;
		// 	break; 

		// 	case 2  :
		// 		position.x--;
		// 	break; 
		
		// 	case 3  :
		// 		position.z++;
		// 	break; 

		// 	case 4  :
		// 		position.z--;
		// 	break; 

		// 	default : 
       	// 		position.x++;
       	// 	break; 
		// }
		return move;
	}

	void die(){
		Destroy(transform.gameObject);
	}
}
