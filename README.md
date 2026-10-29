# DishPlacerAR

Android AR restaurant-menu app (Unity 2022.3.43f1, AR Foundation 5.1 + ARCore). Pointing the phone at a
printed menu card (image tracking) reveals dish buttons; tapping one places a 3D model of the dish
(burger, pizza, pasta, sandwich) on a detected surface, shows its nutrition facts, and lets the user add
it to an order. Orders are posted to a SheetDB endpoint (a Google Sheet).

## Scene flow (Build Settings order)

| # | Scene | Purpose |
| --- | --- | --- |
| 0 | `Assets/TextMesh Pro/SampleScene.unity` | leftover TextMeshPro sample, safe to remove from Build Settings |
| 1 | `Assets/scene2.unity` | main AR scene: menu-card tracking, dish placement, nutrition panel (`MenuCardTracker.cs`, `PlaceDish.cs`, `*Interaction.cs`) |
| 2 | `Assets/WelcomeScene.unity` | welcome / splash (`WelcomeScreenController.cs`, `Welcome2.cs`) |
| 3 | `Assets/test.unity` | experiment scene |
| 4 | `Assets/Order.unity` | order summary and submit (`OrderManager.cs`) |

Reference images for tracking (`sath`, `menucard2`, `menucard3`) live in the XR Reference Image Library
under `Assets/`; 3D models are under `Assets/Models/`.

## How to run

1. Install Unity Hub and Unity **2022.3.43f1** with the *Android Build Support* module (OpenJDK, SDK and NDK).
2. Clone this repository and open the folder in Unity Hub (Add > Add project from disk). First open takes
   several minutes while the `Library` folder is regenerated.
3. Optional: change `sheetDbUrl` in `Assets/Scripts/OrderManager.cs` to your own SheetDB sheet.
4. File > Build Settings > Android > Switch Platform, then *Build And Run* with an ARCore-capable phone
   connected over USB (USB debugging enabled). Print one of the reference menu-card images to test tracking.

## Packages

ARCore XR Plugin 5.1.6 (AR Foundation pulled in as a dependency), TextMeshPro 3.0.6. Restored
automatically from `Packages/manifest.json` on first open.

Note: `Assets/Models/sandwich/source/foood/foood.obj` is 81 MB, under GitHub's 100 MB per-file limit but
above its 50 MB warning threshold. It is committed as a normal file.
