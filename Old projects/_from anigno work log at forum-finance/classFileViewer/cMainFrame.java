import javax.swing.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

public class cMainFrame extends JInternalFrame implements MouseListener {
    public cList list=new cList(this);

    cMainFrame(JDesktopPane desktop,String className){
        super(className);    //set frame caption
        setVisible(true);
        setBounds(0,0,200,200);
        desktop.add(this);
        listInit();
        this.show();
    }//cMainFrame()

    private void listInit(){
        list.list.setBounds(0,0,this.getWidth(),this.getHeight());
        list.list.setVisible(true);
        list.list.addMouseListener(this);
//        list.model.addElement("anigno");
    }//listInit()

    public void mouseReleased(MouseEvent event) {
    }//mouseReleased()
    public void mouseClicked(MouseEvent event) {    }
    public void mouseEntered(MouseEvent event) {    }
    public void mouseExited(MouseEvent event) {     }
    public void mousePressed(MouseEvent event) {    }
}//class cMainFrame
