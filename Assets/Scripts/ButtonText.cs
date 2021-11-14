using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    public Text textField;
    // Start is called before the first frame update
    public void SetText(string text) {

        textField.text = text;
    }
}
