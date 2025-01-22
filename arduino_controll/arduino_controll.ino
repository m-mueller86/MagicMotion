#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>

Adafruit_BNO055 bno = Adafruit_BNO055(55);

float offsetZ = 0.0;
float offsetY = 0.0;

//unsigned long lastCalibrationTime = 0;
//const unsigned long calibrationInterval = 5000; 

void setup() {
    Serial.begin(9600);

    if (!bno.begin()) {
        Serial.println("BNO055 nicht gefunden. Überprüfe die Verkabelung!");
        while (1);
    }

    bno.setExtCrystalUse(true);

    PerformCalibration();
}

void loop() {
    sensors_event_t orientationEvent;
    bno.getEvent(&orientationEvent);


  //  if (millis() - lastCalibrationTime >= calibrationInterval) {
  //      PerformCalibration();
  //      lastCalibrationTime = millis();
  //      Serial.println("Kalibrierung durchgeführt.");
  //  }

    float movementZAxis = orientationEvent.orientation.x - offsetZ;
    float movementYAxis = orientationEvent.orientation.y - offsetY;

    
    bool isLeft = (movementZAxis > 320.0 && movementZAxis < 360.0);
    bool isRight = (movementZAxis > 20.0 && movementZAxis < 50.0);
    bool isUp = (movementYAxis > 10.0 && movementYAxis < 30.0);
    bool isDown = (movementYAxis < -10.0 && movementYAxis > -30.0);

    // Bewegungsrichtung ausgeben
    if (isLeft && isUp) {
        Serial.println("left-up");
    } else if (isLeft && isDown) {
        Serial.println("left-down");
    } else if (isRight && isUp) {
        Serial.println("right-up");
    } else if (isRight && isDown) {
        Serial.println("right-down");
    } else if (isLeft) {
        Serial.println("left");
    } else if (isRight) {
        Serial.println("right");
    } else if (isUp) {
        Serial.println("up");
    } else if (isDown) {
        Serial.println("down");
    } else {
        Serial.println("idle");
    }

    delay(50); // Datenrate anpassen
}

void PerformCalibration() {
    sensors_event_t orientationEvent;
    bno.getEvent(&orientationEvent);

    // Aktuelle Werte als Offset speichern
    offsetZ = orientationEvent.orientation.x;
    offsetY = orientationEvent.orientation.y;
}
