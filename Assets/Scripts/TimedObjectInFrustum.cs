using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectInFrustum : ObjectInFrustum
{
    private bool seen;
    public float timeRequired = 3;
    public float minPlayerDistance = 10;
    private float timeSeen;
    private Transform player;

    protected override void Start()
    {
        player = GameManager.Player.transform;
        base.Start();
    }

    void Update()
    {
        if (IsObjectInFrustum() && Vector3.Distance(transform.position, player.position) <= minPlayerDistance)
        {
            timeSeen += Time.deltaTime;
        }
        else
        {
            timeSeen = 0;
        }

        if (!seen && timeSeen > timeRequired)
        {
            seen = true;
            print("seen!");
        }
    }
}
