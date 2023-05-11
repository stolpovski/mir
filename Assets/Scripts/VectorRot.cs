using UnityEngine;
using TMPro;

public class VectorRot : MonoBehaviour
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
        textmeshPro.SetText("{0:.00}\n{1:.00}\n{2:.00}", target.transform.rotation.eulerAngles.x, target.transform.rotation.eulerAngles.y, target.transform.rotation.eulerAngles.z);
    }
}
