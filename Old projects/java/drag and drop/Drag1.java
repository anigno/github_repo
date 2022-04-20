/*
when droping on text boxes or other java programs, no need to implement drop function
*/
package dragAndDrop;

import java.awt.*;
import java.awt.event.*;
import java.awt.dnd.*;
import java.awt.datatransfer.*;
import java.io.IOException;
import javax.swing.*;

public class Drag1 extends JFrame implements DragGestureListener, DragSourceListener, DropTargetListener
{
    static String items[] = { "Item 1", "Item No. 2", "The Third Item!" };

    //drag and drop members
    Container cpane;                            //hold getContentPane()
    DropTarget mytarget;
    DragSource mysource;
    DragGestureRecognizer dgr;


    //frame members
    JLabel source1;
    JList  list1;
    JTextArea text1;
    DefaultListModel lmod;

    JLabel text;

    public Drag1() {
        super("Drag1 Test");
        cpane = getContentPane();
        cpane.setLayout(new BorderLayout());

        source1 = new JLabel("Drag Source Label - drag me!");
        lmod = new DefaultListModel();
        list1 = new JList(lmod);
        text=new JLabel();
        cpane.add(text);

        //add elements to the list box model
        for(int i = 0; i < items.length; i++)
            lmod.addElement(items[i]);
        text1 = new JTextArea("Drag from the label to\nthe list, then drop!",5, 24);
        //init the drag source
        mysource = new DragSource();
        //init the JList as drop target
        mytarget = new DropTarget(list1,DnDConstants.ACTION_COPY_OR_MOVE, this);
        //init DragGestureRecognizer to recognize the drag source (the JLabel)
        dgr = mysource.createDefaultDragGestureRecognizer(source1,DnDConstants.ACTION_COPY_OR_MOVE, this);

        //set controls on frame
        cpane.add("North", source1);
        cpane.add("Center", list1);
        cpane.add("South", text1);
        text1.setBackground(Color.pink);
        setBounds(100, 100, 640, 480);
        setVisible(true);
    }

    //recognize start drag
    public void dragGestureRecognized(DragGestureEvent e) {
        String sel = source1.getText();
        e.startDrag(DragSource.DefaultCopyDrop,new StringSelection(sel), this);
    }

    //recognize drag on other component (not the drop)
    public void dragEnter(DropTargetDragEvent e) {
        System.out.println("dragEnter");
        e.acceptDrag(DnDConstants.ACTION_COPY_OR_MOVE);
    }

    //drop on other component (JList)
    public void drop(DropTargetDropEvent e) {
        System.out.println("drop");
        try {
            if (e.isDataFlavorSupported(DataFlavor.stringFlavor)) {
                Transferable tr = e.getTransferable();
                e.acceptDrop(DnDConstants.ACTION_COPY_OR_MOVE);
                String s = (String)tr.getTransferData(DataFlavor.stringFlavor);
                lmod.addElement(s);
                e.dropComplete(true);
            }
            else {
                e.rejectDrop();
            }
        }
        catch (Exception ex) {
            System.out.println("Data transfer exception: " + ex);
        }
    }


    public void dragExit(DropTargetEvent e) {
        System.out.println("dragExit");

    }
    public void dragOver(DropTargetDragEvent e) {
        System.out.println("dragOver (drop)");
    }
    public void dropActionChanged(DropTargetDragEvent e) {
        System.out.println("dropActionChanged");
    }

    public void dragDropEnd(DragSourceDropEvent e) {
        System.out.println("dragDropEnd");
    }
    public void dragEnter(DragSourceDragEvent e) {
        System.out.println("dragEnter");
    }
    public void dragExit(DragSourceEvent e) {
        System.out.println("dragExit");
    }
    public void dragOver(DragSourceDragEvent e) {
        System.out.println("dragOver (drag)");
        DragSourceContext d=(DragSourceContext)e.getSource();
        try {
            String s=(String)d.getTransferable().getTransferData(DataFlavor.stringFlavor);
            text.setText(s);
        } catch (UnsupportedFlavorException e1) {
            e1.printStackTrace();
        } catch (IOException e1) {
            e1.printStackTrace();
        }
        text.setBounds(e.getX()-100,e.getY()-100,100,30);
    }
    public void dropActionChanged(DragSourceDragEvent e) {
        System.out.println("dragActionChanged (drag)");
    }


    public static void main(String [] args) {
        Drag1 d1;
        d1 = new Drag1();
        d1.addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent we) {
                System.exit(0);
            } } );
    }
}


