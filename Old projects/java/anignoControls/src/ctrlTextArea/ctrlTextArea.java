package ctrlTextArea;

import controllers.dragControler;

import javax.swing.*;
import javax.swing.event.CaretListener;
import java.awt.*;
import java.awt.datatransfer.StringSelection;
import java.awt.dnd.*;
import java.awt.event.MouseListener;

public class ctrlTextArea implements DragGestureListener, DragSourceListener{
    JTextArea textArea;
    JTextArea dragTextArea;
    JScrollPane scrollPane;
    Container cPane;
    JLabel labelUp,labelDown,labelLeft,labelRight;
    Color resizeBorderColor=Color.black;
    int x,y,width,height;
    int sdx=0;      //start drag x
    int sdy=0;      //start drag y

    DropTarget mytarget;
    DragSource mysource;
    DragGestureRecognizer dgr;
//----------------------------------------------------------------------------------------------------------------------------------------------------------
    public ctrlTextArea(Container cPane){
        this.cPane=cPane;
        initControl();
    }

    private void initControl(){
        textArea=new JTextArea("");
        dragTextArea=new JTextArea("");
        dragTextArea.setVisible(false);
        dragTextArea.setOpaque(true);           //draw all pixels is true
        cPane.add(dragTextArea);
        scrollPane=new JScrollPane();
        cPane.add(scrollPane);
        initViewPort();
        initResizeLabels();
        mytarget=new DropTarget();
        mysource=new DragSource();
        //mytarget = new DropTarget(textArea,DnDConstants.ACTION_COPY_OR_MOVE, this);
        dgr = mysource.createDefaultDragGestureRecognizer(textArea,DnDConstants.ACTION_COPY_OR_MOVE, this);

    }//initControl()

    private void initViewPort(){
        JViewport vp=new JViewport();
        vp.add(textArea);
        scrollPane.setViewport(vp);
    }

    private void  initResizeLabels(){
        resizeBorderColor=textArea.getBackground();
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
        cPane.add(labelUp);
        cPane.add(labelDown);
        cPane.add(labelLeft);
        cPane.add(labelRight);
    }//initResizeLabels()

    public JTextArea getJTextArea(){
        return textArea;
    }//getJTextArea()

    public void setBounds(int x,int y,int width,int height){
        labelUp.setBounds(x,y,width,2);
        labelDown.setBounds(x,y+height-2,width,2);
        labelLeft.setBounds(x,y,2,height);
        labelRight.setBounds(x+width-2,y,2,height);
        scrollPane.setBounds(x+2,y+2,width-4,height-4);
        textArea.validate();
        scrollPane.validate();
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        dragTextArea.setVisible(false);
    }//setBounds

    public void setBorderColor(Color color){
        resizeBorderColor=color;
        labelUp.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelDown.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelLeft.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        labelRight.setBorder(BorderFactory.createLineBorder(resizeBorderColor));
        textArea.validate();
        scrollPane.validate();
    }

    public String getText(){
        return textArea.getText();
    }//getText()

    public void setText(String text){
        this.textArea.setText(text);
    }//setText()

    public int getX(){
        return x;
    }//getX()
    public int getY(){
        return y;
    }//getY()
    public int getWidth(){
        return width;
    }//getWidth()
    public int getHeight(){
        return height;
    }//getHeight()

    public void setWrapStyleWord(boolean word){
        textArea.setWrapStyleWord(word);
    }//setWrapStyleWord()

    public void setLineWrap(boolean wrap){
        textArea.setLineWrap(wrap);
    }//setLineWrap()

    //----------------------------------------------------------------------------------------------------------------------------------------------------------

    //add control listeners to JTextArea listeners lists
    public void addMouseListener(MouseListener listener){
        textArea.addMouseListener(listener);
    }
    public void removeMouseListener(MouseListener listener){
        textArea.removeMouseListener(listener);
    }

    public void addCaretListener(CaretListener listener){
        textArea.addCaretListener(listener);
    }
    public void removeCaretListener(CaretListener listener){
        textArea.removeCaretListener(listener);
    }

//----------------------------------------------------------------------------------------------------------------------------------------------------------







    //recognize start of drag operation
    public void dragGestureRecognized(DragGestureEvent dge) {
        System.out.println("dragGestureRecognized");
        if(dge.getComponent()==textArea){
            String sel=((JTextArea)dge.getComponent()).getText();
            sel="";
            dge.startDrag(Cursor.getPredefinedCursor(Cursor.MOVE_CURSOR),new StringSelection(sel),this);
        }//if
    }


    public void dragEnter(DragSourceDragEvent dsde) {
        //System.out.println("drag-dragEnter");
        sdx=dsde.getX();
        sdy=dsde.getY();
        dragControler.isDrag=true;
    }

    public void dragOver(DragSourceDragEvent dsde) {
        dragTextArea.setBounds(dsde.getX()-sdx+getX(),dsde.getY()-sdy+getY(),getWidth(),getHeight());
        dragTextArea.setText(textArea.getText());
        dragTextArea.setVisible(true);
        //System.out.println("drag-dragOver");
    }

    public void dropActionChanged(DragSourceDragEvent dsde) {
        System.out.println("drag-dropActionChanged");
    }

    public void dragDropEnd(DragSourceDropEvent dsde) {
        //System.out.println("drag-dragDropEnd");
        Component comp=dsde.getDragSourceContext().getComponent();  //the component that is being draged
        if(comp==textArea)System.out.println(((JTextArea)comp).getText());
        setBounds(dragTextArea.getX(),dragTextArea.getY(),width, height);
    }

    public void dragExit(DragSourceEvent dse) {
        //System.out.println("drag-dragExit");
    }

}//class ctrlTextArea
