using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public Vector3 offsetCamera;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x + offsetCamera.x, player.position.y + offsetCamera.y, player.position.z + offsetCamera.z), 10* Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, 0.2f);
        transform.LookAt(player);
    }
}
