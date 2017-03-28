import java.awt.BorderLayout;
import javax.swing.JFrame;

public class GameFrame extends JFrame{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	
	public GameFrame(GamePanel gp, StartPanel sp, RankPanel rp){

		super("DualDodge");
		setResizable(false);
		
		KeySensor ks=new KeySensor(gp, sp, rp);
		addKeyListener(ks);
		
		this.add(sp, BorderLayout.EAST);
		this.add(gp, BorderLayout.CENTER);
		this.add(rp, BorderLayout.WEST);
		
		gp.setVisible(false);
		rp.setVisible(false);
		
		pack();
		setLocationRelativeTo(null);
		setVisible(true);
	}
	
}