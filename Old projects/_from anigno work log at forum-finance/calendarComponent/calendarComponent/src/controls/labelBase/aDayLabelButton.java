package controls.labelBase;
import utilClasses.aDate;

import java.awt.*;

/**
 * display the day of current date
 */
public class aDayLabelButton extends aLabelButton{

    private aDate date;

    public aDayLabelButton(Container container, int width, int height) {
        super(container, width, height, "");
        date=new aDate();   //will set date to today
        setText(""+date.getDay());
    }

    public aDate getDate(){
        return date;
    }

    public void setDate(aDate date){
        this.date.setDate(date);
        setText(""+date.getDay());
    }

}
