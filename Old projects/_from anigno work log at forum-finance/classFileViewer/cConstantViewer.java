import javax.swing.*;
import java.util.Vector;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

public class cConstantViewer extends JInternalFrame implements MouseListener,Runnable{
    cList list;
    Vector nodes=new Vector();      //hold the cNode's that appear in the cList
    cTree tree;
    Vector selectedVector=new Vector();      //hold all line numbers for this node cList
    short tag;
    String constantName;

    public void run() {
        frameInit(constantName,tag);
        cCONSTANT_General cg;   //used to recieve the .tag item from cCONSTANT_General
        cNode tn;       //used to get other cNodes by index, and connect them to this node
        //run on the tree to add data to cList by tag value
        for(cNode it=tree.root.next;it!=null;it=it.next){
            cg=(cCONSTANT_General)it.current;   //the current cCONSTANT_General class
            if(cg.tag==tag){
                if(tag==1){
                    cCONSTANT_Utf8 a=(cCONSTANT_Utf8)cg;
                    generalNodeInit(it);
                    list.model.addElement(cg.index+" :"+a.toString());
                }//if
                if(tag==3){
                    cCONSTANT_Integer a=(cCONSTANT_Integer)cg;
                    generalNodeInit(it);
                    list.model.addElement(""+cg.index+":bytes="+a.bytes);
                }//if
                if(tag==4){
                    cCONSTANT_Float a=(cCONSTANT_Float)cg;
                    generalNodeInit(it);
                    list.model.addElement(""+cg.index+":bytes="+a.bytes);
                }//if
                if(tag==5){
                    cCONSTANT_Long a=(cCONSTANT_Long)cg;
                    generalNodeInit(it);
                    list.model.addElement(""+cg.index+":high_bytes="+a.high_bytes+" low_bytes="+a.low_bytes);
                }//if
                if(tag==6){
                    cCONSTANT_Double a=(cCONSTANT_Double)cg;
                    generalNodeInit(it);
                    list.model.addElement(""+cg.index+":high_bytes="+a.high_bytes+" low_bytes="+a.low_bytes);
                }//if
                if(tag==7){
                    cCONSTANT_Class a=(cCONSTANT_Class)cg;
                    generalNodeInit(it);
                    //model.addElement("index="+cg.index+" name_index="+a.name_index);
                    cCONSTANT_Utf8 utf=(cCONSTANT_Utf8)tree.getNodeByIndex(a.name_index).current;
                    list.model.addElement(cg.index+": "+utf.toString());
                    tn=tree.getNodeByIndex(a.name_index);
                    it.addConnection(tn);
                }//if
                if(tag==8){
                    cCONSTANT_String a=(cCONSTANT_String)cg;
                    generalNodeInit(it);
                    //model.addElement("index="+cg.index+" string_index="+a.string_index);
                    cCONSTANT_Utf8 utf=(cCONSTANT_Utf8)tree.getNodeByIndex(a.string_index).current;
                    list.model.addElement(cg.index+": "+utf.toString());
                    tn=tree.getNodeByIndex(a.string_index);
                    it.addConnection(tn);
                }//if
                if(tag==9){
                    cCONSTANT_Fieldref a=(cCONSTANT_Fieldref)cg;
                    generalNodeInit(it);
                    list.model.addElement(""+cg.index+":class_index="+a.class_index+" name_and_type_index="+a.name_and_type_index);
                    tn=tree.getNodeByIndex(a.class_index);
                    it.addConnection(tn);
                    tn=tree.getNodeByIndex(a.name_and_type_index);
                    it.addConnection(tn);
                }//if
                if(tag==10){
                    cCONSTANT_Methodref a=(cCONSTANT_Methodref)cg;
                    generalNodeInit(it);
                    list.model.addElement(cg.index+":class_index="+a.class_index+" name_and_type_index="+a.name_and_type_index);
                    tn=tree.getNodeByIndex(a.class_index);
                    it.addConnection(tn);
                    tn=tree.getNodeByIndex(a.name_and_type_index);
                    it.addConnection(tn);
                }//if
                if(tag==11){
                    cCONSTANT_InterfaceMethodref a=(cCONSTANT_InterfaceMethodref)cg;
                    generalNodeInit(it);
                    list.model.addElement(cg.index+":class_index="+a.class_index+" name_and_type_index="+a.name_and_type_index);
                    tn=tree.getNodeByIndex(a.class_index);
                    it.addConnection(tn);
                    tn=tree.getNodeByIndex(a.name_and_type_index);
                    it.addConnection(tn);
                }//if
                if(tag==12){
                    cCONSTANT_NameAndType a=(cCONSTANT_NameAndType)cg;
                    generalNodeInit(it);
                    cCONSTANT_Utf8 utf=(cCONSTANT_Utf8)tree.getNodeByIndex(a.name_index).current;
                    list.model.addElement(cg.index+": "+utf.toString());
                    tn=tree.getNodeByIndex(a.name_index);
                    it.addConnection(tn);
                    tn=tree.getNodeByIndex(a.descriptor_index);
                    it.addConnection(tn);
                }//if
            }//if
        }//for
        this.show();

    }//run()

