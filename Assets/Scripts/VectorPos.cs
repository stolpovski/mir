using UnityEngine;
using TMPro;

public class VectorPos : MonoBehaviour
{
    TMP_Text textmeshPro;
    GameObject target;

    void Start()
    {
        textmeshPro = GetComponent<TMP_Text>();
        Debug.Log(textmeshPro);
        target = GameObject.Find("Cosmonaut");
    }

    void Update()
    {
        textmeshPro.SetText("{0:.00}\n{1:.00}\n{2:.00}", target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }
}
