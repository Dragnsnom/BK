using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public ObjectManager objectManager;
    public Slider transparencySlider;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Toggle hide;

    private GameObject selectedObject;

    private void Start()
    {
        transparencySlider.onValueChanged.AddListener(ChangeTransparency);
        redSlider.onValueChanged.AddListener(ChangeColor);
        greenSlider.onValueChanged.AddListener(ChangeColor);
        blueSlider.onValueChanged.AddListener(ChangeColor);
        hide.onValueChanged.AddListener(Hide);


        // Подпишемся на событие ObjectSelected в ObjectManager
        objectManager.ObjectSelected += OnObjectSelected;
    }



    private void OnObjectSelected(GameObject newSelectedObject)
    {
        selectedObject = newSelectedObject;
        UpdateUIValues();
    }

    private void UpdateUIValues()
    {
        Color color = selectedObject.GetComponent<Renderer>().material.color;
        transparencySlider.value = color.a;
        redSlider.value = color.r;
        greenSlider.value = color.g;
        blueSlider.value = color.b;
    }

    private void ChangeSelectedObject(int index)
    {
        selectedObject = objectManager.objects[index];
        UpdateUIValues();
    }

    private void ChangeTransparency(float value)
    {
        if (selectedObject != null)
        {
            objectManager.SetObjectTransparency(selectedObject, value);
        }
    }

    private void ChangeColor(float value)
    {
        if (selectedObject != null)
        {
            Color color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
            objectManager.SetObjectColor(selectedObject, color);
        }
    }

    private void Hide(bool arg0)
    {
        if (selectedObject != null)
        {
            objectManager.HideObject(selectedObject);
        }
    }
}
