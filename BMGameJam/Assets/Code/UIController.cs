using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private JunkCollector junkCollector;
    [SerializeField] private TextMeshProUGUI sizeLabel;

    private void Start()
    {
        junkCollector.OnSizeChange += UpdateSizeLabel;
    }

    private void UpdateSizeLabel(float newSize)
    {
        sizeLabel.SetText($"Size: {newSize}");
    }
}