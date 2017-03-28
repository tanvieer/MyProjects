
// reference github
import java.applet.AudioClip;
import java.io.File;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;

public class Music implements AudioClip {
	public static Clip clip;
	private String song;
	
	Music(String name){
		song = name+".wav";
	}
	
	@Override
	public void loop() {
		// TODO Auto-generated method stub
		clip.loop(Clip.LOOP_CONTINUOUSLY);
	}

	@Override
	public void play() {
		  try {
		   File file = new File(song);
		   clip = AudioSystem.getClip();
		   clip.open(AudioSystem.getAudioInputStream(file));
		   clip.start();
		  } catch (Exception e) {
		   System.err.println(e.getMessage());
		  }
  
	}

	@Override
	public void stop() {
	}
	public static void stp(){
		clip.stop();
	}
}
