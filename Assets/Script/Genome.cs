using UnityEngine;
using System.Collections;

enum Gene
{ 
	Body = 0,
	Speed = 1,
	Face = 2,
	Attack = 3,
	Defense = 4
}

public class Genome {
	public int groupLenth = 8;
	public int groupNum = 10;
	public BitArray gene = null;
	public int maxAge = 100;
	public int[] sex = new int[2]{0,0};
	public float body = 1.0f;
	public System.Random rnd = null;
	public Genome(){
		gene = new BitArray(groupLenth*groupNum + 2);
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

	public void Print(){
		//按位打印
		string geneString = "";
		//xy两位
		geneString += gene[gene.Length-1]?"1":"0";
		geneString += gene[gene.Length-2]?"1":"0";
		//其他位
		geneString +="[";
		for (int x = gene.Length-3; x>=0; x--){
			geneString+=gene[x]?"1":"0";
			if(x!=0 && x%groupLenth==0){
				geneString+="][";
			}
		}
		geneString +="]";
		Debug.Log(geneString);

		//按组打印
		string geneGroupString = "";
		//xy两位
		geneGroupString += gene[gene.Length-1]?"1":"0";
		geneGroupString += gene[gene.Length-2]?"1":"0";
		//其他位
		for (int x = groupNum-1; x>=0; x--){
			geneGroupString +="[";
			geneGroupString+=getIntFromBitArray(getGroup(x));
			geneGroupString +="]";
		}
		Debug.Log(geneGroupString);

	}

	public int getIntFromBitArray(BitArray bitArray)
	{
		if (bitArray.Length > 32)
			throw new System.ArgumentException("Argument length shall be at most 32 bits.");

		int[] array = new int[1];
		bitArray.CopyTo(array, 0);
		return array[0];
	}

	public BitArray getGroup(int index){
		if (index >= groupNum)
			throw new System.ArgumentException("Group index shall be at most " + (groupNum-1) + ".");

		BitArray group = new BitArray(groupLenth);
		for(int i=0; i<groupLenth; i++){
			group[i]=gene[groupLenth*index+i];
		}
		return group;
	}
}

