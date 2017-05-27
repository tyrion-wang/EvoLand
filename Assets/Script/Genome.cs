using UnityEngine;
using System.Collections;

public class Genome {
	public BitArray gene = new BitArray(4*5+2);
	public int maxAge = 100;
	public int[] sex = new int[2]{0,0};
	public float body = 1.0f;
	public System.Random rnd = null;
	public Genome(){
		initRandom();
		initGene();
		body = rnd.Next(100, 200)/100.0f;
		sex[1] = rnd.Next(0, 2);

	}

	public Genome(Genome dna1, Genome dna2){
		initRandom();
		body = rnd.Next(100, 200)/100.0f;
	}

	public void initRandom(){
		long tick = System.DateTime.Now.Ticks;
		rnd = new System.Random((int)(tick & 0xffffffffL) | (int) (tick >> 32));
	}

	public void initGene(){
		for (int x = 0; x < gene.Length; x++){  
			gene[x] = rnd.NextBool();
			// gene[x] = true;
		}
		gene[gene.Length-2] = false;
	}

	public string toString(){
		string geneString = "";
		for (int x = 0; x < gene.Length; x++){
			if(gene[x]){
				geneString+="1";
			}else{
				geneString+="0";
			}
		}
		return geneString;
	}
}

