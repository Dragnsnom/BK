using System;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public event Action<GameObject> ObjectSelected;


    public List<GameObject> objects = new List<GameObject>();
    public Material highlightMaterial; // Материал для подсветки объектов
    public Material originalMaterial; // Исходный материал объекта
    public GameObject selectedObject; // Текущий выделенный объект


    private Dictionary<GameObject, Material> originalMaterials = new Dictionary<GameObject, Material>();
    private Vector3 offset; // Смещение между позицией объекта и точкой, в которой была нажата левая кнопка мыши



    private void Awake()
    {
        // Находим все объекты с тегом "object" и добавляем их в список
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Object");
        objects.AddRange(objectsWithTag);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // При нажатии левой кнопки мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Проверьте, столкнулся ли луч с каким-либо объектом
            {
                GameObject hitObject = hit.transform.gameObject;

                if (objects.Contains(hitObject)) // Проверьте, является ли объект частью списка управляемых объектов
                {
                    DeselectObject(); // Уберите выделение с текущего объекта (если есть)

                    selectedObject = hitObject; // Установите текущий объект в выделенное состояние
                    Renderer renderer = selectedObject.GetComponent<Renderer>();

                    if (renderer != null)
                    {
                        renderer.material = highlightMaterial; // Установите материал для подсветки
                    }
                }
            }
            else
            {
                DeselectObject(); // Если луч не столкнулся с объектом, снимите выделение с текущего объекта (если есть)
            }
        }

        if (selectedObject != null && Input.GetMouseButton(0)) // Если объект выделен и зажата левая кнопка мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Проверьте, столкнулся ли луч с какой-либо поверхностью
            {
                Vector3 newPosition = selectedObject.transform.position; // Изначально новая позиция равна текущей позиции объекта
                newPosition.x = hit.point.x + offset.x; // Изменяем только координату X
                newPosition.y = hit.point.y + offset.y; // Изменяем только координату Y

                // Установите новую позицию объекта
                selectedObject.transform.position = newPosition;
            }
        }

        if (selectedObject != null)
        {
            // Если выбранный объект изменился, вызовите событие ObjectSelected
            ObjectSelected?.Invoke(selectedObject);
        }
    }

    private void DeselectObject()
    {
        if (selectedObject != null)
        {
            Renderer renderer = selectedObject.GetComponent<Renderer>();

            if (renderer != null)
            {
                // Восстановите оригинальный материал
                Material originalMaterial;
                if (originalMaterials.TryGetValue(selectedObject, out originalMaterial))
                {
                    renderer.material = originalMaterial;
                }
            }

            selectedObject = null; // Сбросьте текущий выделенный объект
        }
    }
    public void SetObjectTransparency(GameObject obj, float transparency)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = renderer.material; // Получаем материал объекта
            Color color = material.color; // Получаем цвет материала
            color.a = transparency; // Устанавливаем альфа-компонент цвета
            material.color = color; // Применяем измененный цвет к материалу
            
        }
    }

    public void SetObjectColor(GameObject obj, Color color)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    public void HideObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}