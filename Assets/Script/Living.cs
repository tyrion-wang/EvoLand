using UnityEngine;
using System.Collections;

public class Living : MonoBehaviour {

	// Use this for initialization
	public Material skin_1;
	public Material skin_2;
	public Vector3 position = new Vector3(0,0,0);
	public Genome dna = new Genome();
	private int age = 0;
	void Start () {
		position = transform.position;
		print(dna.body);
		transform.localScale = new Vector3(dna.body, dna.body, dna.body);
		
		dna.Print();

		Move();
	}
	
	// Update is called once per frame
	void Update () {
		// transform.position = position;
		// transform.Translate(position);
		// float step = 20 * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), step); 
		
	}
	void FixedUpdate () {
		Check();
	}
	void Check(){
		age++;
		if(age >= dna.maxAge){
			die();
		}
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

	void die(){
		Destroy(transform.gameObject);
	}

	void Move(){
		float x = Random.Range(-5,5);
		float y = transform.position.y; 
		float z = Random.Range(-5,5);
		iTween.MoveBy(gameObject, iTween.Hash("amount", new Vector3(x, y, z), "speed", 2.5, "easeType", "easeInOutExpo", "oncomplete", "Move"));
	}
}
