package _testControl;

import javax.swing.*;
import javax.swing.event.CaretListener;
import javax.swing.event.CaretEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;
import java.awt.*;
import java.util.ArrayList;

/**
 *demo control to show how to write custom control with
 * awt events and custom events
 * this control contains a JButton and a JTextField placed on a JFrame.
 * the JFrame is importent here for the container component to display something
 */
public class textButton extends JPanel implements MouseListener,CaretListener{
    JButton button;
    JTextField text;
    int textLength;     //used to check if the text kength has been changed
    ArrayList mouseListeners=new ArrayList();                   //list of listeners for mouse events
    ArrayList textChangedListeners=new ArrayList();  //list of listeners for text change event

    /**
     * default constructor
     */
    public textButton(){
        initControl();
    }

    /**
     * init the control
     */
    private void initControl(){
        button=new JButton("OK");
        text=new JTextField("some text");
        textLength=text.getText().length();
        //add mouse listener to the JFrame with super, not with this. (although not needed for this example)
        super.addMouseListener(this);
        //add mous listener to other controls
        button.addMouseListener(this);
        text.addMouseListener(this);
        //add caret listener
        text.addCaretListener(this);
        this.setLayout(null);
        //add component to JFrame container
        this.add(button);
        this.add(text);
    }

    /**
     * Moves and resizes this component. The new location of the top-left corner is specified by x and y, and the new size is specified by width and height.
     * @param x
     * @param y
     * @param w width
     * @param h height
     */
    public void setBounds(int x,int y,int w,int h){
        super.setBounds(x,y,w,h);
        text.setBounds(0,0,w,50);
        button.setBounds(0,h-50,w,50);
    }

    /**
     * add mouse listener to mouse listeners list
     * @param listener
     */
    public synchronized void addMouseListener(MouseListener listener){
        mouseListeners.add(listener);
    }

    /**
     * remove mouse lisener from mouse listeners list
     * @param listener
     */
    public synchronized void removeMouseListener(MouseListener listener){
        mouseListeners.remove(listener);
    }

    /**
     * add text changed listener to textChanged listeners list
     * @param listener
     */
    public synchronized void addTextChangedListener(textButtonTextChangedListener listener){
        textChangedListeners.add(listener);
    }

    /**
     * remove listener from text changed listeners list
     * @param listener
     */
    public synchronized void removeTextChangedListener(textButtonTextChangedListener listener){
        textChangedListeners.remove(listener);
    }

    /**
     * fire mouse event to all mouse event listeners in mouse listeners list
     * @param comp the component returned by getSource() function in listener class
     * @param id
     * @param when time (long)
     * @param modifiers
     * @param x
     * @param y
     * @param clickCount
     * @param triger if true,may trigger popup menu
     * @param buttonNumber 1-left 2-right 3-middle
     */
    private synchronized void fireMouseEvent(Component  comp,int id,long when,int modifiers,int x,int y,int clickCount,boolean triger,int buttonNumber){
        MouseEvent mouseEvent=new MouseEvent(comp,id,when,modifiers,x,y,clickCount,triger,buttonNumber);
        MouseListener mouseListener;
        for(int i=0;i<mouseListeners.size();i++){
            mouseListener=(MouseListener)mouseListeners.get(i);
            mouseListener.mousePressed(mouseEvent);
        }//for
    }

    /**
     * fire text changed event to all text changed listeners in text changed listeners list
     * @param newText the text after the change
     */
    private synchronized void fireTextChangedEvent(String newText){
        textButtonTextChangedEvent event=new textButtonTextChangedEvent(this,newText);
        textButtonTextChangedListener listener;
        for(int i=0;i<textChangedListeners.size();i++){
            listener=(textButtonTextChangedListener)textChangedListeners.get(i);
            listener.textButtonTextChanged(event);
        }//for
    }

    /**
     * must implement mouse events functions
     * @param e
     */
    public void mousePressed(MouseEvent e) {
        if(e.getSource()==button){
            //if right click triger pop menu
            boolean isRightClick=false;
            if(e.getButton()==MouseEvent.BUTTON2)isRightClick=true;
            //fire mouse event
            fireMouseEvent(this,e.getID(),e.getWhen(),e.getModifiers(),e.getX(),e.getY(),e.getClickCount(),isRightClick,e.getButton() );
        }//if
    }

    public void mouseClicked(MouseEvent e) {
    }

    public void mouseEntered(MouseEvent e) {
    }

    public void mouseExited(MouseEvent e) {
    }

    public void mouseReleased(MouseEvent e) {
    }

    /**
     * must implement caretUpdate function
     * then, will check if text has been changed to fire the text changed event
     * @param e
     */
    public void caretUpdate(CaretEvent e) {
        if(text.getText().length()!=textLength){
            textLength=text.getText().length();
            //fire event
            fireTextChangedEvent(text.getText());
        }//if
    }
}//class _testControl
