using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private TMP_InputField _input;

    public void OnEnable()
    {
        _input = GetComponent<TMP_InputField>();
    }

    public void UpdateText()
    {
        if(0 < _input.text.Length && _input.text.Length <= 20)
        {
            _text.text = _input.text;
        }
    }
}
