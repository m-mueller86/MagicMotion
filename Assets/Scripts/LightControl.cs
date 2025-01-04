using UnityEngine;
using System.IO.Ports;

public class LightControl : MonoBehaviour
{
    SerialPort serialPort;
    public Light spotlight;
    
    public float scaleFactor = 0.05f;

    void Start()
    {
        serialPort = new SerialPort("/dev/ttyACM0", 9600);
        serialPort.DtrEnable = true; // Notwendig für Arduino Nano
        serialPort.Open();
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                // Lese die Orientierungsdaten vom Arduino
                string data = serialPort.ReadLine();
                string[] values = data.Split(',');

                // Parse die Orientierungsdaten
                float roll = float.Parse(values[0]);
                float pitch = float.Parse(values[1]);
                float yaw = float.Parse(values[2]);  

                // Ordne die Daten den richtigen Bewegungen zu
                float moveZ = yaw * scaleFactor;
                float moveY = pitch * scaleFactor;

                // Begrenze die Bewegungen
                moveZ = Mathf.Clamp(moveZ, 5f, 15f);
                moveY = Mathf.Clamp(moveY, -2f, 2f);

                // Setze die Position des Lichtkegels
                spotlight.transform.position = new Vector3(
                    spotlight.transform.position.x,
                    moveY, 
                    moveZ
                );
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Fehler beim Lesen der Daten: " + ex.Message);
            }
        }
    }

    void OnDestroy()
    {
        if (serialPort.IsOpen)
            serialPort.Close();
    }
}
