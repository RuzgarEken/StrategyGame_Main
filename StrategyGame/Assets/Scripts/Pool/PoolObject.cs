using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolObject : MonoBehaviour 
{
    [ReadOnly] [SerializeField] protected string objeType;
}
