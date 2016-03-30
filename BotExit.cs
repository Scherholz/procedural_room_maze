using UnityEngine;
using System.Collections;

public class BotExit : AbstractRoomExit {

	// Use this for initialization
	void Start () {
		Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Vector3 NextRoomPos = RoomsContainer.Rooms[CurrentRoom.myI,(CurrentRoom.myJ-1)].transform.position;
			Vector3 NextRoomDoor = RoomsContainer.Rooms[CurrentRoom.myI,(CurrentRoom.myJ-1)].GetComponent<RoomInit>().top.transform.position;
			other.transform.position = new Vector3(NextRoomDoor.x,NextRoomDoor.y-1,NextRoomDoor.z);
			Camera.main.transform.position = new Vector3(NextRoomPos.x,NextRoomPos.y,-10);
		}
	}
}
