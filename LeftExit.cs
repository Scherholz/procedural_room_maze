using UnityEngine;
using System.Collections;

public class LeftExit : AbstractRoomExit {

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
			Vector3 NextRoomPos = RoomsContainer.Rooms[(CurrentRoom.myI-1),CurrentRoom.myJ].transform.position;
			Vector3 NextRoomDoor = RoomsContainer.Rooms[(CurrentRoom.myI - 1),CurrentRoom.myJ].GetComponent<RoomInit>().right.transform.position;
			other.transform.position = new Vector3(NextRoomDoor.x - 1,NextRoomDoor.y,NextRoomDoor.z);
			Camera.main.transform.position = new Vector3(NextRoomPos.x,NextRoomPos.y,-10);
		}
	}
}
