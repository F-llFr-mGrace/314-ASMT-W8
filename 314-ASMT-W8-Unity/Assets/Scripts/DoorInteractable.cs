using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : SimpleHingeInteractable
{
    [SerializeField] Transform doorObject;
    [SerializeField] CombinationLock combolock;

    // Start is called before the first frame update
    void Start()
    {
        
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
