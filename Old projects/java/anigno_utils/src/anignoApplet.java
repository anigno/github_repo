import javax.swing.*;
import java.awt.*;

public class anignoApplet extends JApplet{
    int width=0;
    int height=0;
    Image backBuffer;
    Graphics Graphics;

    public void aSetSize(int width,int height){
        this.width = width;
        this.height=height;
        setSize(width,height);
        width=this.getSize().width;
        height=this.getSize().height;
        backBuffer=createImage(width,height);   //create the buffer Image
        Graphics=backBuffer.getGraphics();
    }//setSize()
    
    public void init(){
        //must be override
    }//init()

    public void paint(Graphics g){
        update(g);
    }//paint()

    public void update(Graphics g){
        g.drawImage( backBuffer, 0, 0, this );
    }//update()


}//class anignoApplet
