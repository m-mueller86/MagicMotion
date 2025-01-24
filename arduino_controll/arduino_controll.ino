#include "Arduino_BMI270_BMM150.h"
#include <MadgwickAHRS.h>
#include <cmath>

// Madgwick-Filter initialisieren
Madgwick filter;
unsigned long lastUpdate = 0;
float accX, accY, accZ;
float gyroX, gyroY, gyroZ;
float timeOffset = 0.0;
unsigned long lastTimeOffsetUpdate = 0;
const unsigned long timeOffsetInterval = 8000;

void setup() {
    Serial.begin(9600);
    while (!Serial);

    if (!IMU.begin()) {
        Serial.println("Failed to initialize IMU!");
        while (1);
    }

    Serial.println("IMU initialized successfully!");

    // Madgwick-Filter
    filter.begin(50);
}

void loop() {
    if (IMU.accelerationAvailable() && IMU.gyroscopeAvailable()) {
        IMU.readAcceleration(accX, accY, accZ);
        IMU.readGyroscope(gyroX, gyroY, gyroZ);

        // Madgwick-Filter aktualisieren
        filter.updateIMU(gyroX, gyroY, gyroZ, accX, accY, accZ);

        float yaw = fmod(filter.getYaw() + timeOffset, 360);


        if (accX < -0.3 && yaw > 190.0) {
          Serial.println("left-down");
        } else if (accX > 0.3 && yaw > 190.0) {
          Serial.println("left-up");
        } else if (accX > 0.3 && yaw < 170.0) {
          Serial.println("right-up");
        } else if (accX < -0.3 && yaw < 170.0) {
          Serial.println("right-down");
        } else if (accX > 0.3) {
          Serial.println("up");
        } else if (accX < -0.3) {
          Serial.println("down");
        } else if (yaw > 190.0) {
          Serial.println("left");
        } else if (yaw < 170.0) {
          Serial.println("right");
        } else {
          Serial.println("idle");
        }
    }

    unsigned long currentTime = millis();
    if (currentTime - lastTimeOffsetUpdate >= timeOffsetInterval) {
        timeOffset += 1.0;
        lastTimeOffsetUpdate = currentTime;

    }

    delay(20);
}

