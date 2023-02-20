using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDirector : MonoBehaviour
{
    public GameObject character;
    public GameObject initialStreet;
    public GameObject streetPrefab;
    private List<GameObject> activeStreets;

    void Start()
    {
        activeStreets = new List<GameObject> { initialStreet };
    }

    void Update()
    {
        // The first street in the list will always be the active one
        var activeStreet = activeStreets[0];

        if (activeStreets.Count == 1)
        {
            // We need to spawn new street once we reach the limit
            Vector3 streetRelative = activeStreet.transform.InverseTransformPoint(character.transform.position);
            if (streetRelative.z >= 30)
            {
                var newStreetPosition = new Vector3(activeStreet.transform.position.x, activeStreet.transform.position.y, activeStreet.transform.position.z + 60);
                var newStreet = Instantiate(streetPrefab, newStreetPosition, Quaternion.identity);
                newStreet.transform.SetParent(activeStreet.transform.parent);
                activeStreets.Add(newStreet);
            }
        }
        else if (activeStreets.Count == 2)
        {
            // We need to check if we reached the next street to delete the previous one
            var nextStreet = activeStreets[1];
            Vector3 streetRelative = nextStreet.transform.InverseTransformPoint(character.transform.position);
            if (streetRelative.z >= 2)
            {
                activeStreets.RemoveAt(0);
                Destroy(activeStreet);
            }
        }
    }
}
