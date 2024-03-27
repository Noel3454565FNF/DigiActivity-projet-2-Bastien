using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour
{

	public Transform player;

	void Update()
	{
		transform.position = new Vector2(player.position.x + 6, player.position.y) ;
	}


}