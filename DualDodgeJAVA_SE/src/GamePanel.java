import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.RenderingHints;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.sql.ResultSet;
import java.sql.SQLException;

import javax.sound.sampled.Clip;
import javax.swing.JPanel;

public class GamePanel extends JPanel{
	/**
	 * 
	 */
	private static final Font largeFont = new Font("Tahoma", Font.BOLD, 24);
	private static final Font smallFont = new Font("Tahoma", Font.BOLD, 12);
	
	private int levelNo=1;
	
	private boolean isPaused=false;
	private double redOvalX, redOvalY, blueOvalX, blueOvalY;
	public double theta,radius;
	private int frameHeight=700, frameWidth=420;
	private int rotationSpeed;
	private int obstacleSpeed;
	private int obstacleDistance = 200;
	private int threadSpeed = 40;
	private int obstacleStartY = - 200;
	private int obstacleNumber = 6;
	
	private Clip clip;
	public PairCoOrdinate obstacles[] = new PairCoOrdinate[100];
	
	public final int rotationRadius=90;
	public double ovalPathCenterX, ovalPathCenterY;
	public final int smallOvalDiameter=30;
	
	private Integer obstacleWidth[] = new Integer[200] ;
	private Integer obstacleHeight[] = new Integer[200] ;
	public Integer obstacleDistanceArray[] = new Integer[200];
	
	private static final long serialVersionUID = 2269971701250845501L;
	
