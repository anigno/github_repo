package controls.labelBase;

import javax.swing.*;
import javax.swing.border.Border;
import java.awt.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

/**
 * borders operation of aLabel mouse events
 */
public class aLabelButton extends aLabel implements MouseListener {

    private Border borderMarked;
    private Border borderUnmarked;

    public aLabelButton(Container container,int width,int height,String text){
        super(container,width,height,text);
        borderMarked=BorderFactory.createEtchedBorder();
        borderUnmarked=BorderFactory.createEmptyBorder();
    }

    public void paint(Graphics g){
        super.paint(g);
    }

    public void mousePressed(MouseEvent e) {
        setBorder(borderUnmarked);
    }
    public void mouseReleased(MouseEvent e) {
        setBorder(borderMarked);
    }
    public void mouseEntered(MouseEvent e) {
        setBorder(borderMarked);
    }
    public void mouseExited(MouseEvent e) {
        setBorder(borderUnmarked);
    }
}
