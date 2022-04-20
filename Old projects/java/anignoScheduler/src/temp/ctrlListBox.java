package temp;

import javax.swing.*;
import javax.swing.event.EventListenerList;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;
import java.awt.event.ItemListener;
import java.awt.event.ItemEvent;
import java.awt.*;

public class ctrlListBox extends JScrollPane implements ItemSelectable {

    DefaultListModel listModel=new DefaultListModel();  //data holder
    JList jList=new JList(listModel);                                           //viewPort component

    public ctrlListBox(){
        super();
        //create new JViewPort for this JScrollPane with JList as component
        JViewport jViewPort=new JViewport();
        jViewPort.add(jList);
        super.setViewport(jViewPort);
    }

    /**
     * add new element to the end of the list
     * @param obj the element to be added
     */
    public void addElement(Object obj){
        listModel.addElement(obj);

    }

    /**
     * add new element at zero base index position
     * @param index the position for the new element
     * @param obj the element to be added
     */
    public void addElement(int index,Object obj){
        if(index>listModel.size())index=listModel.size();
        if(index<0)index=0;
        listModel.add(index,obj);
    }

    /**
     * remove element at zero base index position
     * @param index the zero based index of the element
     * @return true in element was removed otherwise false
     */
    public boolean removeElement(int index){
        if(index>listModel.size())return false;
        if(index<0)return false;
        listModel.removeElementAt(index);
        return true;
    }

    /**
     * Moves and resizes this component. The new location of the top-left corner is specified by x and y, and the new size is specified by width and height.
     * @param x - the new x-coordinate of this component
     * @param y - the new y-coordinate of this component
     * @param width - the new width of this component
     * @param height - the new height of this component
     */
    public void setBounds(int x,int y,int width,int height){
        super.setBounds(x,y,width,height);
    }

    /**
     * Adds the specified mouse listener to receive mouse events from this component. If listener l is null, no exception is thrown and no action is performed.
     * @param mouseListener
     */
    public void addMouseEventListener(MouseListener mouseListener){
        //jList.addMouseListener(mouseListener);
        
    }

    /**
     *return comparable object for event handling
     * @return the object in this control that the event occured on
     */
    public Object getMouseEventSource(){
        return jList;
    }


    public void addItemListener(ItemListener l) {

    }

    public void removeItemListener(ItemListener l) {

    }

    public Object[] getSelectedObjects() {
        return new Object[0];
    }
}//class ctrlListBox
