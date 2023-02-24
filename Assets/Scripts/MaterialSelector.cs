using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSelector : MonoBehaviour
{
    public List<Material> AvailableMaterials;

    void Start()
    {
        var randomN = Random.Range(0, AvailableMaterials.Count - 1);
        var selectedMaterial = AvailableMaterials[randomN];

        var renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material = selectedMaterial;
    }
}
