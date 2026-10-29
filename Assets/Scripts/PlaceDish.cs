using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class Nutrients
{
    public string dishName;
    public int calories;
    public int protein;
    public int carbs;
    public int fats;
}
public class PlaceDish : MonoBehaviour
{
    public GameObject burgerPrefab;
    public GameObject pizzaPrefab;
    public GameObject pastaPrefab;
    public GameObject sandwichPrefab;
    
    public ARRaycastManager raycastManager;
    public Button burgerButton;
    public Button pizzaButton;
    public Button pastaButton;
    public Button sandwichButton;
    

    private GameObject spawnedObject;


    public GameObject nutrientPanel;
public TextMeshProUGUI dishText;
public TextMeshProUGUI caloriesText;
public TextMeshProUGUI proteinText;
public TextMeshProUGUI carbsText;
public TextMeshProUGUI fatsText;

private Dictionary<string, Nutrients> nutrientsData = new Dictionary<string, Nutrients>();

    void Start()
    {
        nutrientsData.Add("Burger", new Nutrients { dishName = "Burger", calories = 450, protein = 25, carbs = 30, fats = 20 });
        nutrientsData.Add("Pizza", new Nutrients { dishName = "Pizza", calories = 700, protein = 30, carbs = 80, fats = 25 });
        nutrientsData.Add("Pasta", new Nutrients { dishName = "Pasta", calories = 600, protein = 15, carbs = 70, fats = 18 });
        nutrientsData.Add("Sandwich", new Nutrients { dishName = "Sandwich", calories = 300, protein =35, carbs = 40, fats = 20 });

        burgerButton.onClick.AddListener(() => PlaceDishOnPlane(burgerPrefab, "Burger"));
        pizzaButton.onClick.AddListener(() => PlaceDishOnPlane(pizzaPrefab, "Pizza"));
        pastaButton.onClick.AddListener(() => PlaceDishOnPlane(pastaPrefab, "Pasta"));
        sandwichButton.onClick.AddListener(() => PlaceDishOnPlane(sandwichPrefab, "Sandwich"));

        nutrientPanel.SetActive(false);
    }
    

    public void PlaceDishOnPlane(GameObject dishPrefab, string dishName)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (spawnedObject != null) Destroy(spawnedObject);

            Vector3 adjustedPosition = hitPose.position;

            if (dishPrefab == pizzaPrefab)
            {
                adjustedPosition.y += 0.05f; // lift pizza 5cm above the plane (adjust if needed)
            }

            spawnedObject = Instantiate(dishPrefab, adjustedPosition, hitPose.rotation);

            if (dishPrefab == pizzaPrefab)
                spawnedObject.transform.localScale = new Vector3(0.0065f, 0.0065f, 0.0065f);

            if (dishPrefab == burgerPrefab)
                spawnedObject.transform.Rotate(-90, 90, 90);
            if (dishPrefab == pastaPrefab)
                spawnedObject.transform.Rotate(-90, 180, 90);
            if (dishPrefab == sandwichPrefab)
                spawnedObject.transform.Rotate(-90, 180, 90);
            ShowNutrients(dishName);

        }
    }
    void ShowNutrients(string dishName)
    {
        if (nutrientsData.ContainsKey(dishName))
        {
            Nutrients n = nutrientsData[dishName];
            dishText.text = n.dishName;
            caloriesText.text = $"Calories: {n.calories}";
            proteinText.text = $"Protein: {n.protein}g";
            carbsText.text = $"Carbs: {n.carbs}g";
            fatsText.text = $"Fats: {n.fats}g";

            nutrientPanel.SetActive(true);
        }
    }

}