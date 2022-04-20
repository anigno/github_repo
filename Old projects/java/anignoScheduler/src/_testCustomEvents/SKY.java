package _testCustomEvents;
public class SKY implements MoodListener {

    public void moodReceived(MoodEvent event) {
        if( event.mood() == Mood.HAPPY )
        {
            System.out.println( "Sun is shining!" );
        }
        else if( event.mood() == Mood.ANNOYED )
        {
            System.out.println( "Cloudy Skies!" );
        }
        else
        {
            System.out.println( "Lightning rains from the heavens!" );
        }
    }
}

