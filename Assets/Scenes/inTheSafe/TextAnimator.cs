using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode] // tomer fuck u
public class TextAnimator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int MONEY;
    
  

    // Update is called once per frame
    void Update()
    {
        text.text = "$" + MONEY;
    }
}
