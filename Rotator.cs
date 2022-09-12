using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    // Mettre a jour chaque frame
    void Update()
    {
        //Code qui fait L'objet une Rotation sur laxe du Y
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
    }
}
