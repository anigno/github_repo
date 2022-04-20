import javax.swing.text.*;
import javax.swing.*;
import java.awt.*;

public class cColoredTextPane extends JFrame{
    JTextPane pane;
    StyledDocument doc;

    cColoredTextPane(){
        super("Colored textPane");
        this.getContentPane().setLayout(null);
        doc = new DefaultStyledDocument();
        pane = new JTextPane (doc);
        JScrollPane sp = new JScrollPane (pane);
        sp.setBounds(10,10,200,200);
        this.getContentPane().add(sp);
        this.setBounds(10,10,600,400);
        this.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        this.setVisible(true);
        pane.setCharacterAttributes(getAttrWithColor(Color.blue), false);

    }//cColoredTextPane()

     MutableAttributeSet getAttrWithColor(Color color){
         MutableAttributeSet attr =new SimpleAttributeSet();
         StyleConstants.setForeground(attr, color);
        return attr;
     }//getAttrWithColor()



    public static void main(String args[]){
        new cColoredTextPane();
    }
}
