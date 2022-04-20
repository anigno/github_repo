import javax.swing.*;

public class cTreeCreator{
    public cTree tree=new cTree();

    cTreeCreator(String fileName,cMdiFrame frame,cList list){
        //frame is used to se where to display error messages
        //list is used to update class general data in cMainFrame
        byte tag;
        cFile file=new cFile();
        file.open(fileName);
        int magic=file.readInt();
        short minor_version=file.readShort();
        short major_version=file.readShort();
        short constant_pool_count=file.readShort();
        list.model.addElement("magic=0x"+Integer.toHexString(magic).toUpperCase());
        list.model.addElement("minor="+minor_version);
        list.model.addElement("major="+major_version);
        list.model.addElement("constant pool count="+constant_pool_count);
        //read cp_count-1 constants (0 is preserve for java)
        for(int a=0;a<constant_pool_count-1;a++){
            tag=file.readByte();
            Object c=null;
            switch(tag){
                case  1:    //CONSTANT_Utf8
                    c=new cCONSTANT_Utf8(file,tree);
                    break;
                case  3:    //CONSTANT_Integer
                    c=new cCONSTANT_Integer(file,tree);
                    break;
                case  4:    //CONSTANT_Float
                    c=new cCONSTANT_Float(file,tree);
                    break;
                case  5:    //CONSTANT_Long
                    c=new cCONSTANT_Long(file,tree);
                    break;
                case  6:    //CONSTANT_Double
                    c=new cCONSTANT_Double(file,tree);
                    break;
                case  7:    //CONSTANT_Class
                    c=new cCONSTANT_Class(file,tree);
                    break;
                case  8:    //CONSTANT_String
                    c=new cCONSTANT_String(file,tree);
                    break;
                case  9:    //CONSTANT_Fieldref
                    c=new cCONSTANT_Fieldref(file,tree);
                    break;
                case  10:   //CONSTANT_Methodref
                    c=new cCONSTANT_Methodref(file,tree);
                    break;
                case  11:   //CONSTANT_InterfaceMethodref
                    c=new cCONSTANT_InterfaceMethodref(file,tree);
                    break;
                case  12:   //CONSTANT_NameAndType
                    c=new cCONSTANT_NameAndType(file,tree);
                    break;
                default:
                    JOptionPane.showMessageDialog(
                            frame,
                            "Error in class file!",
                            "Ex3Prog",
                            JOptionPane.ERROR_MESSAGE
                    );
                    System.exit(-1);
                    //c=new  cCONSTANT_Utf8(file,tree);
                    break;
            }//switch
        }//for
         short access_flags=file.readShort();
         short this_class=file.readShort();
         short super_class=file.readShort();
        //get real utf name from class_index and class_name for super class and this class
        cCONSTANT_Class this_class_class=(cCONSTANT_Class)(tree.getNodeByIndex(this_class).current);
        cCONSTANT_Utf8 this_class_utf;
        try{
                this_class_utf = (cCONSTANT_Utf8)(tree.getNodeByIndex(this_class_class.name_index).current);
                list.model.addElement("this class="+this_class_utf);
                cCONSTANT_Class super_class_class=(cCONSTANT_Class)(tree.getNodeByIndex(super_class).current);
                cCONSTANT_Utf8 super_class_utf=(cCONSTANT_Utf8)(tree.getNodeByIndex(super_class_class.name_index).current);
                list.model.addElement("super class="+super_class_utf);
                file.close();
        }catch(java.lang.NullPointerException e){
            JOptionPane.showMessageDialog(
                    frame,
                    "Error in class file!",
                    "Ex3Prog",
                    JOptionPane.ERROR_MESSAGE
            );
            System.exit(-1);
        }//catch
    }//cTreeCreator()
}//class cTreeCreator
