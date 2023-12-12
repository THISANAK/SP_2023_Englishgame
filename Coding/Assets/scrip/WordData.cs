using UnityEngine;
using UnityEngine.UI;

public class WordData : MonoBehaviour
{
    [SerializeField] 
    private Text charText;

    [HideInInspector]
    public char charValue;

    private Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        if (buttonComponent)
        {
            buttonComponent.onClick.AddListener(() => CharSelected());
        }
    }

    public void SetWord(char value)
    {
        charText.text = value + "";
        charValue = value;
    }

    private void CharSelected()
    {
        QuizManager.instance.SelectedOption(this);
     
    }

}