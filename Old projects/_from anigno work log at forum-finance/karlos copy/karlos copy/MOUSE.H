#define MOUSE 0X33
  void activmouse()
  {
		 /* activate mouse */
		 _AX=32;
		 geninterrupt(MOUSE);
  }

  int resetmouse()
  {
		 /* mouse reset */
		 _AX=0;
		 geninterrupt(MOUSE);
		 return(_AX);
  }

  void showmouse()
  {
		 /* turn on mouse cursor */
		 _AX=1;
		 geninterrupt(MOUSE);
  }

  void hidemouse()
  {
		 /* turn off mouse cursor */
		 _AX=2;
		 geninterrupt(MOUSE);
  }

  void readmouse(int *v,int *h,int *but)
  {
		 int temp;
		 _AX=3;
		 geninterrupt(MOUSE);

		 // which buttons pressed: 1=left, 2=right, 3=both
		 temp=_BX;
		 *but=temp;

		 // horizontal coordinates
		 *h =_CX;

		 // vert coordinates
		 *v=_DX;
  }
