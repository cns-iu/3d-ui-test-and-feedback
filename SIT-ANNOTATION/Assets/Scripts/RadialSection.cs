using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sector { 
    Audio,
    Visual, 
    Physics, 
    Feedback,
    Miscellaneous, 
    Reset
}

public class RadialSection : MonoBehaviour
{
    [field: SerializeField]
    public Sector Type { get; set; }
}
