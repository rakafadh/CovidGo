using UnityEngine;
using UnityEngine.UI;

public class BlinkingTextUI : MonoBehaviour
{
    public GameObject[] textGameObjects; // Array of GameObjects that have Text components
    public float blinkDuration = 0.5f; // Duration of the blink in seconds

    private Text[] textElements; // Array of Text components
    private bool isVisible = true; // Text visibility status

    void Start()
    {
        // Initialize the array of Text components
        textElements = new Text[textGameObjects.Length];

        for (int i = 0; i < textGameObjects.Length; i++)
        {
            // Get the Text component from each GameObject
            textElements[i] = textGameObjects[i].GetComponent<Text>();

            if (textElements[i] == null)
            {
                Debug.LogWarning($"Text component not found on GameObject '{textGameObjects[i].name}'.");
            }
        }

        // Start the coroutine for the blink effect
        InvokeRepeating(nameof(ToggleVisibility), 0, blinkDuration);
    }

    void ToggleVisibility()
    {
        foreach (var textElement in textElements)
        {
            if (textElement != null)
            {
                // Toggle the visibility of the text
                isVisible = !isVisible;
                textElement.enabled = isVisible;
            }
        }
    }
}
