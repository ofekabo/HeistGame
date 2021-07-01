using System.Collections.Generic;
using UnityEngine;

public class GetBuildVersion : MonoBehaviour
{
    [ContextMenu("Get Build")]
    void GetBuildV()
    {
        Debug.Log(Application.version);
    }
}
