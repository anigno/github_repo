#ifndef __ANIGNO_LIBRARY__
#define __ANIGNO_LIBRARY__

#include <Arduino.h>

class AnignoLibrary
{
	private:
	public:
	String GetString(double d,int p);
	void SerialPrintlnValue(String name,float value,String units);
	float GetFloatAverage(float floats[],int nFloats);
	int GetSonicDistanceCm(int trigPin,int echoPin,int maxLimitCm);
	
};

#endif
