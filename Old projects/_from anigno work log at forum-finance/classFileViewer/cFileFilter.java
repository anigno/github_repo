import javax.swing.filechooser.FileFilter;
import java.io.File;

public class cFileFilter extends FileFilter{
    public boolean accept(File file) {
        if(file.isDirectory())return true;  //show directories
        if(getExtension(file).equals("class"))return true;  //show class files
        return false;
    }

    public String getDescription() {
        return "class files";   //set description to show
    }

    //get extention from file (subString after '.')
    private String getExtension(File f){
        String s = f.getName();
        int i = s.lastIndexOf('.');
        if (i > 0 &&  i < s.length() - 1)
          return s.substring(i+1).toLowerCase();
        return "";
      }//getExtention()
}//class cFileFilter
