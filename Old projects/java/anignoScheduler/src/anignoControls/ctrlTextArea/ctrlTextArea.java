package anignoControls.ctrlTextArea;

import anignoControls.dragListener;
import anignoControls.resizeListener;

import javax.swing.*;
import javax.swing.event.CaretEvent;
import javax.swing.event.CaretListener;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.ArrayList;

/**
 * scrollable,resizable textArea control.
 * with mouse events, caret event and resize event
 * @author anigno
 * @version 1
 */
public class ctrlTextArea implements MouseListener,CaretListener{
    private Container cPane;
    private JScrollPane scrollPane;
    private JTextArea text;
    private JLabel labelUp;
    private JLabel labelDown;
    private JLabel labelLeft;
    private JLabel labelRight;
    private ArrayList mouseListeners=new ArrayList();                   //list of listeners for mouse events
    private ArrayList caretListeners=new ArrayList();                   //list of listeners for caret event
    private ArrayList resizeListeners=new ArrayList();                //list of listeners for resize event
    private ArrayList dragListeners=new ArrayList();                      //list of listeners for drag event
    private ArrayList dropListeners=new ArrayList();                      //list of listeners for drop event
    private Color resizeBorderColor=Color.black;
    private boolean isResizable=true;
    private boolean isResizing=false;
    private String resizeSide="";
    private  int x;
    private int y;
    private int width;
    private int height;
    private boolean isDrag=false;
    private int startDragX=0;
    private int startDragY=0;
    private final int dragInterval=5;


    public int getX(){
        return x;
    }//getX()
    public int getY(){
        return y;    }//getX()
    public int getWidth(){
        return width;
    }//getX()
    public int getHeight(){
        return height;
    }//getX()

    /**
     * add the control to the given container
     * @param cPane Container to hold the control
     */
    public ctrlTextArea(Container cPane){
        this.cPane=cPane;
        initControl();
    }//ctrlTextArea()

    private void initControl(){
        text=new JTextArea("");
        text.addMouseListener(this);
        text.addCaretListener(this);
        scrollPane=new JScrollPane();
        cPane.add(scrollPane);
        JViewport vp=new JViewport();
        vp.add(text);
        scrollPane.setViewport(vp);
        initResizeLabels();
    }//initControl()

    private void  initResizeLabels(){
        resizeBorderColor=text.getBackground();
        labelUp=new JLabel("");
        labelUp.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelUp.setCursor(Cursor.getPredefinedCursor(Cursor.N_RESIZE_CURSOR));
        labelDown=new JLabel("");
        labelDown.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelDown.setCursor(Cursor.getPredefinedCursor(Cursor.S_RESIZE_CURSOR));
        labelLeft=new JLabel("");
        labelLeft.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelLeft.setCursor(Cursor.getPredefinedCursor(Cursor.W_RESIZE_CURSOR));
        labelRight=new JLabel("");
        labelRight.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelRight.setCursor(Cursor.getPredefinedCursor(Cursor.E_RESIZE_CURSOR));
        labelUp.addMouseListener(this);
        labelDown.addMouseListener(this);
        labelLeft.addMouseListener(this);
        labelRight.addMouseListener(this);
        cPane.add(labelUp);
        cPane.add(labelDown);
        cPane.add(labelLeft);
        cPane.add(labelRight);
    }//initResizeLabels()

    /**
     * get the JTextArea of this control, used for additional properties
     */
    public JTextArea getJTextArea(){
        return text;
    }//getJTextArea

    /**
     * get the JScrollPane of this control, used for additional properties
     */
    public JScrollPane getJScrollPane(){
        return scrollPane;
    }//getJScrollPane()

    /**
     * Moves and resizes this component. The new location of the top-left corner is specified by x and y, and the new size is specified by width and height.
     * the zero point referenced as the top-left point of it's container
     * @param x
     * @param y
     * @param width
     * @param height
     */
    public void setBounds(int x,int y,int width,int height){
        labelUp.setBounds(x-3,y-3,width+6,3);
        labelDown.setBounds(x-3,y+height,width+6,3);
        labelLeft.setBounds(x-3,y,3,height);
        labelRight.setBounds(x+width,y,3,height);
        scrollPane.setBounds(x,y,width,height);
        text.validate();
        scrollPane.validate();
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }//setBounds

