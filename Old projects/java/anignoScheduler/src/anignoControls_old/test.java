package anignoControls_old;

import anignoControls_old.ctrlTextField;

import javax.swing.*;
import java.awt.*;

import anignoControls_old.ctrlList;
import anignoControls_old.ctrlTextField;

public class test extends JFrame{

    Container cPane;
    ctrlList list;

    public test(){
        super("ctrlTextFieldTest");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        cPane=getContentPane();
        setBounds(0,0,800,600);
        cPane.setLayout(null);
        show();

        list=new ctrlList(cPane);
        list.setLocation(50,50);
        ctrlTextField text=new ctrlTextField(cPane);
        list.addElement(text);
        text.setPosition(5,10,1,0);

        JTextArea ta=new JTextArea("1234");
        JScrollPane js=new JScrollPane(ta);
        js.setBounds(200,200,100,100);
        cPane.add(js);


    }



    public static void main(String args[]){
        new test();
    }
}
