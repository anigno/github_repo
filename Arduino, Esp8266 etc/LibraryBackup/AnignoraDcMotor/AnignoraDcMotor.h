#ifndef __ANIGNO_DC_MOTOR__
#define __ANIGNO_DC_MOTOR__

#include <Arduino.h>

class AnignoraDcMotor
{
	private:
	int pinMotorsDriverEnable;
	int pinMotorRightControlA;
	int pinMotorRightControlB;
	int pinMotorLeftControlA;
	int pinMotorLeftControlB;
	int maxSpeed;

	public:
	AnignoraDcMotor(int pinLeftA,int pinLeftB,int pinRightA,int pinRightB,int pinEnable,int maximumSpeed)
	{
		pinMotorsDriverEnable=pinEnable;
		pinMotorRightControlA=pinRightA;
		pinMotorRightControlB=pinRightB;
		pinMotorLeftControlA=pinLeftA;
		pinMotorLeftControlB=pinLeftB;
		maxSpeed=maximumSpeed;
		pinMode(pinMotorsDriverEnable,OUTPUT);
		pinMode(pinMotorRightControlA,OUTPUT);
		pinMode(pinMotorRightControlB,OUTPUT);
		pinMode(pinMotorLeftControlA,OUTPUT);
	 pinMode(pinMotorLeftControlB,OUTPUT);
	}
	
	void driveFwd()
	{
	  digitalWrite(pinMotorsDriverEnable,HIGH);
	  analogWrite(pinMotorRightControlA,maxSpeed);
	  analogWrite(pinMotorRightControlB,0);
	  analogWrite(pinMotorLeftControlA,maxSpeed);
	  analogWrite(pinMotorLeftControlB,0);
	}

	void driveBck()
	{
	  digitalWrite(pinMotorsDriverEnable,HIGH);
	  analogWrite(pinMotorRightControlA,0);
	  analogWrite(pinMotorRightControlB,maxSpeed);
	  analogWrite(pinMotorLeftControlA,0);
	  analogWrite(pinMotorLeftControlB,maxSpeed);
	}

	void driveBckRt()
	{
	  digitalWrite(pinMotorsDriverEnable,HIGH);
	  analogWrite(pinMotorRightControlA,maxSpeed);
	  analogWrite(pinMotorRightControlB,0);
	  analogWrite(pinMotorLeftControlA,0);
	  analogWrite(pinMotorLeftControlB,maxSpeed);
	}

	void driveBckLt()
	{
	  digitalWrite(pinMotorsDriverEnable,HIGH);
	  analogWrite(pinMotorRightControlA,0);
	  analogWrite(pinMotorRightControlB,maxSpeed);
	  analogWrite(pinMotorLeftControlA,maxSpeed);
	  analogWrite(pinMotorLeftControlB,0);
	}

	void driveStop()
	{
	  analogWrite(pinMotorsDriverEnable,LOW);
	  analogWrite(pinMotorRightControlA,0);
	  analogWrite(pinMotorRightControlB,0);
	  analogWrite(pinMotorLeftControlA,0);
	  analogWrite(pinMotorLeftControlB,0);
	}

};

#endif