	public GamePanel() {
		setPreferredSize(new Dimension(getFrameWidth(), getFrameHeight()));
		setBackground(Color.BLACK);
		setRedOvalX(getFrameWidth()/2 + rotationRadius - smallOvalDiameter/2);
		setRedOvalY(getFrameHeight()-rotationRadius-smallOvalDiameter*2);
		setBlueOvalX(getFrameWidth()/2 - rotationRadius - smallOvalDiameter/2);
		setBlueOvalY(getFrameHeight()-rotationRadius-smallOvalDiameter*2);
		theta=0;
		
		//================================ selecting last played level================================
		String ip = null;
		DataAccess da=new DataAccess();
        ResultSet rs=null;
		try {
			ip = InetAddress.getLocalHost().toString();
			String name = ip.substring(0, ip.indexOf('/'));
	        
	        String q = "SELECT Level FROM `ScoreBoard` WHERE `UserName` LIKE '"+name+"'";

	        rs=da.getData(q);
	        try {
				rs.next();
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				//e1.printStackTrace();
			}
	        	try {
					levelNo = rs.getInt("Level");
				} catch (SQLException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
	        try {
				da.close();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
		} catch (UnknownHostException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		//============================================================================================
		
		setRotationSpeed(7);
		setObstacleSpeed(5);
		
		ovalPathCenterX = ( getBlueOvalX() + getRedOvalX() ) / 2;
		ovalPathCenterY = ( getBlueOvalY() + getRedOvalY() ) / 2;
		radius=rotationRadius;

		int x,y,i;
		for(i = 0,y = getObstacleStartY() ; i<getObstacleNumber() ; y -= getObstacleDistance(), i++){
			getObstacleWidth()[i] = 200;
			getObstacleHeight()[i] = 35;
			obstacleDistanceArray [i] = y;
			if(i%2 == 0){
				x = 10;
			}
			else {
				x  = getFrameWidth()-10-getObstacleWidth()[i];
			}
			obstacles[i] = new PairCoOrdinate(x,y,getObstacleWidth()[i],getObstacleHeight()[i]);
		}

	}
		public void paintComponent(Graphics g2) {
		  super.paintComponent(g2);
		  Graphics2D g = (Graphics2D) g2;
		  g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);;
		  g.setColor(Color.WHITE);
		//======================================Ovals=======================================
		  if(!isPaused){
			  g.drawOval((int)(ovalPathCenterX - rotationRadius + smallOvalDiameter/2), (int)(ovalPathCenterY - rotationRadius + smallOvalDiameter/2), rotationRadius*2, rotationRadius*2);
			  g.setColor(Color.BLUE);
			  g.fillOval((int)(getBlueOvalX()),(int)(getBlueOvalY()), smallOvalDiameter, smallOvalDiameter);
			  g.setColor(Color.RED);
			  g.fillOval((int)(getRedOvalX()),(int)(getRedOvalY()), smallOvalDiameter, smallOvalDiameter);
			
		//====================================Obstacles=================================
			
			  g.setColor(Color.WHITE);
			  g.fillRect(obstacles[0].x, obstacles[0].y, getObstacleWidth()[0], getObstacleHeight()[0]);
			  g.fillRect(obstacles[1].x, obstacles[1].y,  getObstacleWidth()[1], getObstacleHeight()[1]);
			  g.fillRect(obstacles[2].x, obstacles[2].y,  getObstacleWidth()[2], getObstacleHeight()[2]);
			  g.fillRect(obstacles[3].x, obstacles[3].y,  getObstacleWidth()[3], getObstacleHeight()[3]);
			  g.fillRect(obstacles[4].x, obstacles[4].y,  getObstacleWidth()[4], getObstacleHeight()[4]);
			  g.fillRect(obstacles[5].x, obstacles[5].y,  getObstacleWidth()[5], getObstacleHeight()[5]);
		  //=============================Level Info======================================
			  g.setFont(smallFont);
			  g.setColor(Color.CYAN);
			  g.drawString("CURRENT LEVEL: "+KeySensor.getLevel(), frameWidth-140, 20);
		  }
		  
		  else{
		//==========================PAUSED===============================
			  g.setFont(largeFont);
			  g.setColor(Color.WHITE);
			  g.drawString("PAUSED", frameWidth/2 - g.getFontMetrics().stringWidth("PAUSED") / 2, frameHeight/2);
		  }
		}
		
		public void updateDatabase(int l){
			String ip = null;
			String name = null ;
			try {
				ip = InetAddress.getLocalHost().toString();
				name = ip.substring(0, ip.indexOf('/'));
			} catch (UnknownHostException e) {
				// TODO Auto-generated catch block
				//e.printStackTrace();
			}
			
			try {
	        	DataAccess da=new DataAccess();
	        	String query ="SELECT Level FROM `ScoreBoard` WHERE `UserName` LIKE '"+name+"'";
	        	ResultSet rs=da.getData(query);
	        	
	        	rs.next();
	        	if(rs.getInt("Level")<l){
	        		query = "update `ScoreBoard` set Level='"+l+"' where UserName Like '"+name+"'"; 
	        		da.updateDB(query);
	        	}
			} catch (SQLException e) {
				
			}
		}
		public int getThreadSpeed() {
			return threadSpeed;
		}
		public void setThreadSpeed(int threadSpeed) {
			this.threadSpeed = threadSpeed;
		}
		public int getObstacleSpeed() {
			return obstacleSpeed;
		}
		public void setObstacleSpeed(int obstacleSpeed) {
			this.obstacleSpeed = obstacleSpeed;
		}
		public int getRotationSpeed() {
			return rotationSpeed;
		}
		public void setRotationSpeed(int rotationSpeed) {
			this.rotationSpeed = rotationSpeed;
		}
		public Clip getClip() {
			return clip;
		}
		public void setClip(Clip clip) {
			this.clip = clip;
		}
		public double getBlueOvalX() {
			return blueOvalX;
		}
		public void setBlueOvalX(double blueOvalX) {
			this.blueOvalX = blueOvalX;
		}
		public double getRedOvalX() {
			return redOvalX;
		}
		public void setRedOvalX(double redOvalX) {
			this.redOvalX = redOvalX;
		}
		public double getBlueOvalY() {
			return blueOvalY;
		}
		public void setBlueOvalY(double blueOvalY) {
			this.blueOvalY = blueOvalY;
		}
		public double getRedOvalY() {
			return redOvalY;
		}
		public void setRedOvalY(double redOvalY) {
			this.redOvalY = redOvalY;
		}
		public int getFrameHeight() {
			return frameHeight;
		}
		public void setFrameHeight(int frameHeight) {
			this.frameHeight = frameHeight;
		}
		public int getObstacleStartY() {
			return obstacleStartY;
		}
		public void setObstacleStartY(int obstacleStartY) {
			this.obstacleStartY = obstacleStartY;
		}
		public int getObstacleNumber() {
			return obstacleNumber;
		}
		public void setObstacleNumber(int obstacleNumber) {
			this.obstacleNumber = obstacleNumber;
		}
		public int getObstacleDistance() {
			return obstacleDistance;
		}
		public void setObstacleDistance(int obstacleDistance) {
			this.obstacleDistance = obstacleDistance;
		}
		public int getFrameWidth() {
			return frameWidth;
		}
		public void setFrameWidth(int frameWidth) {
			this.frameWidth = frameWidth;
		}
		public Integer[] getObstacleWidth() {
			return obstacleWidth;
		}
		public void setObstacleWidth(Integer obstacleWidth[]) {
			this.obstacleWidth = obstacleWidth;
		}
		public Integer[] getObstacleHeight() {
			return obstacleHeight;
		}
		public void setObstacleHeight(Integer obstacleHeight[]) {
			this.obstacleHeight = obstacleHeight;
		}
		public boolean getIsPaused() {
			return isPaused;
		}
		public void setIsPaused(boolean isPaused) {
			this.isPaused = isPaused;
		}
		public static Font getLargefont() {
			return largeFont;
		}
		public int getLevelNo() {
			return levelNo;
		}
		public void setLevelNo(int levelNo) {
			this.levelNo = levelNo;
		}
		
}