    cConstantViewer(String constantName,short tag,cTree tree){
        super(constantName.substring(9,constantName.length())); //set frame caption
        this.tag=tag;
        this.constantName=constantName.substring(9,constantName.length());
        this.tree=tree;
    }//cConstantViewer()

    private void frameInit(String constantName,short tag){
        this.getContentPane().setLayout(null);
        list=new cList(this);
        list.list.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);    //single selection for current cList
        list.list.addMouseListener(this);
        list.scrollPane.setBounds(0,0,130,170);
        this.getContentPane().add(list.scrollPane);
        this.setBounds(150+(tag-1)*25,(tag-1)*25,150,200);
        this.show();
    }//frameInit()

    //general init procedure for each cNode, after selected constant is assign
    private void generalNodeInit(cNode node){
        node.lineNumber=list.model.getSize();  //set the line number for the current cNode
        node.constantViewer=this;     //set constantVewer frame for the current cNode
        nodes.addElement(node);   //add current cNode to nodes Vector in this cConstantViewer
    }//generalNodeInit()

    private void setSelected(cNode node){
        int nMax=node.connection.size();        //number of connections
        //mark selected line numbers of all connected cNodes
        for(int a=0;a<nMax;a++){
            cNode n=(cNode) node.connection.elementAt(a);       //connected cNode
            n.constantViewer.list.list.setSelectionMode(ListSelectionModel.MULTIPLE_INTERVAL_SELECTION);
            int j=n.lineNumber;     //line number in the connected cNode JList
            Integer I=new Integer(j);
            n.constantViewer.selectedVector.addElement(I);
            int i[]=new int[n.constantViewer.selectedVector.size()];
            for(int b=0;b<i.length;b++)i[b]=((Integer)n.constantViewer.selectedVector.elementAt(b)).intValue();
            n.constantViewer.list.list.setSelectedIndices(i);
        }//for
        //recourse call
        for(int a=0;a<nMax;a++){
            cNode n=(cNode) node.connection.elementAt(a);       //connected cNode
            setSelected(n);     //recourse call
        }//for
    }//setSelected()

    public void mouseClicked(MouseEvent event) {    }
    public void mouseEntered(MouseEvent event) {    }
    public void mouseExited(MouseEvent event) {     }
    public void mousePressed(MouseEvent event) {    }
    public void mouseReleased(MouseEvent event) {
        int i=list.list.getSelectedIndex();               //the index selected in this JList
        if(i>=0){           //check if any item selected
            cNode node=(cNode) nodes.elementAt(i);  //the node at that index
            //clear all selected;
            for(cNode it=tree.root.next;it!=null;it=it.next){
                DefaultListModel model=it.constantViewer.list.model;     //DLModel for it' JFrame
                JList list=it.constantViewer.list.list;      //get JList for it' JFrame
                Vector V=it.constantViewer.selectedVector;      //get selected vector for it' JFrame
                if(model.getSize()>0){
                    list.removeSelectionInterval(0,model.getSize()-1);
                    V.removeAllElements();
                }//if
            }//for
            list.list.setSelectedIndex(i);   //set current JList selected on (the one the mouse clicked on)
            setSelected(node);
        }//if i>=0
    }//mouseReleased()
}//class cConstantViewer