    /**
     * set the border color
     * @param color
     */
    public void setBorderColor(Color color){
        resizeBorderColor=color;
        labelUp.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelDown.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelLeft.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelRight.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
    }

    /**
     * Sets the style of wrapping used if the text area is wrapping lines. If set to true the lines will be wrapped at word boundaries (whitespace) if they are too long to fit within the allocated width. If set to false, the lines will be wrapped at character boundaries. By default this property is false.
     * @param word
     */
    public void setWrapStyleWord(boolean word){
        text.setWrapStyleWord(word);
    }//setWrapStyleWord()

    /**
     * Sets the line-wrapping policy of the text area. If set to true the lines will be wrapped if they are too long to fit within the allocated width. If set to false, the lines will always be unwrapped. A PropertyChange event ("lineWrap") is fired when the policy is changed. By default this property is false.
     * @param wrap
     */
    public void setLineWrap(boolean wrap){
        text.setLineWrap(wrap);
    }//setLineWrap()

    public String getText(){
        return text.getText();
    }//getText()

    public void setText(String text){
        this.text.setText(text);
    }//setText()

    /**
     * set control to be resizable
     * @param resize true for resizable control
     */
    public void setResizable(boolean resize){
        isResizable = resize;
        if(resize==true){
            labelUp.setCursor(Cursor.getPredefinedCursor(Cursor.N_RESIZE_CURSOR));
            labelDown.setCursor(Cursor.getPredefinedCursor(Cursor.S_RESIZE_CURSOR));
            labelLeft.setCursor(Cursor.getPredefinedCursor(Cursor.W_RESIZE_CURSOR));
            labelRight.setCursor(Cursor.getPredefinedCursor(Cursor.E_RESIZE_CURSOR));
        }else{
            labelUp.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
            labelDown.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
            labelLeft.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
            labelRight.setCursor(Cursor.getPredefinedCursor(Cursor.DEFAULT_CURSOR));
        }//if else
    }//setResizable()

    //drag functions
    public synchronized void addDragListener(dragListener listener){
        dragListeners.add(listener);
    }
    public synchronized void removeDragListener(dragListener listener){
        dragListeners.remove(listener);
    }
    private synchronized void fireDragEvent(String eventString){
        dragListener listener;
        for(int i=0;i<dragListeners.size();i++){
            listener=(dragListener)dragListeners.get(i);
            if(eventString.equals("startDrag"))listener.dragStart(this);
            if(eventString.equals("endDrag")){
                listener.dragEnd(this);

            }//if
        }//for
    }

    //resize functions
    public synchronized void addResizeListener(resizeListener listener){
        resizeListeners.add(listener);
    }
    public synchronized  void removeResizeListener(resizeListener listener){
        resizeListeners.remove(listener);
    }
    private synchronized void fireResizeEvent(String resizedSide){
        resizeListener listener;
        for(int i=0;i<resizeListeners.size();i++){
            listener=(resizeListener)resizeListeners.get(i);
            listener.controlResized(resizedSide,this);
        }//for
    }
    //mouse functions
    public synchronized void addMouseListener(MouseListener listener){
        mouseListeners.add(listener);
    }
    public synchronized void removeMouseListener(MouseListener listener){
        mouseListeners.remove(listener);
    }
    private synchronized void fireMouseEvent(String action,Component  comp,int id,long when,int modifiers,int x,int y,int clickCount,boolean triger,int buttonNumber){
        MouseEvent mouseEvent=new MouseEvent(comp,id,when,modifiers,x,y,clickCount,triger,buttonNumber);
        MouseListener mouseListener;
        for(int i=0;i<mouseListeners.size();i++){
            mouseListener=(MouseListener)mouseListeners.get(i);
            if(action.equals("mouseClicked"))mouseListener.mouseClicked(mouseEvent);
            if(action.equals("mouseEntered"))mouseListener.mouseEntered(mouseEvent);
            if(action.equals("mouseExited"))mouseListener.mouseExited(mouseEvent);
            if(action.equals("mousePressed"))mouseListener.mousePressed(mouseEvent);
            if(action.equals("mouseReleased"))mouseListener.mouseReleased(mouseEvent);
        }//for
    }
    //caret functions
    public synchronized void addCaretListener(CaretListener listener){
        caretListeners.add(listener);
    }
    public synchronized void removeCaretListener(CaretListener listener){
        caretListeners.remove(listener);
    }
    private synchronized void fireCaretEvent(CaretEvent e){
        CaretListener caretListener;
        for(int i=0;i<caretListeners.size();i++){
            caretListener=(CaretListener)caretListeners.get(i);
            caretListener.caretUpdate(e);
        }//for
    }
    //mouse events
    public void mouseClicked(MouseEvent e) {
        if(e.getSource()==text)
            fireMouseEvent("mouseClicked",e.getComponent(),e.getID(), e.getWhen(),e.getModifiers(),e.getX(),e.getY(),e.getClickCount(),e.isPopupTrigger(),e.getButton());
    }
    public void mouseEntered(MouseEvent e) {
        if(e.getSource()==text)
            if(isResizing!=true)
                fireMouseEvent("mouseEntered",e.getComponent(),e.getID(), e.getWhen(),e.getModifiers(),e.getX(),e.getY(),e.getClickCount(),e.isPopupTrigger(),e.getButton());
    }
    public void mouseExited(MouseEvent e) {
        if(e.getSource()==text)
            if(isResizing!=true)
                fireMouseEvent("mouseExited",e.getComponent(),e.getID(), e.getWhen(),e.getModifiers(),e.getX(),e.getY(),e.getClickCount(),e.isPopupTrigger(),e.getButton());
    }

