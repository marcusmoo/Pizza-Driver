using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -20);
    }

    
}
