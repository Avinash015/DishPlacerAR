using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
[System.Serializable]
public class Dish
{
    public string name;
    public int price;
}

public class OrderManager : MonoBehaviour
{
    public List<Dish> orderList = new List<Dish>();
    public string sheetDbUrl = "https://sheetdb.io/api/v1/xgkztv8wfd455";
    public void AddBurgerToOrder()
    {
        AddToOrder("Burger", 120);
    }

    public void AddPizzaToOrder()
    {
        AddToOrder("Pizza", 180);
    }

    public void AddPastaToOrder()
    {
        AddToOrder("Pasta", 150);
    }
    public void AddSandwichToOrder()
    {
        AddToOrder("Sandwich", 150);
    }


    public void AddToOrder(string dishName, int price)
    {
        Dish newDish = new Dish { name = dishName, price = price };
        orderList.Add(newDish);
        Debug.Log($"✅ Added {dishName} to order. ₹{price}");
    }

    public void PrintOrderSummary()
    {
        Debug.Log("📋 Current Order:");
        int total = 0;
        foreach (var dish in orderList)
        {
            Debug.Log($"- {dish.name}: ₹{dish.price}");
            total += dish.price;
        }
        Debug.Log($"Total: ₹{total}");
    }
    public void ConfirmOrder()
    {
        if (orderList.Count == 0)
        {
            Debug.LogWarning("🛒 Order is empty!");
            return;
        }

        foreach (var dish in orderList)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string json = "{\"data\": [{\"Dish\": \"" + dish.name + "\", \"Quantity\": \"1\", \"Notes\": \"From DishAR\", \"Time\": \"" + timeStamp + "\"}]}";

            StartCoroutine(SendToSheet(json));
        }

        Debug.Log("📤 Order sent to chef!");
    }

    IEnumerator SendToSheet(string json)
    {
        UnityWebRequest req = new UnityWebRequest(sheetDbUrl, "POST");
        byte[] body = Encoding.UTF8.GetBytes(json);

        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("✅ Order submitted successfully.");
        }
        else
        {
            Debug.LogError("❌ Order failed: " + req.error);
        }
    }
}