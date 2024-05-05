using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_moving : MonoBehaviour
{
    [SerializeField] float water_speed = 0.1f;
    [SerializeField] float direction = 1f;
    // Update is called once per frame
    void Update()
    {
        float yMove=water_speed* Time.deltaTime;
        transform.Translate(new Vector2(0, yMove*direction));
    }
}
