using UnityEngine;
using System.Collections;

public class RoomsContainer : MonoBehaviour {

	public GameObject ReferenceRoom1;

	public GameObject[,] Rooms;
	private bool[,] roomOccupied;
	private int RoomMatrixOrder = 20;

	public int iIndex = 0;
	public int jIndex = 0;

	public bool finished = false;

	private int minRoomQuantity = 16;
	private int roomsCreated = 0;
	private int maxJ = 0;
	private int maxI = 0;
	private int maxIJ = 0;
	private int maxJI = 0;

	private int[] maxJroom = new int[2];
	private int[] maxIroom	= new int[2];

	private enum dir 
	{
		TOP,
		BOT,
		LEFT,
		RIGHT
	}
	private dir dirTaken;

	// Use this for initialization
	void Start () {

		roomOccupied = new bool[RoomMatrixOrder,RoomMatrixOrder];
		Rooms = new GameObject[RoomMatrixOrder,RoomMatrixOrder];

		// initiate with false
		for (int i = 0; i < RoomMatrixOrder; i++) 
			for (int j = 0; j < RoomMatrixOrder; j++) 
				roomOccupied[i,j] = false;

		/*for (int i = 0; i < RoomMatrixOrder; i++) 
			for (int j = 0; j < RoomMatrixOrder; j++) 
			{

			Rooms[i,j] = (GameObject) Instantiate(ReferenceRoom1,new Vector3(0 + 20*i,0 + 20 *j,0f),Quaternion.identity);
			
			}*/
		Rooms[0,0] = (GameObject) Instantiate(ReferenceRoom1,new Vector3(0 + 20*iIndex,0 + 20 *jIndex,0f),Quaternion.identity);
		roomOccupied[0,0] = true;
		roomsCreated = 1;
		Rooms[0,0].GetComponent<RoomInit>().myI = 0;
		Rooms[0,0].GetComponent<RoomInit>().myJ = 0;
		Rooms[0,0].name = ("Room_" + 0 + "_" + 0);
		Rooms[0,0].GetComponent<RoomInit>().RoomsMatrix = this.gameObject.GetComponent<RoomsContainer>();

		while(roomsCreated<minRoomQuantity)
		{
						AddNextRoom();
						if (roomsCreated == minRoomQuantity )
							finished = true;
		}
				

	}
	
	// Update is called once per frame
	void Update () {

	}

	void AddNextRoom()
	{
		int randNum;
		randNum = Random.Range(1,5);
		switch(randNum)
		{
		case 1:
			if(iIndex<RoomMatrixOrder)
				iIndex++;
				dirTaken = dir.RIGHT;
			break;
		case 2:
			if(iIndex>0)
				iIndex--;
				dirTaken = dir.LEFT;
			break;
		case 3:
			if(jIndex<RoomMatrixOrder)
				jIndex++;
				dirTaken = dir.TOP;
			break;
		case 4:
			if(jIndex>0)
				jIndex--;
				dirTaken = dir.BOT;
			break;
		
		default:
			break;

		}

		Debug.Log("i : " + iIndex +"j : " + jIndex);
		//check if room is occupied
		if(roomOccupied[iIndex,jIndex] == false)
		{
			Rooms[iIndex,jIndex] = (GameObject) Instantiate(ReferenceRoom1,new Vector3(0 + 24*iIndex,0 + 14 *jIndex,0f),Quaternion.identity);
			roomOccupied[iIndex,jIndex] = true;
			roomsCreated ++;
			Rooms[iIndex,jIndex].GetComponent<RoomInit>().myI = iIndex;
			Rooms[iIndex,jIndex].GetComponent<RoomInit>().myJ = jIndex;
			Rooms[iIndex,jIndex].name = ("Room_" + iIndex + "_" + jIndex);
			Rooms[iIndex,jIndex].GetComponent<RoomInit>().RoomsMatrix = this.gameObject.GetComponent<RoomsContainer>();

			// TOP , BOT , LEFT , RIGHT
			switch(dirTaken)
			{
			case dir.TOP:
				Rooms[iIndex,jIndex].GetComponent<RoomInit>().SetBotTrue();
				Rooms[iIndex,jIndex-1].GetComponent<RoomInit>().SetTopTrue();
					break;
				
			case dir.BOT:
				Rooms[iIndex,jIndex].GetComponent<RoomInit>().SetTopTrue();
				Rooms[iIndex,jIndex+1].GetComponent<RoomInit>().SetBotTrue();
				break;
			case dir.LEFT:
				Rooms[iIndex,jIndex].GetComponent<RoomInit>().SetRightTrue();
				Rooms[iIndex+1,jIndex].GetComponent<RoomInit>().SetLeftTrue();
				break;
			case dir.RIGHT:
				Rooms[iIndex,jIndex].GetComponent<RoomInit>().SetLeftTrue();
				Rooms[iIndex-1,jIndex].GetComponent<RoomInit>().SetRightTrue();
				break;
	
			default:
				break;
			}

			if(jIndex >= maxJ )
			{
				maxJ = jIndex;
				maxJroom[0] = iIndex;
				maxJroom[1] = jIndex;

				if(iIndex > maxJI++)
				maxJI = iIndex;

			}
			if(iIndex >= maxI )
			{
				maxI = iIndex;
				maxIroom[0] = iIndex;
				maxIroom[1] = jIndex;

				if(jIndex > maxIJ++)
					maxIJ = maxIJ++;
			}


		}
		if(maxI > maxJ && maxIJ > maxJI)
			Debug.Log("Max room detect: " + maxIroom[0] + " , " + maxIroom[1]);
			else
			Debug.Log("Max room detect: " + maxJroom[0] + " , " + maxJroom[1]);

	}
	public bool[,] GetRoomOcuppiedMatrix()
	{
		return roomOccupied;
	}
}
