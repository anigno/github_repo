import java.io.*;

public class cFile {
    String filename;
    InputStream file;
    DataInputStream data;
    OutputStream writeFile;
    DataOutputStream writeData;

    cFile(String filename){
        this.filename=filename;
    }//cFile()

    DataInput openRead(){
        try {
            file=new FileInputStream(filename);
        } catch(FileNotFoundException e) {
            e.printStackTrace();
        }//try catch
        data=new DataInputStream(file);
        return data;
    }//open()

    DataOutput openWrite(){
        try {
            writeFile=new FileOutputStream(filename);
        } catch(FileNotFoundException e) {
            e.printStackTrace();
        }//tru catch
        writeData=new DataOutputStream(writeFile);
        return writeData;
    }//open()

    void close(){
        try {
            file.close();
        } catch(IOException e) {
            e.printStackTrace();
        }//try catch
    }//close()

    byte getNextByte(){
        try {
            return data.readByte();
        } catch(IOException e) {
            //e.printStackTrace();
            return -1;
        }//try catch
    }//getNextByte()

    void writeByte(byte b){
        try {
            writeData.writeByte(b);
        } catch(IOException e) {
            e.printStackTrace();
        }//tru catch
    }//save()

}//class cFile
