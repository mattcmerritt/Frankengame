using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offsetX, offsetZ;

    private void Start()
    {
        offsetX = transform.position.x - player.transform.position.x;
        offsetZ = transform.position.z;
    }

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + offsetX, transform.position.y, offsetZ); // offset by initial spacing
    }
}
