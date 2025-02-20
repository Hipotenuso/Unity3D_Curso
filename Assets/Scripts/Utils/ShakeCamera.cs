using UnityEngine;
using Unity.Cinemachine;

public class ShakeCamera : MonoBehaviour
{
    public CinemachineCamera cinemachineCamera;  // Referência para a Cinemachine Virtual Camera
    private CinemachineBasicMultiChannelPerlin perlinNoise;  // Referência ao componente de Noise

    public float shakeTime = 0f;  // Tempo de duração do shake

    void Start()
    {
        // Verifique se a Cinemachine Virtual Camera foi atribuída corretamente
        if (cinemachineCamera != null)
        {
            // Obtenha o componente de Noise diretamente da câmera
            perlinNoise = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();

            if (perlinNoise == null)
            {
                Debug.LogError("CinemachineBasicMultiChannelPerlin não encontrado na Cinemachine Virtual Camera!");
            }
        }
        else
        {
            Debug.LogError("Cinemachine Virtual Camera não atribuída ao ShakeCamera!");
        }
    }

    // Função para aplicar o shake
    public void Shake(float amplitude, float frequency, float time)
    {
        if (perlinNoise != null)
        {
            perlinNoise.AmplitudeGain = amplitude;  // Ajuste a intensidade do shake
            perlinNoise.FrequencyGain = frequency;  // Ajuste a frequência do shake
            shakeTime = time;  // Define o tempo para o shake
        }
    }

    void Update()
    {
        // Diminui o tempo de shake
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else if (perlinNoise != null)
        {
            // Quando o tempo de shake termina, zera os valores
            perlinNoise.AmplitudeGain = 0f;
            perlinNoise.FrequencyGain = 0f;
        }
    }

    [NaughtyAttributes.Button]  // Usado para criar um botão no Inspector
    public void Shake()
    {
        Shake(10f, 10f, 10f);  // Chama o shake com os valores padrão (amplitude, frequência, tempo)
    }
}
