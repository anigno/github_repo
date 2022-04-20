package gui;

import javax.swing.*;
import javax.swing.event.ListSelectionListener;
import javax.swing.event.ListSelectionEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;
import java.awt.event.ActionEvent;

public class mainFrame extends JFrame implements MouseListener,ListSelectionListener{
    DefaultListModel listModel=new DefaultListModel();
    JList list=new JList(listModel);
    JScrollPane scrollPane=new JScrollPane(list);

    public mainFrame(String title){
        super(title);
        initComponents();
    }//mainFrame()

    private  void initComponents(){
        initMainFrame();
        initListBox();
    }

    private void initListBox(){
        getContentPane().add(scrollPane);
        scrollPane.setBounds(70,50,100,480+5);
        list.addMouseListener(this);
        list.addListSelectionListener(this);
        list.setFixedCellHeight(20);
        list.setSelectionMode(ListSelectionModel.MULTIPLE_INTERVAL_SELECTION);
        for(int i=0;i<24;i++){
            listModel.addElement("___________");
        }//for
        JTextArea text=new JTextArea("anigno");
        list.add(text);
        text.setBounds(0,20,80,40);
        text=new JTextArea("anigno");
        list.add(text);
        text.setBounds(0,100,40,60);
        text=new JTextArea("anigno");
        list.add(text);
        text.setBounds(40,120,40,60);

    }

    private void initMainFrame(){
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(800,600);
        getContentPane().setLayout(null);
        show();
    }

    int selStart=-1;
    int selEnd=-1;
    public void mousePressed(MouseEvent e) {
        int i=e.getY()/20;
        selStart=i;
    }
                         int sel[];
    public void mouseReleased(MouseEvent e) {
        int i=e.getY()/20;
        selEnd=i;
        System.out.println("sel="+selStart+" "+selEnd);
        sel=new int[selEnd-selStart+1];
        for(int j=0;j<selEnd-selStart+1;j++)sel[j]=selStart+j;
        list.setSelectedIndices(sel);
        Object o=list.getSelectedIndices();
    }

    public void valueChanged(ListSelectionEvent e) {
        System.out.println(""+e.getFirstIndex()+" "+e.getLastIndex());
    }


    public void mouseClicked(MouseEvent e) {
        //To change body of implemented methods use File | Settings | File Templates.
    }

    public void mouseEntered(MouseEvent e) {
        //To change body of implemented methods use File | Settings | File Templates.
    }

    public void mouseExited(MouseEvent e) {
        //To change body of implemented methods use File | Settings | File Templates.
    }

    public void actionPerformed(ActionEvent e) {
    }

}//class mainFrame
