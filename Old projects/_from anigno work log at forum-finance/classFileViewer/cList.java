import javax.swing.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

public class cList{
    DefaultListModel model=new DefaultListModel();
    JList list=new JList(model);
    JScrollPane scrollPane=new JScrollPane(list);
    cList(JInternalFrame parentFrame){
        parentFrame.getContentPane().add(scrollPane);
        list.setVisible(true);
    }//cList()

}//class cList
