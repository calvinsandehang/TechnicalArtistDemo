using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIFlickerEffect : MonoBehaviour
{
    private Image image;
    public float minOnDuration = 5f;
    public float maxOnDuration = 10f;
    public float minFlickerDuration = 0.5f;
    public float maxFlickerDuration = 1.5f;
    public float flickerFrequency = 0.1f;

    private Material tempMaterial;
    private Color originalGlowColor;

    void Start()
    {
        image = GetComponent<Image>();

        // Create an instance of the material
        tempMaterial = Instantiate(image.material);
        originalGlowColor = tempMaterial.GetColor("_GlowColor");

        // Assign the new material instance to the Image component
        image.material = tempMaterial;

        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            // Lamp on
            tempMaterial.SetColor("_GlowColor", originalGlowColor);
            yield return new WaitForSeconds(Random.Range(minOnDuration, maxOnDuration));

            // Flickering
            float flickerEndTime = Time.time + Random.Range(minFlickerDuration, maxFlickerDuration);
            while (Time.time < flickerEndTime)
            {
                Color flickerColor = Random.Range(0f, 1f) * originalGlowColor;
                tempMaterial.SetColor("_GlowColor", flickerColor);
                yield return new WaitForSeconds(flickerFrequency);
            }

            // Change to a new random color
            originalGlowColor = GetRandomColor();
        }
    }

    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, 1.0f);
    }
}
