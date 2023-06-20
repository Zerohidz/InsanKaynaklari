using TMPro;
using UnityEngine;

public class TogglableText : MonoBehaviour
{
    public string[] Texts;
    public int TextIndex = 0;

    [SerializeField] private TMP_Text _text;

    public void Toggle()
    {
        if (Texts.Length < 1) 
            return;

        TextIndex = (TextIndex + 1) % Texts.Length;
        _text.text = Texts[TextIndex];
    }
}
