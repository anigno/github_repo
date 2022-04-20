import java.io.*;

public class cFile {
    InputStream file=null;
    DataInputStream data;
    //byte dataBytes[];
    //long byteRead=0;

    public DataInput open(String fileName){
        try {
            file=new FileInputStream(fileName);
        } catch (FileNotFoundException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
        data=new DataInputStream(file);
        return data;
    }//open()

    public void close(){
        try {
            file.close();
        } catch (IOException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
    }//close()

    public int readInt(){
        try {
            return data.readInt();
        } catch (IOException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
        return -1;
    }//readInt()

    public short readShort(){
        try {
            return data.readShort();
        } catch (IOException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
        return -1;
    }//readShort()

    public byte readByte(){
        try {
            return data.readByte();
        } catch (IOException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
        return -1;
    }//readByte()
}//class cFile
