using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [Header("Assign patrol waypoints in order")]
    public List<Transform> waypoints = new List<Transform>();
}
