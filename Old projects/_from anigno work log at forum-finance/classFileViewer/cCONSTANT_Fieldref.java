public class cCONSTANT_Fieldref extends cCONSTANT_General{
    short class_index;
    short name_and_type_index;
    cCONSTANT_Fieldref(cFile file,cTree tree){
        this.tag=9;
        this.tree = tree;
        class_index=file.readShort();
        name_and_type_index=file.readShort();
        addToTree();
    }
    public String toString(){
        String s="";
        s=s+" tag="+this.tag;
        s=s+" class_index="+class_index;
        s=s+" name_and_type_index="+name_and_type_index;
        s=s+" " + this.ConstantName;
    return s;
    }//toString()

}//class cCONSTANT_Fieldref
