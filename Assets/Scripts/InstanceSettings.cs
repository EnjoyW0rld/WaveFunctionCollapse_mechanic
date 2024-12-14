using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceSettings : MonoBehaviour
{
    [SerializeField] private GameObject[] allowedObjectsLeft;
    [SerializeField] private GameObject[] allowedObjectsRight;
    [SerializeField] private GameObject[] allowedObjectsTop;
    [SerializeField] private GameObject[] allowedObjectsBottom;
    public GameObject[] LeftAllowed { get { return allowedObjectsLeft; } }
    public GameObject[] RightAllowed { get { return allowedObjectsRight; } }
    public GameObject[] TopAllowed { get { return allowedObjectsTop; } }
    public GameObject[] BottomAllowed { get { return allowedObjectsBottom; } }
}
