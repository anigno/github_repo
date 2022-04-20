package anignoControls.ctrlList;

import javax.swing.*;
import java.awt.*;

public class ctrlList {

    private JList list;
    private JScrollPane scrollPane;
    private DefaultListModel listModel;

    public ctrlList(Container cPane){
        listModel=new DefaultListModel();
        list=new JList(listModel);
        scrollPane=new JScrollPane(list);
        cPane.add(scrollPane);
        listModel.addElement("");
    }//ctrlList()

    public JList getJList(){
        return list;
    }
    public JScrollPane getJScrollPane(){
        return scrollPane;
    }
    public DefaultListModel getDefaultListModel(){
        return listModel;
    }

    public void addElement(Object obj){
        listModel.addElement(obj);
    }

}//class ctrlList
