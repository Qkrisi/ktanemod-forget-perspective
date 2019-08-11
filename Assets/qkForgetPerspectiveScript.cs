﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KModkit;
using System.Linq;
using System;

public class qkForgetPerspectiveScript : MonoBehaviour {

	public GameObject Cube;
	public GameObject Module;
	public GameObject[] Faces;
	public GameObject OrangeOBJ;
	public GameObject WhiteOBJ;
	public KMSelectable[] Buttons;
	public GameObject StageText;
	public GameObject InputText;
	public GameObject TimerText;
	public KMBombInfo Bomb;
	public KMAudio Audio;

	public List<string> AllStages;
	public List<string> CurrentStage;
	public List<int> indexes;
	public List<string> Answer;
	public List<string> letters;
	private string Input;
	private int stageNumber = 0;
	private int currentInputNumber = 1;
	private int prevnum = 0;
	private int stages;
	public List<string> Ignoreds;
	private bool solved = false;
	private bool readytosolve = false;
	public List<string> AvailableColors;
	public List<string> TempColors;
	private float OriginalTime;
	private bool stagegot = false;
	private int net = 0;
	private int starting;
	public List<string> finalorder;
	public List<string> lowlist;
	int ticker = 0;
	int solveCount = 0;
	int lastCalcStage=0;
	List<String> solvedModules = new List<String>();
	private float angle = 900.0f;
 	private float time = 0.1f;
	private Vector3 axis = Vector3.up;
	private bool autorotate = false;
	private int x;
	private int y;

	private Material Orange;
	private Material Yellow;
	private Material Blue;
	private Material Green;
	private Material Red;
	private Material Magenta;
	private Material White;

	static int moduleIdCounter;
	int moduleId;



