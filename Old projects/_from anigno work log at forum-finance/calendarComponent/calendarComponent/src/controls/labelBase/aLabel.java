package controls.labelBase;

import javax.swing.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;
import java.awt.*;

/**
 * flat label with auto font size and alignment, implements events
 */
public class aLabel extends JLabel implements MouseListener {

    public aLabel(Container container,int width,int height,String text){
        container.add(this);
        setText(text);
        setSize(width,height);
        Font font = new Font("Tahoma", Font.PLAIN, height * 3 / 4);
        setFont(font);
        setOpaque(true);
        setHorizontalAlignment(JLabel.CENTER);
        setVerticalAlignment(JLabel.BOTTOM);
        addMouseListener(this);
        container.repaint();
    }

    public void mouseClicked(MouseEvent e) {
    }
    public void mousePressed(MouseEvent e) {
    }
    public void mouseReleased(MouseEvent e) {
    }
    public void mouseEntered(MouseEvent e) {
    }
    public void mouseExited(MouseEvent e) {
    }
}
