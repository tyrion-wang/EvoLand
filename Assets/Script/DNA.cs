using UnityEngine;
using System.Collections;

public class DNA {
	public int age = 20;
	public int[] sex = new int[2]{0,0};
	public float body = 1.0f;
	public System.Random rnd = null;
	public DNA(){
		initRandom();
		body = rnd.Next(100, 200)/100.0f;
		sex[1] = rnd.Next(0, 2);
	}

	public DNA(DNA dna1, DNA dna2){
		initRandom();
		body = rnd.Next(100, 200)/100.0f;
	}

	public void initRandom(){
		long tick = System.DateTime.Now.Ticks;
		rnd = new System.Random((int)(tick & 0xffffffffL) | (int) (tick >> 32));
	}

}
