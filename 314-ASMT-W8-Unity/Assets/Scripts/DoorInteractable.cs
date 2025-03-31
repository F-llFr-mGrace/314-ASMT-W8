using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorInteractable : SimpleHingeInteractable
{
    [SerializeField] Transform doorObject;
    [SerializeField] CombinationLock combolock;

    [SerializeField] bool isRightSide;

    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation.y;
    }

    protected override void Update()
    {
        if (combolock != null)
        {
            if (!combolock.isLocked)
            {
                MoveHinge();
            }
        }
        else
        {
            MoveHinge();
        }
        if (isRightSide)
        {
            transform.localEulerAngles = new Vector3(0, Mathf.Clamp(transform.localRotation.eulerAngles.y, 0, 90), 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, Mathf.Clamp(transform.localRotation.eulerAngles.y, 270, 360 - Mathf.Epsilon), 0);
        }
    }

    private void MoveHinge()
    {
        base.Update();

        if (doorObject != null)
        {
            doorObject.localEulerAngles = new Vector3
                (
                doorObject.localEulerAngles.x,
                transform.localEulerAngles.y,
                doorObject.localEulerAngles.z
                );
        }
    }
}