    public void mousePressed(MouseEvent e) {
        if(e.getSource()==text){
            fireMouseEvent("mousePressed",e.getComponent(),e.getID(), e.getWhen(),e.getModifiers(),e.getX(),e.getY(),e.getClickCount(),e.isPopupTrigger(),e.getButton());
            isDrag=true;
            startDragX=e.getX();
            startDragY=e.getY();
            text.setCursor(Cursor.getPredefinedCursor(Cursor.MOVE_CURSOR));
            fireDragEvent("startDrag");
        }
        if(isResizable==true){
            if(e.getSource()==labelUp){
                isResizing=true;
                resizeSide="up";
            }//if
            if(e.getSource()==labelDown){
                isResizing=true;
                resizeSide="down";
            }//if
            if(e.getSource()==labelLeft){
                isResizing=true;
                resizeSide="left";
            }//if
            if(e.getSource()==labelRight){
                isResizing=true;
                resizeSide="right";
            }//if
        }//if
    }

    public void mouseReleased(MouseEvent e) {
        if(e.getSource()==text){
            if(isDrag==true){
                //check if mouse had moved drag interval to fire endDrag or to fire mouseReleased
                if( (Math.abs(e.getX()-startDragX)>dragInterval)||(Math.abs(e.getY()-startDragY)>dragInterval)){
                    setBounds(x+e.getX()-startDragX,y+e.getY()-startDragY,width,height);
                    text.setCursor(Cursor.getPredefinedCursor(Cursor.TEXT_CURSOR));
                    fireDragEvent("endDrag");
                }else{
                    fireMouseEvent("mouseReleased",e.getComponent(),e.getID(), e.getWhen(),e.getModifiers(),e.getX(),e.getY(),e.getClickCount(),e.isPopupTrigger(),e.getButton());
                }//if else
                isDrag=false;
            }//if
        }//if
        if(isResizing==true){
            isResizing=false;
            if(
                    (e.getSource()==labelUp)||
                    (e.getSource()==labelDown)||
                    (e.getSource()==labelLeft)||
                    (e.getSource()==labelRight)){
                if(resizeSide.equals("up")){
                    y+=e.getY();
                    height-=e.getY();
                }//if
                if(resizeSide.equals("down")){
                    height+=e.getY();
                }//if
                if(resizeSide.equals("left")){
                    x+=e.getX();
                    width-=e.getX();
                }//if
                if(resizeSide.equals("right")){
                    width+=e.getX();
                }//if
                setBounds(x,y,width,height);
            }//if
            fireResizeEvent(resizeSide);
        }//if
    }
    //caret event
    public void caretUpdate(CaretEvent e) {
        fireCaretEvent(e);
    }


}//class ctrlTextArea
