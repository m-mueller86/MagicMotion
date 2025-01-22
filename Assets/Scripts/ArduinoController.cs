using System;
using System.IO.Ports;
using UnityEngine;

public class ArduinoController : MonoBehaviour
{
    private SerialPort _serialPort;
    public string serialPortName = "/dev/ttyACM0";
    public int baudRate = 9600;
    public float moveSpeed = 0.1f;

    private Vector3 _movementDirection = Vector3.zero;

    void Start()
    {
        _serialPort = new SerialPort(serialPortName, baudRate);
        _serialPort.DtrEnable = true;
        _serialPort.Open();
    }

    void Update()
    {
        if (_serialPort.IsOpen)
        {
            try
            {
                string direction = _serialPort.ReadLine().Trim();
                
                switch (direction)
                {
                    case "left":
                        _movementDirection = new Vector3(0, 0, -moveSpeed);
                        break;
                    case "right":
                        _movementDirection = new Vector3(0, 0, moveSpeed);
                        break;
                    case "up":
                        _movementDirection = new Vector3(0, moveSpeed, 0);
                        break;
                    case "down":
                        _movementDirection = new Vector3(0, -moveSpeed, 0);
                        break;
                    case "left-up":
                        _movementDirection = new Vector3(0, moveSpeed, -moveSpeed);
                        break;
                    case "left-down":
                        _movementDirection = new Vector3(0, -moveSpeed, -moveSpeed);
                        break;
                    case "right-up":
                        _movementDirection = new Vector3(0, moveSpeed, moveSpeed);
                        break;
                    case "right-down":
                        _movementDirection = new Vector3(0, -moveSpeed, moveSpeed);
                        break;
                    default:
                        _movementDirection = Vector3.zero;
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error while reading data: " + ex.Message);
            }
        }
        
        transform.position += _movementDirection * Time.deltaTime;
    }

    void OnDestroy()
    {
        if (_serialPort.IsOpen)
            _serialPort.Close();
    }
}
