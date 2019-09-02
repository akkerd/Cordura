using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMeAs : MonoBehaviour
{
    [SerializeField]
    SO_ObjectRef sO_ObjectRef;
    // Use this for initialization
    void Start()
    {
        sO_ObjectRef.setObjectRef(this.gameObject);
    }
}
