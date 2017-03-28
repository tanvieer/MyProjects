import java.net.InetAddress;
import java.net.UnknownHostException;

// @Author : Nabila , Tanvir , Mobasser
/* Last Updated : 16 Dec 2015 [ 5:48 AM ]
 *
 *
 */

public class StartGame {

	public static void main(String str[]) throws UnknownHostException{
		
		// create id in database =================================================
		DataAccess da=new DataAccess();
        String ip =InetAddress.getLocalHost().toString();
		String name = ip.substring(0, ip.indexOf('/'));
        String q="insert into scoreboard values('"+name+"','1','"+ip+"')";
        
        da.updateDB(q);
        //===========================================================================
		Music m1 = new Music("gameBackground");
		GamePanel p=new GamePanel();
		StartPanel sp=new StartPanel();
		RankPanel rp=new RankPanel();
		
		GameFrame mf=new GameFrame(p, sp, rp);
        
        mf.addWindowListener(new WindowSensor());
        
        m1.play();   // if u open it , you also need to open music.stp(); in WindowSensor.java class
        m1.loop();
    }
}
