using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class MenuCardTracker : MonoBehaviour
{
    public ARTrackedImageManager imageManager;

    public CanvasGroup burgerButtonGroup;
    public CanvasGroup pizzaButtonGroup; // assign in inspector
    public CanvasGroup pastaButtonGroup; // assign in inspector
    public CanvasGroup sandwichButtonGroup;
    public CanvasGroup backButtonGroup;


    public GameObject arManager; // 👈 Assign this in the inspector
    public ARPlaneManager arPlaneManager;  // Not GameObject, but component


    
    void OnEnable() => imageManager.trackedImagesChanged += OnImageChanged;
    void OnDisable() => imageManager.trackedImagesChanged -= OnImageChanged;

    void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            if (trackedImage.referenceImage.name == "sath" || trackedImage.referenceImage.name == "menucard2" || trackedImage.referenceImage.name == "menucard3") // match your image name
            {
                burgerButtonGroup.alpha = 1;
                burgerButtonGroup.interactable = true;
                burgerButtonGroup.blocksRaycasts = true;

                pizzaButtonGroup.alpha = 1;
                pizzaButtonGroup.interactable = true;
                pizzaButtonGroup.blocksRaycasts = true;

                
                pastaButtonGroup.alpha = 1;
                pastaButtonGroup.interactable = true;
                pastaButtonGroup.blocksRaycasts = true;

                sandwichButtonGroup.alpha = 1;
                sandwichButtonGroup.interactable = true;
                sandwichButtonGroup.blocksRaycasts = true;

                backButtonGroup.alpha = 1;
                backButtonGroup.interactable = true;
                backButtonGroup.blocksRaycasts = true;

                arManager.SetActive(true);
                arPlaneManager.enabled = true; // Activates plane detection


            }
        }
    }
}
