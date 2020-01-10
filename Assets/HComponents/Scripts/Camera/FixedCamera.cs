using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    float yOffset;
    public Transform playerTrans;
    // Start is called before the first frame update
    void Start()
    {
        yOffset = transform.position.y - playerTrans.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float y = playerTrans.position.y + yOffset;
        Vector3 pos = transform.position;
        pos.y = y;
        transform.position = pos;
    }
}
