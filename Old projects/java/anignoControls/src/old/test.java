package old;


import javax.swing.*;
import javax.swing.event.CaretListener;
import javax.swing.event.CaretEvent;
import java.awt.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

public class test extends JFrame implements
        MouseListener,CaretListener, resizeListener,dragListener{

    Container cPane;
    ctrlTextArea ta;

    public test(){
        super("anignoControls test");
        initFrame();
        ta=new ctrlTextArea(cPane);
        ta.setBounds(10,10,100,200);
        ta.setText("anigno");
        ta.setResizable(true);
        ta.addResizeListener(this);
        ta.addDragListener(this);
        ta.addMouseListener(this);
        ta.addCaretListener(this);
        ta.setBorderColor(Color.green);

    }//test()


    private void initFrame(){
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        cPane=getContentPane();
        setBounds(0,0,600,400);
        cPane.setLayout(null);
        show();
    }//initFrame()

    public static void main(String args[]){
        new test();
    }

    public void mouseClicked(MouseEvent e) {
        System.out.println("clicked");
    }
    public void mouseEntered(MouseEvent e) {
        System.out.println("entered");
    }
    public void mouseExited(MouseEvent e) {
        System.out.println("exited");
    }
    public void mousePressed(MouseEvent e) {
        System.out.println("pressed");
    }
    public void mouseReleased(MouseEvent e) {
        System.out.println("released");
    }

    public void caretUpdate(CaretEvent e) {
        System.out.println("caret");
    }

    public void controlResized(String resizedSide, Object obj) {
        System.out.println(resizedSide);
    }

    public void dragEnd(Object obj) {
        if(obj==ta){
            System.out.println("dragEnd text="+((ctrlTextArea)obj).getText());
        }//if
    }

    public void dragStart(Object obj) {
        System.out.println("dragStart");
    }

}//class test
