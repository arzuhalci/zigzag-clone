using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraFollower : MonoBehaviour
{
    public Rigidbody playerrb;
    public Transform camtransform;
    Vector3 targetedCamPos;
    public RoadCreator rc;
    public Vector3 lastCubePos;
    public float speed = 5;
    public Vector3 normalizedDirection;
    public CharacterMovement cm;
    public float x;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        playerrb = GameObject.Find("Player").GetComponent<Rigidbody>();
        camtransform = gameObject.GetComponent<Transform>();
        rc = GameObject.Find("RoadManager").GetComponent<RoadCreator>();
        cm = GameObject.Find("Player").GetComponent<CharacterMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cm.mouseClicked)
        {
            normalizedDirection = new Vector3(calculateOffset().x - transform.position.x + x,28f, calculateOffset().z - transform.position.z - z).normalized;
            transform.Translate(normalizedDirection * speed);
            transform.position = new Vector3(transform.position.x, 28f, transform.position.z);
        }
        Debug.Log(lastCubePos);
    }

    public Vector3 calculateOffset()
    {
        lastCubePos = new Vector3(rc.cubes.Last<GameObject>().transform.position.x,28f, rc.cubes.Last<GameObject>().transform.position.z);
        
            return lastCubePos;
    }
}
