package customEvents;

import java.util.EventObject;

/**
 * event for textButtonTextChangedEvent 
 */
public class textButtonTextChangedEvent extends EventObject{

    public String newText;

    public textButtonTextChangedEvent(Object source,String text) {
        super(source);
        newText=text;
    }

}
