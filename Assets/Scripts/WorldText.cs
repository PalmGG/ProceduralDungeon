using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;

public class WorldText //CodeMonkey https://www.youtube.com/watch?v=waEsGu--9P8&list=PLzDRvYVwl53uhO8yhqxcyjDImRjO9W722
{
    public static TextMesh CreateWorldText(string tag, string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 5000)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(tag, parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }
    public static TextMesh CreateWorldText(string tag, Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        gameObject.tag = tag;
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        transform.rotation = Quaternion.Euler(90, 0, 0);
        return textMesh;
        
    }
}
