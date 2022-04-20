public class cRunner {

    StringBuffer sIn=new StringBuffer();
    StringBuffer sOut=new StringBuffer();
    cFile myFile;
    cFile outFile;

    cRunner(String filename){
        myFile=new cFile(filename);
        outFile=new cFile(filename + ".out.htm");
        myFile.openRead();
        outFile.openWrite();
        byte b=0;
        while(b!=-1){
            b=myFile.getNextByte();
            if(b!=-1){
                sIn.append((char)b);
                sOut.append((char)b);
                //System.out.print((char)b);
            }//if


            checkTocken("<head>","</head>");
            checkTocken("<style>","</style>");
            checkTocken("<body",">");
            checkTocken("<div",">");
            checkTocken("<table",">");
            checkTocken("<tr",">");
            checkTocken("<td",">");
            checkTocken("<p",">");
            checkTocken("<span",">");

        }//while
        System.out.println(sOut);
        for(int i=0;i<sOut.length();i++)outFile.writeByte((byte)sOut.charAt(i));
        myFile.close();
        //outFile.close();
    }//cRunner()

    void skipUntil(String s){
        byte b=0;
        StringBuffer sb=new StringBuffer();
        while(sb.indexOf(s)==-1){
            b=myFile.getNextByte();
            sb.append((char)b);
        }//while
    }//skipUntil()

    void checkTocken(String start,String end){
        if(sIn.indexOf(start)!=-1){
            sIn.delete(0,sIn.length());
            skipUntil(end);
            sOut.append(end);
        }//if
    }//checkTocken()

}//class cRunner
