import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;

import javax.swing.JPanel;

public class StartPanel extends JPanel {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private int frameWidth=420, frameHeight=700;
	private static final Font smallFont = new Font("Tahoma", Font.BOLD, 13);
	private static final Font mediumFont = new Font("Tahoma", Font.BOLD, 16);
	private static final Font largeFont = new Font("Tahoma", Font.BOLD, 24);
	private static final Font superLargeFont = new Font("Tahoma", Font.BOLD, 32);
	
	
	public StartPanel(){
		setPreferredSize(new Dimension(getFrameWidth(), getFrameHeight()));
		setBackground(Color.BLACK);
		
	}
	public void paintComponent(Graphics g2) {
		  super.paintComponent(g2);
		  Graphics2D g = (Graphics2D) g2;
		  g.setColor(Color.CYAN);
		  
		  g.setFont(superLargeFont);
		  g.drawString("DUAL DODGE", frameWidth/2 - g.getFontMetrics().stringWidth("DUAL DODGE") / 2, 70);
		  g.setFont(mediumFont);
		  g.drawString("The ULTIMATE Team-up", frameWidth/2 - g.getFontMetrics().stringWidth("The ULTIMATE Team-up") / 2, 100);
		  
		 
		  g.setColor(Color.CYAN);
		  g.setFont(mediumFont);
		  g.drawString("ENTER- Start Game", frameWidth/2 - g.getFontMetrics().stringWidth("ENTER- Start Game") / 2, 190);
		  g.drawString("R- Rank List", frameWidth/2 - g.getFontMetrics().stringWidth("R- Rank List") / 2, 212);
		  
		  g.setColor(Color.WHITE);
		  g.setFont(largeFont);
		  g.drawString("INSTRUCTIONS", frameWidth/2 - g.getFontMetrics().stringWidth("INSTRUCTIONS") / 2, 310);
		  g.setColor(Color.WHITE);
		  g.setFont(smallFont);
		  g.drawString("LEFT ARROW- Rotate Anti-Clockwise", frameWidth/2 - g.getFontMetrics().stringWidth("LEFT ARROW- Rotate Anti-Clockwise") / 2, 350);
		  g.drawString("RIGHT ARROW- Rotate Clockwise", frameWidth/2 - g.getFontMetrics().stringWidth("RIGHT ARROW- Rotate Clockwise") / 2, 370);
		  g.drawString("UP ARROW- Rotate Faster", frameWidth/2 - g.getFontMetrics().stringWidth("UP ARROW- Rotate Faster") / 2, 390);
		  g.drawString("DOWN ARROW- Rotate Slower", frameWidth/2 - g.getFontMetrics().stringWidth("DOWN ARROW- Rotate Slower") / 2, 410);
		  g.drawString("S- Start Panel", frameWidth/2 - g.getFontMetrics().stringWidth("S- Start Panel") / 2, 450);
		  g.drawString("R- Rank List", frameWidth/2 - g.getFontMetrics().stringWidth("R- Rank List") / 2, 470);
		  g.drawString("P- Pause Game", frameWidth/2 - g.getFontMetrics().stringWidth("P- Pause Game") / 2, 490);

		  g.setFont(largeFont);
		  g.drawString("DEVELOPED BY", frameWidth/2 - g.getFontMetrics().stringWidth("DEVELOPED BY") / 2, 570);
		  
		  g.setFont(smallFont);
		  g.drawString("Islam, Mohammad Tanvir    14-25471-1", frameWidth/2 - g.getFontMetrics().stringWidth("Islam, Mohammad Tanvir    14-25471-1") / 2, 610);
		  g.drawString("Ahmed, Mobasser    14-25722-1", frameWidth/2 - g.getFontMetrics().stringWidth("Ahmed, Mobasser    14-25722-1") / 2, 630);
		  g.drawString("Nabila, Syeda Nuzhat Sabrina    14-25613-1", frameWidth/2 - g.getFontMetrics().stringWidth("Nabila, Syeda Nuzhat Sabrina    14-25613-1") / 2, 650);
	}
	public int getFrameHeight() {
		return frameHeight;
	}
	public void setFrameHeight(int frameHeight) {
		this.frameHeight = frameHeight;
	}
	public int getFrameWidth() {
		return frameWidth;
	}
	public void setFrameWidth(int frameWidth) {
		this.frameWidth = frameWidth;
	}
	public static Font getSmallFont() {
		return smallFont;
	}
	public static Font getLargefont() {
		return largeFont;
	}
	public static Font getMediumfont() {
		return mediumFont;
	}
}
