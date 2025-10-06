using TMPro;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public void OnPressed()
    {
        text.text += "\n Loser";
    }
}
