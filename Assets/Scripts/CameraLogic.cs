using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public GameObject playerTarget;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTarget.transform.position + offset;
    }
}