	void Awake() {
		
		moduleId=moduleIdCounter++;
		//Debug.LogFormat("There are {0} modules on the bomb", Bomb.GetModuleNames().Count);
		CurrentStage.Clear();
		Debug.LogFormat("Awake");
		OriginalTime = Bomb.GetTime();
		AvailableColors.Clear();
		AvailableColors.Add("Blue");
		AvailableColors.Add("Red");
		AvailableColors.Add("Green");
		AvailableColors.Add("Yellow");
		AvailableColors.Add("Magenta");
		AvailableColors.Add("Orange");
		letters.Clear();
        letters.Add("A");
        letters.Add("B");
        letters.Add("C");
        letters.Add("D");
        letters.Add("E");
        letters.Add("F");
		letters.Add("G");
		letters.Add("H");
		letters.Add("I");
		letters.Add("J");
		letters.Add("K");
		letters.Add("L");
		letters.Add("M");
		letters.Add("N");
		letters.Add("O");
		letters.Add("P");
		letters.Add("Q");
		letters.Add("R");
		letters.Add("S");
		letters.Add("T");
		letters.Add("U");
		letters.Add("V");
		letters.Add("W");
		letters.Add("X");
		letters.Add("Y");
		letters.Add("Z");

		Orange=OrangeOBJ.GetComponent<Renderer>().material;
		Red=Faces[0].GetComponent<Renderer>().material;
		Magenta=Faces[1].GetComponent<Renderer>().material;
		Blue=Faces[2].GetComponent<Renderer>().material;
		Green=Faces[3].GetComponent<Renderer>().material;
		Yellow=Faces[4].GetComponent<Renderer>().material;
		White=WhiteOBJ.GetComponent<Renderer>().material;

		Buttons[0].OnInteract += delegate(){
			Buttons[0].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[0].transform);
			pressButton(letters[0]);
			return false;
		};
		Buttons[1].OnInteract += delegate(){
			Buttons[1].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[1].transform);
			pressButton(letters[1]);
			return false;
		};
		Buttons[2].OnInteract += delegate(){
			Buttons[2].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[2].transform);
			pressButton(letters[2]);
			return false;
		};
		Buttons[3].OnInteract += delegate(){
			Buttons[3].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[3].transform);
			pressButton(letters[3]);
			return false;
		};
		Buttons[4].OnInteract += delegate(){
			Buttons[4].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[4].transform);
			pressButton(letters[4]);
			return false;
		};
		Buttons[5].OnInteract += delegate(){
			Buttons[5].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[5].transform);
			pressButton(letters[5]);
			return false;
		};
		Buttons[6].OnInteract += delegate(){
			Buttons[6].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[6].transform);
			pressButton(letters[6]);
			return false;
		};
		Buttons[7].OnInteract += delegate(){
			Buttons[7].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[7].transform);
			pressButton(letters[7]);
			return false;
		};
		Buttons[8].OnInteract += delegate(){
			Buttons[8].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[8].transform);
			pressButton(letters[8]);
			return false;
		};
		Buttons[9].OnInteract += delegate(){
			Buttons[9].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[9].transform);
			pressButton(letters[9]);
			return false;
		};
		Buttons[10].OnInteract += delegate(){
			Buttons[10].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[10].transform);
			pressButton(letters[10]);
			return false;
		};
		Buttons[11].OnInteract += delegate(){
			Buttons[11].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[11].transform);
			pressButton(letters[11]);
			return false;
		};
		Buttons[12].OnInteract += delegate(){
			Buttons[12].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[12].transform);
			pressButton(letters[12]);
			return false;
		};
		Buttons[13].OnInteract += delegate(){
			Buttons[13].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[13].transform);
			pressButton(letters[13]);
			return false;
		};
		Buttons[14].OnInteract += delegate(){
			Buttons[14].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[14].transform);
			pressButton(letters[14]);
			return false;
		};
		Buttons[15].OnInteract += delegate(){
			Buttons[15].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[15].transform);
			pressButton(letters[15]);
			return false;
		};
		Buttons[16].OnInteract += delegate(){
			Buttons[16].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[16].transform);
			pressButton(letters[16]);
			return false;
		};
		Buttons[17].OnInteract += delegate(){
			Buttons[17].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[17].transform);
			pressButton(letters[17]);
			return false;
		};
		Buttons[18].OnInteract += delegate(){
			Buttons[18].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[18].transform);
			pressButton(letters[18]);
			return false;
		};
		Buttons[19].OnInteract += delegate(){
			Buttons[19].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[19].transform);
			pressButton(letters[19]);
			return false;
		};
		Buttons[20].OnInteract += delegate(){
			Buttons[20].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[20].transform);
			pressButton(letters[20]);
			return false;
		};
		Buttons[21].OnInteract += delegate(){
			Buttons[21].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[21].transform);
			pressButton(letters[21]);
			return false;
		};
		Buttons[22].OnInteract += delegate(){
			Buttons[22].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[22].transform);
			pressButton(letters[22]);
			return false;
		};
		Buttons[23].OnInteract += delegate(){
			Buttons[23].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[23].transform);
			pressButton(letters[23]);
			return false;
		};
		Buttons[24].OnInteract += delegate(){
			Buttons[24].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[24].transform);
			pressButton(letters[24]);
			return false;
		};
		Buttons[25].OnInteract += delegate(){
			Buttons[25].AddInteractionPunch(.5f);
			Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Buttons[25].transform);
			pressButton(letters[25]);
			return false;
		};

		//Debug.LogFormat("Got a new module: {0}", Bomb.GetModuleNames()[0]);

		/*List<string> tempmodules = Bomb.GetModuleNames();
		foreach(string i in Ignoreds){
			tempmodules.RemoveAll(item => item == i);
		}
		stages=tempmodules.Count;*/
		
		//Debug.LogFormat("[Forget Perspective #{0}] Number of stages: {1}", moduleId, stages);

		//generateNew((int) (OriginalTime/60));
		//StartCoroutine(Countdown());
	}

	void Reset() {
		
		Debug.LogFormat("Awake");
		OriginalTime = Bomb.GetTime();
		AvailableColors.Clear();
		AvailableColors.Add("Blue");
		AvailableColors.Add("Red");
		AvailableColors.Add("Green");
		AvailableColors.Add("Yellow");
		AvailableColors.Add("Magenta");
		AvailableColors.Add("Orange");
		letters.Clear();
        letters.Add("A");
        letters.Add("B");
        letters.Add("C");
        letters.Add("D");
        letters.Add("E");
        letters.Add("F");
		letters.Add("G");
		letters.Add("H");
		letters.Add("I");
		letters.Add("J");
		letters.Add("K");
		letters.Add("L");
		letters.Add("M");
		letters.Add("N");
		letters.Add("O");
		letters.Add("P");
		letters.Add("Q");
		letters.Add("R");
		letters.Add("S");
		letters.Add("T");
		letters.Add("U");
		letters.Add("V");
		letters.Add("W");
		letters.Add("X");
		letters.Add("Y");
		letters.Add("Z");
       
		


		generateNew((int) (OriginalTime/60));
	}

	void generateNew(int time){
		//Debug.LogFormat("Generate started");
		if(!solved){
		CurrentStage.Clear();
		TimerText.GetComponent<TextMesh>().text="";
		//Debug.LogFormat("Got there");
		stageNumber++;
		if(stageNumber>stages){
				if(readytosolve){return;}
				Debug.LogFormat("[Forget Perspective #{0}] ------Final------", moduleId);
				Faces[0].GetComponent<Renderer>().material=White;
				Faces[1].GetComponent<Renderer>().material=White;
				Faces[2].GetComponent<Renderer>().material=White;
				Faces[3].GetComponent<Renderer>().material=White;
				Faces[4].GetComponent<Renderer>().material=White;
				StageText.GetComponent<TextMesh>().text="Input";
				string ansstring = "";
				foreach(string pt in Answer){
					ansstring = ansstring + pt;
				}
				Debug.LogFormat("[Forget Perspective #{0}] Answer: {1}", moduleId, ansstring);
				readytosolve=true;
				return;
		}
		StageText.GetComponent<TextMesh>().text=stageNumber.ToString();
		Debug.LogFormat("[Forget Perspective #{0}] ------Stage {1} ------", moduleId,stageNumber.ToString());
		TempColors=AvailableColors;
		for(int i = 0;i<5;i++){
			CurrentStage.Add(TempColors[UnityEngine.Random.Range(0,TempColors.Count)]);
			//foreach(string curr in CurrentStage){
				//Debug.LogFormat(curr);
			//}
			Debug.LogFormat("[Forget Perspective #{0}]" +CurrentStage.Count.ToString(), moduleId);
			TempColors.RemoveAll(item => item == CurrentStage[i]);
		}
		CurrentStage.Add(TempColors[0]);
		CurrentStage.Add(time.ToString());
		
		for(int i = 0;i<5;i++){
			Debug.LogFormat("[Forget Perspective #{0}] Face {1} is {2}.", moduleId, (i+1).ToString(), CurrentStage[i]);
			switch(CurrentStage[i]){
				case "Red":
					Faces[i].GetComponent<Renderer>().material=Red;
					break;
				case "Orange":
					Faces[i].GetComponent<Renderer>().material=Orange;
					break;
				case "Blue":
					Faces[i].GetComponent<Renderer>().material=Blue;
					break;
				case "Green":
					Faces[i].GetComponent<Renderer>().material=Green;
					break;
				case "Yellow":
					Faces[i].GetComponent<Renderer>().material=Yellow;
					break;
				case "Magenta":
					Faces[i].GetComponent<Renderer>().material=Magenta;
					break;
			}
		}
		Debug.LogFormat("[Forget Perspective #{0}] Face 6 is {1}.", moduleId, CurrentStage[5]);
		indexes.Add(AllStages.Count);
		foreach(string it in CurrentStage){
			AllStages.Add(it);
		}
		Calculate();
		//if(autorotate){StartCoroutine(ProcessTwitchCommand("rotate"));}
		}
	}





	void Calculate(){
		//Debug.LogFormat("Started calculating: {0}", CurrentStage.Count.ToString());
		int currtime = int.Parse(CurrentStage[6]);
		Debug.LogFormat("[Forget Perspective #{0}] Time you got the stage on: {1}",moduleId, CurrentStage[6]);
		finalorder.Clear();
		//Debug.LogFormat("finalorder cleared");
		lowlist.Clear();
		//Debug.LogFormat("lowlist cleared");
		//lowlist = CurrentStage;
		foreach(string it in CurrentStage){lowlist.Add(it);}
		//Debug.LogFormat("Lowlist 1: {0}", lowlist.Count.ToString());
		lowlist[lowlist.FindIndex(ind=>ind.Equals("Red"))] =  "R";
		lowlist[lowlist.FindIndex(ind=>ind.Equals("Blue"))] =  "B";
		lowlist[lowlist.FindIndex(ind=>ind.Equals("Green"))] =  "G";
		lowlist[lowlist.FindIndex(ind=>ind.Equals("Yellow"))] =  "Y";
		lowlist[lowlist.FindIndex(ind=>ind.Equals("Magenta"))] =  "M";
		lowlist[lowlist.FindIndex(ind=>ind.Equals("Orange"))] =  "O";
		//Debug.LogFormat("Short values assigned");
		if(currtime%6==0){
			starting=1;
		}
		else{
			if(isPrime(currtime)){
				starting=2;
			}
			else{
				if((Math.Sqrt(currtime))%1==0){
					starting=3;
				}
				else{
					if(currtime/10<1){
						starting=4;
					}
					else{
						if(currtime%2==0){
							starting=5;
						}
						else{
							starting=6;
						}
					}
				}
			}
		}
		Debug.LogFormat("[Forget Perspective #{0}] Starting rule {1} applied.", moduleId, starting);
		//Debug.LogFormat("Starting position calculated");

		switch(lowlist[starting-1]){
			case "R":
				net=1;
				break;
			case "B":
				net=2;
				break;
			case "G":
				net=3;
				break;
			case "Y":
				net=4;
				break;
			case "M":
				net=5;
				break;
			case "O":
				net=6;
				break;
		}
		Debug.LogFormat("[Forget Perspective #{0}] Net rule {1} applied.", moduleId, net);
		//Debug.LogFormat("Net calculated: {0}", net);

		switch(net){

			case 1:
				//Debug.LogFormat("Got to case 1");
				switch(starting){
					case 1:
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[5]);
						break;
					case 2:
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[3]);
						break;
					case 3:
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[4]);
						break;
					case 4:
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[1]);
						break;
					case 5:
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[2]);
						break;
					case 6:
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[0]);
						break;
					}
				break;
			case 2:
			//Debug.LogFormat("Got to case 2");
			switch(starting){
					case 1:
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						break;
					case 2:
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						break;
					case 3:
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						break;
					case 4:
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						break;
					case 5:
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						break;
					case 6:
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						break;
					}
				break;
			case 3:
			//Debug.LogFormat("Got to case 3");
			switch(starting){
					case 1:
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						break;
					case 2:
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						break;
					case 3:
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						break;
					case 4:
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						break;
					case 5:
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						break;
					case 6:
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						break;
					}
				break;
			case 4:
			//Debug.LogFormat("Got to case 4");
			switch(starting){
					case 1:
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[5]);
						break;
					case 2:
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[3]);
						break;
					case 3:
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[4]);
						break;
					case 4:
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[1]);
						break;
					case 5:
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[2]);
						break;
					case 6:
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[0]);
						break;
					}
				break;
			case 5:
			//Debug.LogFormat("Got to case 5");
			switch(starting){
					case 1:
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[1]);
						break;
					case 2:
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[5]);
						break;
					case 3:
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[5]);
						break;
					case 4:
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[5]);
						break;
					case 5:
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[5]);
						break;
					case 6:
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[1]);
						break;
					}
				break;
			case 6:
			//Debug.LogFormat("Got to case 6");
			switch(starting){
					case 1:
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[2]);
						break;
					case 2:
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[2]);
						break;
					case 3:
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[3]);
						break;
					case 4:
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[4]);
						break;
					case 5:
						finalorder.Add(lowlist[4]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[1]);
						break;
					case 6:
						finalorder.Add(lowlist[5]);
						finalorder.Add(lowlist[2]);
						finalorder.Add(lowlist[3]);
						finalorder.Add(lowlist[1]);
						finalorder.Add(lowlist[0]);
						finalorder.Add(lowlist[4]);
						break;
					}
				break;
			}
			string ordertostring = "";
			for(int i = 0;i<5;i++){ordertostring=ordertostring+" "+finalorder[i];}
			Debug.LogFormat("[Forget Perspective #{0}] Order made:{1}", moduleId, ordertostring);
			//Debug.LogFormat("List length: {0}", finalorder.Count.ToString());
		x=letters.FindIndex(ind=>ind.Equals(Bomb.GetSerialNumberLetters().Last().ToString().ToUpper()))+1;
		Debug.LogFormat("[Forget Perspective #{0}] X = {1}", moduleId, x.ToString());
		y=Bomb.GetSerialNumberNumbers().Sum();
		Debug.LogFormat("[Forget Perspective #{0}] Y = {1}", moduleId, y.ToString());
		int rule = (Bomb.GetBatteryCount()*Bomb.GetPortCount())%10;
		Debug.LogFormat("[Forget Perspective #{0}] Character Shift rule = {1}", moduleId, rule.ToString());
		//foreach(string i in finalorder){
			for(int i=0;i<finalorder.Count;i++){
			//int basenum = letters.FindIndex(ind=>ind.Equals(i))+1;
			int basenum = letters.FindIndex(ind=>ind.Equals(finalorder[i]))+1;
			int final = 0;
			switch(rule){
				case 0:
					final=basenum+3;
					break;
				case 1:
					final=basenum+x;
					break;
				case 2:
					final=basenum-y;
					break;
				case 3:
					final=basenum+y-Bomb.GetPortPlateCount();
					break;
				case 4:
					final=basenum+Bomb.GetSerialNumberNumbers().Last();
					break;
				case 5:
					final=(basenum-Bomb.GetBatteryHolderCount())+x*2;
					break;
				case 6:
					final=basenum+Bomb.GetOnIndicators().Count()+y-Bomb.GetOffIndicators().Count();
					break;
				case 7:
					if(Bomb.IsIndicatorOn(Indicator.SIG)){
						final=basenum+x;
					}
					else{
						final=basenum+y;
					}
					break;
				case 8:
					final=basenum+x+y-Bomb.GetIndicators().Count()-Bomb.GetBatteryCount(Battery.D);
					break;
				case 9:
					if(Bomb.GetBatteryCount()>3){
						final=basenum+x;
					}
					else{
						final=basenum-x;
					}
					if(Bomb.GetIndicators().Count()>3){
						final=final+y;
					}
					else{
						final=final-y;
					}
					break;
			}
			while(!(final>0 && final<27)){
			if(final<1){final=26-(final*-1);}
			if(final>26){final=final-26;}}
			Debug.LogFormat("[Forget Perspective #{0} Shifted: {1} => {2}", moduleId, finalorder[i], letters[final-1]);
			//lowlist[lowlist.FindIndex(ind=>ind.Equals("Red"))] =  "R";
			//finalorder[finalorder.FindIndex(ind=>ind.Equals(i))]=letters[final-1];
			finalorder[i]=letters[final-1];
		}
		string finalstring = "";
		foreach(string i in finalorder){
			finalstring = finalstring + i;
		}
		Debug.LogFormat("Shifted order: {0} {1} {2} {3} {4} {5}", finalstring[0].ToString(), finalstring[1].ToString(), finalstring[2].ToString(), finalstring[3].ToString(), finalstring[4].ToString(), finalstring[5].ToString());
		int vowels =0;
		for (int i = 0; i < finalstring.Length; i++)
    	{
        if (finalstring[i]  == 'A' || finalstring[i] == 'E' || finalstring[i] == 'I' || finalstring[i] == 'O' || finalstring[i] == 'U')
        {
            vowels++;
        }
    	}
		if(vowels>=3){
			//Debug.LogFormat("Answer 0!");
			Answer.Add(finalstring[0].ToString());
			}
		else{
			if (finalstring[5]  == 'A' || finalstring[5] == 'E' || finalstring[5] == 'I' || finalstring[5] == 'O' || finalstring[5] == 'U'){
				//Debug.LogFormat("Answer 1!");
				Answer.Add(finalstring[1].ToString());
			}
			else{
				bool arethere = false;
				for(int j=0;j<finalstring.Length;j++){
					int target = j-1;
					if(target==-1){target=5;}
					if((finalstring[j]  == 'A' || finalstring[j] == 'E' || finalstring[j] == 'I' || finalstring[j] == 'O' || finalstring[j] == 'U') && (finalstring[target]  == 'A' || finalstring[target] == 'E' || finalstring[target] == 'I' || finalstring[target] == 'O' || finalstring[target] == 'U')){
						arethere = true;
					}
				}
				if(arethere){
					//Debug.LogFormat("Answer 2!");
					Answer.Add(finalstring[2].ToString());
					}
				else{
					bool arethere2 = false;
					for(int p=0;p<finalstring.Length;p++){
					int target2 = p-1;
					if(target2==-1){target2=5;}
					int target3 = target2-1;
					if(target3==-1){target3=5;}
					if(!(finalstring[p]  == 'A' || finalstring[p] == 'E' || finalstring[p] == 'I' || finalstring[p] == 'O' || finalstring[p] == 'U') && !(finalstring[target2]  == 'A' || finalstring[target2] == 'E' || finalstring[target2] == 'I' || finalstring[target2] == 'O' || finalstring[target2] == 'U') && !(finalstring[target3]  == 'A' || finalstring[target3] == 'E' || finalstring[target3] == 'I' || finalstring[target3] == 'O' || finalstring[target3] == 'U')){
						arethere2 = true;
					}
					int tempconsnum = 0;
					for(int k=0;k<finalstring.Length;k++){
							if(!(finalstring[k]  == 'A' || finalstring[k] == 'E' || finalstring[k] == 'I' || finalstring[k] == 'O' || finalstring[k] == 'U')){
								tempconsnum++;
							}
						}
					if(tempconsnum==5){arethere2=false;}
				}
				if(arethere2){
					//Debug.LogFormat("Answer 3!");
					Answer.Add(finalstring[3].ToString());
				}
				else{
						int consnum = 0;
						for(int k=0;k<finalstring.Length;k++){
							if(!(finalstring[k]  == 'A' || finalstring[k] == 'E' || finalstring[k] == 'I' || finalstring[k] == 'O' || finalstring[k] == 'U')){
								consnum++;
							}
						}
						if(consnum==5){
							//Debug.LogFormat("Answer 4!");
							Answer.Add(finalstring[4].ToString());
						}
						else{
							//Debug.LogFormat("Answer 5!");
							Answer.Add(finalstring[5].ToString());
						}
					}
				}
			}
		}
		Debug.LogFormat("[Forget Perspective #{0}] Added value: {1}", moduleId, Answer[Answer.Count-1].ToString());
		return;
	}



	public bool isPrime(int number){
		if(number==1){return false;}
		else{
		int n, i, m=0, flag=0;    
          n = number;  
          m=n/2;    
          for(i = 2; i <= m; i++)    
          {    
           if(n % i == 0)    
            {    
             return false;  
             flag=1;    
             break;    
            }    
          }    
          if (flag==0){    
           return true;}
		  else{
			  return false;
		  }
		}
	}


	void Display(int stage){
		for(int i = 0; i<5; i++){
			switch(AllStages[indexes[(stage-1)]+i]){
				case "Red":
					Faces[i].GetComponent<Renderer>().material=Red;
					break;
				case "Orange":
					Faces[i].GetComponent<Renderer>().material=Orange;
					break;
				case "Blue":
					Faces[i].GetComponent<Renderer>().material=Blue;
					break;
				case "Green":
					Faces[i].GetComponent<Renderer>().material=Green;
					break;
				case "Yellow":
					Faces[i].GetComponent<Renderer>().material=Yellow;
					break;
				case "Magenta":
					Faces[i].GetComponent<Renderer>().material=Magenta;
					break;
			}
		}
		StageText.GetComponent<TextMesh>().text=stage.ToString();
		int zero = 0;
		TimerText.GetComponent<TextMesh>().text=AllStages[indexes[(stage-1)]+6];
		if(int.Parse(TimerText.GetComponent<TextMesh>().text)/10<1){TimerText.GetComponent<TextMesh>().text = zero.ToString() + TimerText.GetComponent<TextMesh>().text;}
	}


	void pressButton(string letter){
		Debug.LogFormat("[Forget Perspective #{0}] Pressed: {1} at stage {2}", moduleId, letter, currentInputNumber);
		if(readytosolve){
			if(!solved){
			if(Answer[currentInputNumber-1]==letter){
				if(InputText.GetComponent<TextMesh>().text.Length==6){InputText.GetComponent<TextMesh>().text="";}
				InputText.GetComponent<TextMesh>().text=InputText.GetComponent<TextMesh>().text+letter;
				Debug.LogFormat("[Forget Perspective #{0}] Which was correct!", moduleId);
				currentInputNumber++;
				if(currentInputNumber>stages){
					solved=true;
					Faces[0].GetComponent<Renderer>().material=White;
					Faces[1].GetComponent<Renderer>().material=White;
					Faces[2].GetComponent<Renderer>().material=White;
					Faces[3].GetComponent<Renderer>().material=White;
					Faces[4].GetComponent<Renderer>().material=White;
					TimerText.GetComponent<TextMesh>().text="";
					StageText.GetComponent<TextMesh>().text="GG :D";
					InputText.GetComponent<TextMesh>().text="Module solved!";
					Debug.LogFormat("[Forget Perspective #{0}] Module solved!", moduleId);
					GetComponent<KMBombModule>().HandlePass();
				}
		}
		else{
			Debug.LogFormat("[Forget Perspective #{0}] Which wasn't correct. Strike!", moduleId);
			Display(currentInputNumber);
			GetComponent<KMBombModule>().HandleStrike();
				}
			}
		}
		else{
			Debug.LogFormat("[Forget Perspective #{0}] Tried to press button before the module is ready to be solved. Strike!", moduleId);
			GetComponent<KMBombModule>().HandleStrike();
		}
	}

	void checkForNew(){
		if(stages>0){
		if(Bomb.GetSolvedModuleNames().Count()>prevnum){
			prevnum=Bomb.GetSolvedModuleNames().Count();
			if(prevnum<stages){
				Reset();
			}
			else{
				//StopCoroutine(Countdown());
				Faces[0].GetComponent<Renderer>().material=White;
				Faces[1].GetComponent<Renderer>().material=White;
				Faces[2].GetComponent<Renderer>().material=White;
				Faces[3].GetComponent<Renderer>().material=White;
				Faces[4].GetComponent<Renderer>().material=White;
				StageText.GetComponent<TextMesh>().text="Input";
				readytosolve=true;
			}
		}
		}
		else{
			//StopCoroutine(Countdown());
			solved=true;
			readytosolve=true;
			Faces[0].GetComponent<Renderer>().material=White;
			Faces[1].GetComponent<Renderer>().material=White;
			Faces[2].GetComponent<Renderer>().material=White;
			Faces[3].GetComponent<Renderer>().material=White;
			Faces[4].GetComponent<Renderer>().material=White;
			TimerText.GetComponent<TextMesh>().text="";
			StageText.GetComponent<TextMesh>().text="GG :D";
			InputText.GetComponent<TextMesh>().text="Module solved!";
			GetComponent<KMBombModule>().HandlePass();
		}
	}

	/*/private IEnumerator Countdown()
 	{
     while(true){
		 if(!stagegot){
		List<string> tempmodules = Bomb.GetModuleNames();
		foreach(string i in Ignoreds){
			tempmodules.RemoveAll(item => item == i);
		}
		stages=tempmodules.Count;
		Debug.LogFormat("There are {0} modules on the bomb", Bomb.GetModuleNames().Count);
		stagegot=true;
	 	}
		yield return new WaitForSeconds(.2f);
		
		checkForNew();
	 }
 	}*/

	 private IEnumerator AutoSolve(){
		 yield return new WaitForSeconds(2f);
		 Debug.LogFormat("[Forget Perspective #{0}] There are no modules that is not ignored by Forget Perspective. Auto-solving module.", moduleId);
		 GetComponent<KMBombModule>().HandlePass();
		 yield break;
	 }


	 void Start (){
		 CheckAutoSolve();
	 }
	
	void CheckAutoSolve(){
		stages = Bomb.GetSolvableModuleNames().Where(x => !Ignoreds.Contains(x)).Count();
		if(stages==0){
			//Debug.LogFormat("Got to solve");
			solved=true;
			readytosolve=true;
			Faces[0].GetComponent<Renderer>().material=White;
			Faces[1].GetComponent<Renderer>().material=White;
			Faces[2].GetComponent<Renderer>().material=White;
			Faces[3].GetComponent<Renderer>().material=White;
			Faces[4].GetComponent<Renderer>().material=White;
			TimerText.GetComponent<TextMesh>().text="";
			StageText.GetComponent<TextMesh>().text="GG :D";
			InputText.GetComponent<TextMesh>().text="Module solved!";
			StartCoroutine(AutoSolve());
			//GetComponent<KMBombModule>().HandlePass();
		}
	}

	 void Update (){
		 if(solved){return;}
		ticker++;
		if(ticker == 5)
		{
			ticker = 0;

			List<String> newSolves = Bomb.GetSolvedModuleNames().ToList();

			if(newSolves.Count() == solveCount)
				return;

			solveCount = newSolves.Count();

			foreach (String d in Ignoreds) { newSolves.Remove(d); }
			foreach (String d in solvedModules) { newSolves.Remove(d); }

			if(newSolves.Count() == 0)
				return;

			lastCalcStage++;
			solvedModules.Add(newSolves[0]);
		}
		if(lastCalcStage >= stageNumber)
		{
			Reset();
		}
	 }

	private float getRotateRate(float targetTime, float rate)
    {
        return rate * (Time.deltaTime / targetTime);
    }

	IEnumerator RotateModule(int duration)
    {
			int angle = 20;
			//Module.transform.localEulerAngles = new Vector3(0, 0, 0);
			for (float i = 0; i < angle; i += getRotateRate(2.5f, 300))
            {	
				if(Module.transform.localEulerAngles.z==0){
                Module.transform.localEulerAngles = new Vector3((30 - i), Module.transform.localEulerAngles.y, Module.transform.localEulerAngles.z);}
				else{
					Module.transform.localEulerAngles = new Vector3(-(30 - i), Module.transform.localEulerAngles.y, Module.transform.localEulerAngles.z);
				}
                yield return null;
            }

			

			/*float startRotation = Module.transform.localEulerAngles.x;
        	float endRotation = startRotation + 45.0f;
        	float t = 0.0f;
        	while ( t  < duration )
        	{
            	t += Time.deltaTime;
            	float xRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 45.0f;
            	Module.transform.localEulerAngles = new Vector3(xRotation, Module.transform.localEulerAngles.y, Module.transform.localEulerAngles.z);
            	yield return null;
        	}
			Module.transform.localEulerAngles = new Vector3(45, 0, 0);*/

			//duration=6;
			yield return new WaitForSeconds(0.5f);
			float startRotation = Cube.transform.localEulerAngles.y;
        	float endRotation = startRotation + 360.0f;
        	float t = 0.0f;
        	while ( t  < duration )
        	{
            	t += Time.deltaTime;
            	float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            	Cube.transform.localEulerAngles = new Vector3(Cube.transform.localEulerAngles.x, yRotation, Cube.transform.localEulerAngles.z);
            	yield return null;
        	}
			Cube.transform.localEulerAngles = new Vector3(0, 180, 0);


			/*duration=2;
			startRotation = Module.transform.localEulerAngles.x;
			endRotation = startRotation + 45.0f;
        	t = 0.0f;
        	while ( t  < duration )
        	{
            	t += Time.deltaTime;
            	float xRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 45.0f;
            	Module.transform.localEulerAngles = new Vector3(-xRotation, Module.transform.localEulerAngles.y, Module.transform.localEulerAngles.z);
            	yield return null;
        	}
			Module.transform.localEulerAngles = new Vector3(0, 0, 0);*/


			/*angle = 20;
			Module.transform.eulerAngles = new Vector3(20, 0, 0);
			
			for (float i = 0; i < angle; i += getRotateRate(2.5f, 300))
            {
                Module.transform.eulerAngles = new Vector3((30 - i), Module.transform.eulerAngles.y, Module.transform.eulerAngles.z);
                yield return null;
            }*/


			angle = 20;
			//Module.transform.localEulerAngles = new Vector3(0, 0, 0);
			for (float i = 0; i < angle; i += getRotateRate(2.5f, 300))
            {	
				if(Module.transform.localEulerAngles.z==0){
                Module.transform.localEulerAngles = new Vector3(-(30 - i), Module.transform.localEulerAngles.y, Module.transform.localEulerAngles.z);}
				else{
					Module.transform.localEulerAngles = new Vector3((30 - i), Module.transform.localEulerAngles.y, Module.transform.localEulerAngles.z);
				}
                yield return null;
            }
			Module.transform.localEulerAngles=new Vector3(0, 0, Module.transform.localEulerAngles.z);
		yield break;
    }

	public string TwitchHelpMessage = "Use '!{0} submit <input>' to submit an answer! (Don't use spaced between the input characters!)";
    IEnumerator ProcessTwitchCommand(string command){
		yield return null;
		if(command.Equals("rotate", StringComparison.InvariantCultureIgnoreCase)){
			if(Module.transform.localEulerAngles.z==0){yield return new Quaternion[] {((Quaternion.Euler(0,0,0)) * (Quaternion.Euler(0,0,0)) * (Quaternion.Euler(0,0,0))), Quaternion.Euler(75,0,0)};}
			else{
			yield return new Quaternion[] {((Quaternion.Euler(0,0,0)) * (Quaternion.Euler(0,0,0)) * (Quaternion.Euler(0,0,0))), Quaternion.Euler(-75,0,0)};
			}
			StartCoroutine(RotateModule(6));
			yield return new WaitForSeconds(7.1f);
			yield return new Quaternion[] {((Quaternion.Euler(0,0,0)) * (Quaternion.Euler(0,0,0)) * (Quaternion.Euler(0,0,0))), Quaternion.Euler(0,0,0)};
			yield break;
		}
		/* if(command.Equals("toggleautorotate", StringComparison.InvariantCultureIgnoreCase)){
			autorotate=!autorotate;
			if(autorotate){
				yield return null;
				yield return "sendtochat Autorotation turned ON.";
				yield break;
			}
			else{
				yield return null;
				yield return "sendtochat Autorotation turned OFF.";
				yield break;
			}
		}*/
		
			string commandl=command.ToUpper();
			commandl=commandl.Replace("PRESS ", "");
			commandl=commandl.Replace("SUBMIT ", "");
			for(int i=0;i<commandl.Length;i++){
				//Debug.LogFormat(commandl[i]);
				//Debug.LogFormat(letters.FindIndex(ind=>ind.Equals(commandl[i])).ToString());
				if(letters.FindIndex(ind=>ind.Equals(commandl[i].ToString()))>-1){
					Buttons[letters.FindIndex(ind=>ind.Equals(commandl[i].ToString()))].OnInteract();
				}
				else{
					int lastinputnumber = currentInputNumber-1;
					yield return null;
					yield return "sendtochaterror Invalid character. You've entered " + lastinputnumber + " characters so far.";
					yield break;
				}
			}
			yield break;
	}
	
}