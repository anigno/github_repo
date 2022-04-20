import java.io.*;

public class anignoFile {
    public final int OK=0;
    public final int OPEN_READ_ERROR=1;
    public final int OPEN_WRITE_ERROR=2;
    public final int CLOSE_FILE_ERROR=3;
    public final int WRITE_ERROR=4;
    public final int READ_ERROR=5;
    public final int EOF=6;
    public final int UNKNOWN_ERROR=7;


    private InputStream iFile=null;
    private OutputStream oFile=null;
    private DataInputStream iData;
    private DataOutputStream oData;
    private String fileName="";

    public int errorNumber=OK;

    private void debug(String s){
        System.out.println(s);
    }//debug()

    public DataOutputStream openWrite(String fileName){
        try {
            oFile=new FileOutputStream(fileName);
        } catch (FileNotFoundException e) {
            errorNumber=OPEN_WRITE_ERROR;
        }//try catch
        oData=new DataOutputStream(oFile);
        this.fileName=fileName;
        return oData;
    }//openRead()

    public DataInput openRead(String fileName){
        try {
            iFile=new FileInputStream(fileName);
        } catch (FileNotFoundException e) {
            errorNumber=OPEN_READ_ERROR;
        }//try catch
        iData=new DataInputStream(iFile);
        this.fileName=fileName;
        return iData;
    }//openRead()

    public void close(){
        if(iFile!=null){
            try {
                iFile.close();
            } catch (IOException e) {
                errorNumber=CLOSE_FILE_ERROR;
            }//try catch
            iFile=null;
        }else{
            try {
                oFile.close();
            } catch (IOException e) {
                errorNumber=CLOSE_FILE_ERROR;
            }//try catch
            oFile=null;
        }//if else
    }//close()

    public void writeInt(int i){
        try {
            oData.writeInt(i);
        } catch (IOException e) {
            errorNumber=WRITE_ERROR;
        }//try catch
    }//writeInt()

    private void checkEndOfFile(){
        try {
            //try to read one byte
            iData.readByte();
        } catch (IOException e) {
            //error reading byte, EOF reached
            errorNumber=EOF;
        }//try catch
        try {
            //return to previous byte
           iFile.skip(-1);
        } catch (IOException e) {
            errorNumber=UNKNOWN_ERROR;
        }//try catch
    }//checkEndOfFile()

    public int readInt(){
        int i=0;
        try {
            i=iData.readInt();
            checkEndOfFile();
        } catch (IOException e) {
            errorNumber=READ_ERROR;
        }//try catch
        return i;
    }//readInt()

    public void writeByte(byte b){
        try {
            oData.writeByte(b);
        } catch (IOException e) {
            errorNumber=WRITE_ERROR;
        }//try catch
    }//writeInt()

    public byte readByte(){
        byte b=0;
        try {
            b=iData.readByte();
            checkEndOfFile();
        } catch (IOException e) {
            errorNumber=READ_ERROR;
        }//try catch
        return b;
    }//readByte()

}//class anignoFile
