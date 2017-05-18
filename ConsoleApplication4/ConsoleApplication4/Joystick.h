#pragma once

#ifndef D_INPUT
#define D_INPUT
#include <dinput.h>
#include <iostream>
#endif






class Joystick
{

	// ustawienia
	DIDEVCAPS capabilities;




public:
	Joystick();
	HRESULT poll(DIJOYSTATE *js);
	void GetDesktopResolution(int & horizontal, int & vertical);
	void close();
	int start();
	~Joystick();


};

