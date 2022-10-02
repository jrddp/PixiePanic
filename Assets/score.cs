using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text m_MyText;

    void Start()
    {
        //Text sets your text to say this message
        
    }

    void Update()
    {
        //Press the space key to change the Text message
        if (Input.GetKey(KeyCode.Space))
        {
            m_MyText.text = "My text has now changed.";
        }
    }
}