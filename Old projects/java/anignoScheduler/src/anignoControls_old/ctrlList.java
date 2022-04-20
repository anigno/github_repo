package anignoControls_old;

import javax.swing.*;
import java.awt.*;

public class ctrlList extends JScrollPane{

    DefaultListModel listModel=new DefaultListModel();  //data holder
    JList list=new JList(listModel);                                           //viewPort component



    public ctrlList(Container cPane){
        super();
        cPane.add(this);
        initControl();
    }

    private void initControl(){
        //create new JViewPort for this JScrollPane with JList as component
        JViewport viewPort=new JViewport();
        viewPort.add(list);
        super.setViewport(viewPort);
        //init the list
        setSize(100,485);
        list.setSelectionMode(ListSelectionModel.MULTIPLE_INTERVAL_SELECTION);
        list.setFixedCellHeight(20);
        for(int i=0;i<24;i++){
                listModel.addElement("___________");
        }//for
    }//initControl()


    public void addElement(Component comp){
        list.add(comp);
    }//addElement()

}//class ctrlList
