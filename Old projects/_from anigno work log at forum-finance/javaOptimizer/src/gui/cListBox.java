/*class cListBox:
special listBox control that includes
jscrollpane, defaultListModel*/
package gui;
import javax.swing.*;

public class cListBox extends JList{
    public JScrollPane listScrollPane;
    DefaultListModel listModel;

    cListBox(){
        super();
        listModel=new DefaultListModel();
        super.setModel(listModel);
        listScrollPane=new JScrollPane(this);
    }//cListBox()

    public void addElement(Object o){
        listModel.addElement(o);
    }

    public void removeElement(int index){
        listModel.remove(index);
    }//removeElement();

    public void removeAll(){
        listModel.removeAllElements();
    }//removeAll();

}//cListBox
