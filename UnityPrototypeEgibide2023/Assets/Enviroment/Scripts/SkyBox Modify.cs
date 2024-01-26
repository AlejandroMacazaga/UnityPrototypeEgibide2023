using UnityEngine;

public class RotarSkybox : MonoBehaviour
{
    public float velocidadRotacion = 0.5f; // Velocidad de rotaci�n del skybox

    private void Update()
    {
        // Obtener el material del skybox
        Material skyboxMaterial = RenderSettings.skybox;

        // Obtener el �ngulo de rotaci�n actual
        float rotation = skyboxMaterial.GetFloat("_Rotation");

        // Aumentar gradualmente el �ngulo de rotaci�n en el tiempo
        rotation += velocidadRotacion * Time.deltaTime;

        // Aplicar la rotaci�n al material del skybox
        skyboxMaterial.SetFloat("_Rotation", rotation);
    }
}
