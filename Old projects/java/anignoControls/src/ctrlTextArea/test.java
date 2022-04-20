package ctrlTextArea;

import javax.swing.*;
import javax.swing.event.CaretListener;
import javax.swing.event.CaretEvent;
import java.awt.*;

public class test extends JFrame implements CaretListener{

    Container cPane;
    ctrlTextArea ta;

    public test(){
        super("test");
        cPane=getContentPane();
        cPane.setLayout(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setBounds(0,0,600,400);
        show();

        JTextArea text=new JTextArea("");
        cPane.add(text);
        text.setBounds(300,100,200,200);

        ta=new ctrlTextArea(cPane);
        ta.setBounds(10,10,100,200);
        ta.setBorderColor(Color.green);
        ta.addCaretListener(this);

    }
    public static void main(String args[]){
        new test();
    }

    /**
     * Called when the caret position is updated.
     *
     * @param e the caret event
     */
    public void caretUpdate(CaretEvent e) {
        if(e.getSource()==ta.getJTextArea())System.out.println("test caretUpdate");
    }

}//class test
