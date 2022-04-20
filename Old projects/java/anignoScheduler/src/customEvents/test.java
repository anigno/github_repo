package customEvents;

import javax.swing.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

/**
 * test class
 * implement the listeners used in this demo
 */
public class test extends JFrame implements MouseListener,textButtonTextChangedListener{

    textButton tb=new textButton(); //the new custom control

    public test(){
        //frame init
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(800,600);
        getContentPane().setLayout(null);
        show();
        //textButton init
        getContentPane().add(tb);
        tb.setBounds(50,60,100,200);
        tb.addMouseListener(this);
        tb.addTextChangedListener(this);
    }

    //entry point to the application
    public static void main(String args[]){
        new test();
    }

    public void mousePressed(MouseEvent e) {
        //getSource will return the textButton control
        System.out.println(e.getSource());
    }

    public void mouseClicked(MouseEvent e) {
    }

    public void mouseEntered(MouseEvent e) {
    }

    public void mouseExited(MouseEvent e) {
    }

    public void mouseReleased(MouseEvent e) {
    }

    public void textButtonTextChanged(textButtonTextChangedEvent event) {
        //newText will be the changed text in the textButton custom control
        System.out.println(event.newText);
    }
}
