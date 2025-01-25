using System.IO.Ports;
using UnityEngine;

public class PatternSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] patterns;
    // private SerialPort _serialPort;
    // public string portName = "/dev/ttyACM0";
    // public int baudRate = 9600;
    
    // Start is called before the first frame update
    void Start()
    {
        // _serialPort = new SerialPort(portName, baudRate);
        // _serialPort.DtrEnable = true;
        // _serialPort.Open();
        
        SpawnPattern(0);
    }
    
    public void SpawnPattern(int patternIndex)
    {
        // SendCalibrationCommand();
        GameObject patternPrefab = patterns[patternIndex];
        SpawnPositionSaver spawnPositionSaver = patternPrefab.GetComponent<SpawnPositionSaver>();
        Instantiate(patternPrefab, spawnPositionSaver.spawnPosition, spawnPositionSaver.spawnRotation);
    }
    
    // private void SendCalibrationCommand()
    // {
    //     if (_serialPort.IsOpen)
    //     {
    //         _serialPort.WriteLine("calibrate");
    //         Debug.Log("Calibration command sent");
    //     }
    //     else
    //     {
    //         Debug.LogError("Serial port is not open");
    //     }
    // }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
