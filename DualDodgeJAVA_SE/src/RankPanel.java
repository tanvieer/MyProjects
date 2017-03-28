import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.sql.ResultSet;
import java.sql.SQLException;

import javax.swing.JPanel;

public class RankPanel extends JPanel {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private int frameWidth=420, frameHeight=700;
	private static final Font largeFont = new Font("Tahoma", Font.BOLD, 16);
	private static final Font smallFont = new Font("Tahoma", Font.BOLD, 12);
	private String query;
	private Rank[]  rankList= new Rank[1000];
	private int index;
	public RankPanel(){
		setPreferredSize(new Dimension(getFrameWidth(), getFrameHeight()));
		setBackground(Color.BLACK);
		
	}
	public void paintComponent(Graphics g2) {
		  super.paintComponent(g2);
		  Graphics2D g = (Graphics2D) g2;
		  g.setColor(Color.WHITE);
		  g.setFont(largeFont);
		  g.drawString("Top 10 Rank List", frameWidth/2 - g.getFontMetrics().stringWidth("Top 10 Rank List") / 2, 50);
		  //===========================================rank sort========================================
		  g.setFont(smallFont);
	        try {
	        	DataAccess da=new DataAccess();
	        	query = "SELECT * FROM `ScoreBoard`"; 
	        	ResultSet rs=da.getData(query);
	  		  	
	  		  	index =0;
				while(rs.next()){
				    rankList[index] = new Rank(rs.getString("UserName") ,rs.getInt("Level"));
				    index ++;
				}
				 da.close();
				 Rank.sort(rankList, index);
				 int y =100;
				 for(int i=0; i<index;i++){
					 g.drawString("Rank "+(i+1)+" : "+rankList[i].getName()+"    : "+rankList[i].getLevel(), 40, y);
					 y+=20;
				 }
			} catch (SQLException e) {
				g.drawString("Faild To Load Rank List", 100, 100);
			}
	       
		  //============================================================================================
		 
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
}
