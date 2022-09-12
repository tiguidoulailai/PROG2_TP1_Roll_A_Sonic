using UnityEngine;
using System.Collections;

public class GoldRing : MonoBehaviour
{

    // Mettre a jour chaque Frame
    void Update()
    {
        // Une Rotation sur l'axe du Z pour les "Gold Ring"
        transform.Rotate(new Vector3(0, 0, 50) * Time.deltaTime);
    }
}
