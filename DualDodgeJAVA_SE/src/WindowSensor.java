import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

class WindowSensor extends WindowAdapter{
	public void windowClosing(WindowEvent we){
		Music.stp();
		System.exit(0);
	}
}