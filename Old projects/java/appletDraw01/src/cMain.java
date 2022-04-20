import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionListener;

public class cMain extends JApplet implements MouseListener,MouseMotionListener{
    int width,height;   //size of applet
    Image backBuffer;   //buffer to draw on
    Graphics G;                     //Graphics to use for drawing on buffer

    public void init(){
        this.setSize(640,480);
        this.addMouseMotionListener(this);
        width=this.getSize().width;
        height=this.getSize().height;
        backBuffer=createImage(width,height);   //create the buffer Image
        G=backBuffer.getGraphics();
        G.setColor(Color.BLUE);
        G.fillRect(0,0,width,height);
        G.setColor(Color.YELLOW);
    }//init()

    public void paint(Graphics g){
        update(g);
    }//paint()

    public void update( Graphics g ) {
       g.drawImage( backBuffer, 0, 0, this );
    }

    public void mouseDragged(MouseEvent e) {
        int x = e.getX();
        int y = e.getY();
        G.fillOval(x-5,y-5,10,10);
        repaint();
        e.consume();
    }

    public void mousePressed(MouseEvent event) {    }
    public void mouseClicked(MouseEvent event) {    }
    public void mouseEntered(MouseEvent event) {    }
    public void mouseExited(MouseEvent event) {    }
    public void mouseReleased(MouseEvent event) {    }
    public void mouseMoved(MouseEvent event) {    }
}//class cMain
