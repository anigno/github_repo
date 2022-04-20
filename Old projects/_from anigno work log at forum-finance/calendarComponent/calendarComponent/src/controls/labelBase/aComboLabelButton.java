package controls.labelBase;

import controls.labelBase.aLabelButton;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseEvent;

/**
 * aLabelButton with combo isOpen parameter and drawn rectangle to indicate it's class
 */
public class aComboLabelButton extends aLabelButton{

    private boolean _isOpen;

    public aComboLabelButton(Container container, int width, int height, String text) {
        super(container, width, height, text);
        _isOpen=false;
        setHorizontalAlignment(JLabel.LEFT);
        //super already added MouseListener
    }

    private void drawTriangle(Graphics g){
        int w=getWidth();
        int h=getHeight();
        int x[]={w-h+4,w-4,w-h/2};
        int y[]={4,4,h-4};
        g.setColor(getForeground());
        g.fillRect(w-h+2,1,h-4,h-3);
        g.setColor(getBackground());
        g.fillPolygon(x,y,3);
    }

    /**
     * the state of the combo
     * @return true if combo is open, otherwise false, text is aligned left
     */
    public boolean isOpen(){
        return _isOpen;
    }

    public void paint(Graphics g){
        super.paint(g);
        drawTriangle(g);
    }

    public void mouseClicked(MouseEvent e) {
        super.mouseClicked(e);
        _isOpen=!_isOpen;
    }

}
