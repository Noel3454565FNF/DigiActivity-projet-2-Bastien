using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeRotation : MonoBehaviour
{
    public GameObject cube;
    float rotationSpeed = 90f; 
    float rotationTime;
    public TextMeshProUGUI chronometerText;
    float rotationCooldown = 10f;
    public Transform from;
    public Transform to;
    float speed = 1f;
    float timeCount = 0.0f;
    bool isRotating = false;
    private int rotationCubeInt = 90;// la valeur dont le cube va tourner toutes les 10 secondes
    public int numberRotations = 1; // initialiser la variable numberRotations

    private void Update()
    {
        if(!isRotating)
        {
            rotationTime += Time.deltaTime;
            chronometerText.text = (rotationCooldown - rotationTime).ToString("F2");
            //print(rotationTime);
            if (rotationTime >= rotationCooldown)
            {
                isRotating = true;
                StartCoroutine(RotationCoroutine());
                rotationTime = 0f;
            }
        }  
    }

    IEnumerator RotationCoroutine()
    {
        if (numberRotations == 1) // Lancer la coroutine une seule fois si numberRotations == 1
        {
            float t = 0f;
            while (t < 1)
            {
                yield return null;
                t += Time.deltaTime * speed;
                transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, t);
            }
            transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, 1);
            isRotating = false;
            from.rotation = Quaternion.Euler(from.rotation.eulerAngles.x , from.rotation.eulerAngles.y, from.rotation.eulerAngles.z + rotationCubeInt);
            to.rotation = Quaternion.Euler(to.rotation.eulerAngles.x, to.rotation.eulerAngles.y, to.rotation.eulerAngles.z + rotationCubeInt);
        }
        else if (numberRotations > 1) // Lancer la coroutine pour chaque rotation
        {
            for (int i = 0; i < numberRotations; i++)
            {
                float t = 0f;
                while (t < 1)
                {
                    yield return null;
                    t += Time.deltaTime * speed;
                    transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, t);
                }
                transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, 1);
                isRotating = false;
                yield return new WaitForSeconds(1f); // Attendre 2 secondes entre chaque rotation
                from.rotation = Quaternion.Euler(from.rotation.eulerAngles.x , from.rotation.eulerAngles.y, from.rotation.eulerAngles.z + rotationCubeInt);
                to.rotation = Quaternion.Euler(to.rotation.eulerAngles.x, to.rotation.eulerAngles.y, to.rotation.eulerAngles.z + rotationCubeInt);
            }
        }
    }
}