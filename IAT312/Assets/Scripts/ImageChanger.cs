using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ImageChanger : MonoBehaviour
{
    public Sprite[] images; // Array to hold your images
    public float changeInterval = 2f; // Time interval between image changes
    
    private Image imageComponent;
    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        imageComponent = GetComponent<Image>();
        if (images.Length > 0)
        {
            imageComponent.sprite = images[0]; // Set the initial image
        }
        else
        {
            Debug.LogError("No images assigned to the array!");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        while (timer >= changeInterval)
        {
            ChangeImage();
            timer -= changeInterval;
        }

        // Check for Tab key press to move to the next scene
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("TutorialRoom");
        }
    }

    void ChangeImage()
    {
        if (images.Length > 1)
        {
            currentIndex = (currentIndex + 1) % images.Length;
            imageComponent.sprite = images[currentIndex];

            if (currentIndex == images.Length - 1)
            {
                // Switch to the next scene
                SceneManager.LoadScene("TutorialRoom");
            }
        }
    }
}
