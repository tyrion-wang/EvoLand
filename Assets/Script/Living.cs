using UnityEngine;
using System.Collections;

public class Living : MonoBehaviour {

	// Use this for initialization
	public Material skin_1;
	public Material skin_2;
	public Vector3 position = new Vector3(0,0,0);
	public Genome dna = new Genome();
	private bool goRight = true;
	private int age = 0;
	void Start () {
		position = transform.position;
		print(dna.body);
		transform.localScale = new Vector3(dna.body, dna.body, dna.body);
		
		print(dna.toString());

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
		Check();
		Move();
	}
	void Check(){
		age++;
		if(age >= dna.maxAge){
			die();
		}
	}
	void Move(){
		RandomPosition();
	}

	void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("碰撞到的物体的名字是：" + collisionInfo.gameObject.name);
		if(dna.sex[1] == collisionInfo.gameObject.GetComponent<Living>().dna.sex[1]){
			attack(collisionInfo.gameObject.GetComponent<Living>());
		}else{
			if(age >= 5){
				sex();
			}
		}
    }

	public void attack(Living other){
		if(dna.body < other.dna.body){
			die();
		}
	}
	public void sex(){
		GameObject living = (GameObject)Instantiate(Resources.Load("Prefabs/Living"));
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
