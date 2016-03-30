using UnityEngine;
using System.Collections;

public abstract class AbstractRoomExit : MonoBehaviour {

	public RoomsContainer RoomsContainer;
	public RoomInit CurrentRoom;
	public GameObject Parent;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init()
	{
		Parent = transform.parent.gameObject;
		CurrentRoom = Parent.GetComponent<RoomInit>();
		RoomsContainer = CurrentRoom.RoomsMatrix;
	}
}
