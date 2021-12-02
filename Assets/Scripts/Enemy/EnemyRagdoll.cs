using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _bones;

    public void ActiveRagdoll()
    {
        foreach(Rigidbody currentBone in _bones)
        {
            currentBone.isKinematic = false;
        }
    }
}
