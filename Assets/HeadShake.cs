using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShake : MonoBehaviour
{
    private int headNodCount;
    private int headShakeCount;
    
    bool nextTargetUp = true;
    bool nextTargetRight = true;

    public float requiredRotation = 90;
    public int requiredCount = 10;

    private float currentRotationUp;
    private float currentRotationRight;

    private Quaternion previousRotation;
    private Vector3 angularVelocity;

    void Update()
    {
        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(previousRotation);
        previousRotation = transform.rotation;
        deltaRotation.ToAngleAxis(out var angle, out var axis);
        angle *= Mathf.Deg2Rad;
        angularVelocity = (1.0f / Time.deltaTime) * angle * axis;
        angularVelocity.x = -angularVelocity.x;

        if (nextTargetRight)
        {
            if (angularVelocity.y > 0)
                currentRotationRight += angularVelocity.y;
        }
        else //if next target Left
        {
            if (angularVelocity.y < 0)
                currentRotationRight += angularVelocity.y;
        }
        
        if (nextTargetUp)
        {
            if (angularVelocity.x > 0)
                currentRotationUp += angularVelocity.x;
        }
        else //if next target down
        {
            if (angularVelocity.x < 0)
                currentRotationUp += angularVelocity.x;
        }



        if (nextTargetRight && currentRotationRight > requiredRotation)
        {
            nextTargetRight = false;
            currentRotationRight = 0;
            headShakeCount++;
            if (headShakeCount >= requiredCount)
            {
                headShakeCount = 0;
                headNodCount = 0;
                ShakeComplete();
            }
        }
        else if (!nextTargetRight && currentRotationRight < -requiredRotation)
        {
            nextTargetRight = true;
            currentRotationRight = 0;
            headShakeCount++;
            if (headShakeCount >= requiredCount)
            {
                headShakeCount = 0;
                headNodCount = 0;
                ShakeComplete();
            }
        }
        
        if (nextTargetUp && currentRotationUp > requiredRotation)
        {
            nextTargetUp = false;
            currentRotationUp = 0;
            headNodCount++;
            if (headNodCount >= requiredCount)
            {
                headNodCount = 0;
                headShakeCount = 0;
                NodComplete();
            }
        }
        else if (!nextTargetUp && currentRotationUp < -requiredRotation)
        {
            nextTargetUp = true;
            currentRotationUp = 0;
            headNodCount++;
            if (headNodCount >= requiredCount)
            {
                headNodCount = 0;
                headShakeCount = 0;
                NodComplete();
            }
        }
    }

    public void ShakeComplete()
    {
        print("shake");
    }

    public void NodComplete()
    {
        print("nod");
    }
}