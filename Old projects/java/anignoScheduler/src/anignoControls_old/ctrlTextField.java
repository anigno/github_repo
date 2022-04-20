package anignoControls_old;

import javax.swing.*;
import java.awt.*;
import java.awt.datatransfer.StringSelection;
import java.awt.datatransfer.DataFlavor;
import java.awt.datatransfer.Transferable;
import java.awt.dnd.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

public class ctrlTextField extends JPanel implements DragGestureListener, DragSourceListener,DropTargetListener,MouseListener{

    JLabel labelText;
    JLabel labelUp;
    JLabel labelDown;
    JLabel labelCursor=new JLabel("---------");
    JTextArea textEdit;
    JScrollPane textEditScrollPane;


    //drag and drop members
    DragSource dragSourceUp;
    DragSource dragSourceDown;
    DragSource dragSourceText;
    DropTarget dropTargerText;
    DragGestureRecognizer dgr;

    public int totalWidth=90;               //container width
    public int startHour=0;                   //the start hour
    public int endHour=1;                        //the end hour
    public String text="";                       //the text that will appear
    public int day,month,year;            //the date of this control
    public int widthDivFactor=1;    //the number of ctrlTextField this control share width with
    public int widthIndex=0;               //the zero based index within the width


    public ctrlTextField(Container cPane){
        super();
        cPane.add(this);
        initControl();
    }

    private void initControl(){
        setLayout(null);
        labelUp=new JLabel(" ");
        labelText=new JLabel("text");
        labelDown=new JLabel(" ");
        textEdit=new JTextArea("");
        textEditScrollPane=new JScrollPane(textEdit);
        textEditScrollPane.setVisible(false);
        textEdit.setLineWrap(true);
        textEdit.setAutoscrolls(true);
        textEdit.setWrapStyleWord(true);
        add(labelText);
        add(labelUp);
        add(labelDown);
        add(labelCursor);
        add(textEditScrollPane);
        setPosition(startHour,endHour,widthDivFactor,widthIndex);
        labelUp.setCursor(Cursor.getPredefinedCursor(Cursor.N_RESIZE_CURSOR));
        labelDown.setCursor(Cursor.getPredefinedCursor(Cursor.N_RESIZE_CURSOR));
        labelText.setBorder(BorderFactory.createLineBorder(Color.blue));
        labelUp.setBorder(BorderFactory.createLineBorder(Color.green));
        labelDown.setBorder(BorderFactory.createLineBorder(Color.green));
        labelText.addMouseListener(this);
        dragSourceUp=new DragSource();
        dragSourceDown=new DragSource();
        dragSourceText=new DragSource();
        dropTargerText = new DropTarget(labelText,DnDConstants.ACTION_COPY_OR_MOVE, this);
        dgr=dragSourceUp.createDefaultDragGestureRecognizer(labelUp,DnDConstants.ACTION_COPY_OR_MOVE,this);
        dgr=dragSourceDown.createDefaultDragGestureRecognizer(labelDown,DnDConstants.ACTION_COPY_OR_MOVE,this);
        dgr=dragSourceText.createDefaultDragGestureRecognizer(labelText,DnDConstants.ACTION_COPY_OR_MOVE,this);
    }//initControl()

    public void setPosition(int startHour,int endHour,int widthDivFactor,int widthIndex){
        //setup parameters
        this.startHour = startHour;
        this.endHour=endHour;
        this.widthDivFactor=widthDivFactor;
        this.widthIndex=widthIndex;
        //set location
        int xPos=totalWidth/widthDivFactor*widthIndex+3;
        int width=totalWidth/widthDivFactor;
        this.setBounds(xPos,startHour*20,width,(endHour-startHour)*20);
        labelUp.setBounds(0,0,width,3);
        labelText.setBounds(0,1+(int)labelUp.getBounds().getHeight(),width,(endHour-startHour)*20-8);
        labelDown.setBounds(0,4+(int)labelText.getBounds().getHeight(),width,3);
        textEditScrollPane.setBounds(labelText.getBounds());
    }//setPosition()







    //events functions
    /**
     * set String value to transfer and start the drag operation
     * @param dge
     */
    public void dragGestureRecognized(DragGestureEvent dge) {
        String sel="";
        Component comp=dge.getComponent();
        if(comp==labelUp)sel="up";
        if(comp==labelDown)sel="down";
        if(comp==labelText)sel="text";
        Cursor resizeCursor=Cursor.getPredefinedCursor(Cursor.N_RESIZE_CURSOR);
        dge.startDrag(resizeCursor,new StringSelection(sel), this);
    }//dragGestureRecognized()







    //drag listener functions
    public void dragEnter(DragSourceDragEvent dsde) {    }
    public void dragOver(DragSourceDragEvent dsde) {    }
    public void dropActionChanged(DragSourceDragEvent dsde) {    }
    public void dragDropEnd(DragSourceDropEvent dsde) {    }
    public void dragExit(DragSourceEvent dse) {    }

    //drop Listener  functions
    /**
     * start thr drop operation on the labelText, meaning resize the ctrlTextField to diferent time interval
     * @param dtde
     */
    public void drop(DropTargetDropEvent dtde) {
        try {
            if (dtde.isDataFlavorSupported(DataFlavor.stringFlavor)) {
                Transferable tr = dtde.getTransferable();
                dtde.acceptDrop(DnDConstants.ACTION_COPY_OR_MOVE);
                String sel = (String)tr.getTransferData(DataFlavor.stringFlavor);
                int newHour=(int)((dtde.getLocation().getY()+5)/20+startHour);
                if(sel.equals("up")){
                    if(endHour-newHour>=1)setPosition(newHour,endHour,widthDivFactor,widthIndex);
                }//if
                if(sel.equals("down")){
                    if(endHour-newHour>=1)setPosition(startHour,newHour,widthDivFactor,widthIndex);
                }//if
                labelCursor.setVisible(false);
                dtde.dropComplete(true);
            }else {
                dtde.rejectDrop();
            }//if else
        }catch (Exception ex) {
            System.out.println("Data transfer exception: " + ex);
        }//catch
    }//drop()

    public void dragOver(DropTargetDragEvent dtde) {
        int newHour=(int)((dtde.getLocation().getY()+5)/20+startHour);
        labelCursor.setVisible(true);
        labelCursor.setBounds(0,(newHour-startHour)*20-5,80,3);
        //System.out.println(newHour);
    }//dragOver()
    public void dragEnter(DropTargetDragEvent dtde) {    }
    public void dropActionChanged(DropTargetDragEvent dtde) {    }
    public void dragExit(DropTargetEvent dte) {
        labelCursor.setVisible(false);
    }

    //mouse events
    public void mousePressed(MouseEvent e) {
        if(e.getSource()==labelText){
            labelText.setVisible(false);
            textEditScrollPane.setVisible(true);


        }//if
    }//mousePressed()
    public void mouseClicked(MouseEvent e) {
    }
    public void mouseEntered(MouseEvent e) {
    }
    public void mouseExited(MouseEvent e) {
    }
    public void mouseReleased(MouseEvent e) {
    }
}//class ctrlTextField
