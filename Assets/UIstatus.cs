using UnityEngine;
using TMPro;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText;

    public void SetStatus(string msg)
    {
        statusText.text = msg;
    }
}