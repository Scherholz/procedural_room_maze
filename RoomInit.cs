using UnityEngine;
using System.Collections;

public class RoomInit : MonoBehaviour {

	public GameObject LevelMatrix;
	public RoomsContainer RoomsMatrix;
	public int myI;
	public int myJ;
	public GameObject top;
	public GameObject bot;
	public GameObject left;
	public GameObject right;

	private bool exitTop = false;
	private bool exitBot = false;
	private bool exitRig = false;
	private bool exitLef = false;

	private bool firstUpdate = true;

	private bool[,] RoomOcuppiedMatrix;

	// Use this for initialization
	void Start () {
	



	}
	
	// Update is called once per frame
	void Update () {
		if(RoomsMatrix.finished==true && firstUpdate ==true)
		{
			RoomOcuppiedMatrix = RoomsMatrix.GetRoomOcuppiedMatrix();
			//for (int i = 0; i < 20; i++) 
				//for (int j = 0; j < 20; j++) 
					//Debug.Log ("[ " + i + " ][ " + j + " ] : " + RoomOcuppiedMatrix[i,j]);
				
				
			
	
		if(RoomOcuppiedMatrix[myI,(myJ+1)] == false)
			{
			Destroy(top);
				//Debug.Log ("Destroyed top because: [ " + myI + " ][ " + (myJ+1) + " ] : " + RoomOcuppiedMatrix[myI,(myJ+1)]);
			}
		
		if(myJ>0)
			{
				if(RoomOcuppiedMatrix[myI,(myJ-1)]== false || myJ == 0)
					Destroy(bot);
			}
			else
				Destroy(bot);
		if(myI>0)
			{
				if(RoomOcuppiedMatrix[(myI-1),myJ]== false || myI == 0)
					Destroy(left);
			}
			else
				Destroy(left);

		if(RoomOcuppiedMatrix[(myI+1),myJ]== false)
			{
			Destroy(right);
			//Debug.Log ("Destroyed right because: [ " + (myI+1) + " ][ " + myJ + " ] : " + RoomOcuppiedMatrix[(myI+1),myJ]);
			}
			firstUpdate = false;
		}

	}
	public void SetExists(bool a,bool b,bool c,bool d)
	{
		if(a==true)
			exitTop = true;
		if(b==true)
			exitBot = true;
		if(c==true)
			exitLef = true;
		if(d==true)
			exitRig = true;
	}
	public void SetTopTrue()
	{
		exitTop = true;
	}
	public void SetBotTrue()
	{
		exitBot = true;
	}
	public void SetLeftTrue()
	{
		exitLef = true;
	}
	public void SetRightTrue()
	{
		exitRig = true;
	}

	public bool GetExitTop()
	{
		return exitTop;
	}
	public bool GetExitBot()
	{
		return exitBot;
	}
	public bool GetExitLeft()
	{
		return exitLef;
	}
	public bool GetExitRight()
	{
		return exitRig;
	}
}
