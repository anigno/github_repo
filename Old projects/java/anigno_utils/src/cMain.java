import java.awt.*;

public class cMain extends anignoApplet{
    public void init(){
        aSetSize(400,200);
        Graphics.setColor(Color.BLUE);
        Graphics.fillRect(0,0,width,height);
        Graphics.setColor(Color.YELLOW);
        Graphics.drawLine(10,10,100,100);


    }

}//class cMain
