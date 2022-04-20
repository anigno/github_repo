
import java.io.UnsupportedEncodingException;

public class cCONSTANT_Utf8 extends cCONSTANT_General{
    short length;
    byte bytes[];

    cCONSTANT_Utf8(cFile file,cTree tree){
        this.tag=1;
        this.tree=tree;
        length=file.readShort();
        bytes=new byte[length];
        for(int a=0;a<length;a++){
            bytes[a]=file.readByte();
        }//for
        addToTree();
    }
    public String toString(){
         String s="";
         s=s+" tag="+this.tag;
        s=s+" length="+length;
        //convert bytes[] from unicode to UTF-8
        try {
            String t=new String(bytes,"UTF-8");
            s=s+" bytes=\""+t+"\"";
            s=t;
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
        s=s+" " + this.ConstantName;
        return s;
     }//toString()
}//class cCONSTANT_Utf8
