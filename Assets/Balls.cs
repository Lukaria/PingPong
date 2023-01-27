using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ball")]


public class Balls : ScriptableObject
{
    [field:SerializeField]
    public Vector2 direction
    {
        get;
        private set;
    }
}
