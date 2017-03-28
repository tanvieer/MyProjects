import java.awt.Rectangle;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.geom.Ellipse2D;

public class KeySensor  implements KeyListener, Runnable{
	
	private CoOrdinateChange co ;
	public static int threadSpeed = 10;
	private RankPanel rp;
	private StartPanel sp;
	private GamePanel gp;
	private GameLevel gl;
	private Thread KeyThread = null;
	private Music m = new Music("bump");
	
	private boolean collision =false;
	private boolean checkL = false;
	private boolean checkR = false;
	
	private int count = 0;
	private static int level;
	//=========================================
	private Rectangle fallingR1;
	private Rectangle fallingL1;
	private Rectangle fallingR2;
	private Rectangle fallingL2;
	private Rectangle fallingR3;
	private Rectangle fallingL3;
	
	private Ellipse2D.Double redCircle;
	private Ellipse2D.Double blueCircle;
	//=========================================
	
	public KeySensor(GamePanel p, StartPanel sp, RankPanel rp){
		
		this.rp=rp;
		this.sp=sp;
		this.gp=p;
		setLevel(p.getLevelNo());                    /////store initial level
		gl = new GameLevel(gp);
        KeyThread = new Thread(this);
        co = new CoOrdinateChange(gp);
      //======================================= Selecting initial level  ================================
        if( getLevel() == 1 ){
    		gl.levelOne();
    	}
    	else if( getLevel() == 2 ){
    		gl.levelTwo();
    	}
    	else if( getLevel() == 3 ){
    		gl.levelThree();
    	}
    	else if( getLevel() == 4 ){
    		gl.levelFour();
    	}
    	else if( getLevel() == 5 ){
    		gl.levelFive();
    	}
    	else if( getLevel() == 6 ){
    		gl.levelSix();
    	}
    	else if( getLevel() == 7 ){
    		gl.levelSeven();
    	}
    	else if( getLevel() == 8 ){
    		gl.levelEight();
    	}
    	else if( getLevel() == 9 ){
    		gl.levelNine();
    	}
    	else if( getLevel() == 10 ){
    		gl.levelTen();
    	}
    	else if( getLevel() == 11 ){
    		setLevel(2);
    		gp.setLevelNo(getLevel());
    	}
      //==============================================================================================
      		
        KeyThread.start();
	}
	
	@Override
	public void keyPressed(KeyEvent ke){
		if(ke.getKeyCode()==KeyEvent.VK_LEFT && !collision && !gp.getIsPaused()){
			co.ovalRotateLeft(gp.getRotationSpeed());
			count ++;
			if(count < 2) checkL = true;
			else {
				checkL = false;
				count = 5;
			}	
		}
		else if(ke.getKeyCode()==KeyEvent.VK_RIGHT && !collision && !gp.getIsPaused()){
			co.ovalRotateRight(gp.getRotationSpeed());
			count ++;
			if(count < 2) checkR = true;
			else{
				checkR = false;
				count = 5;
			}
		}		
    }
	@Override
	public void keyReleased(KeyEvent ke) {
		checkL = false;
		checkR = false;
		count = 0;
		
			if(ke.getKeyCode()==KeyEvent.VK_DOWN && !gp.getIsPaused()){
				gp.setRotationSpeed(gp.getRotationSpeed()-1);
				System.out.println(gp.getRotationSpeed());
			}
			else if(ke.getKeyCode()==KeyEvent.VK_UP && !gp.getIsPaused()){
				gp.setRotationSpeed(gp.getRotationSpeed()+1);
				System.out.println(gp.getRotationSpeed());
			}
			else if(ke.getKeyCode()==KeyEvent.VK_P && !collision){
				gp.setIsPaused(!gp.getIsPaused());
			}
			else if(ke.getKeyCode()==KeyEvent.VK_U && !gp.getIsPaused()){
				threadSpeed+=10;
			}
			else if(ke.getKeyCode()==KeyEvent.VK_I && !gp.getIsPaused()){
				threadSpeed-=10;
			}
			
			/*THIS IS TO TEST VISIBILITY OF PANELS*/
			//=================================================================
			else if(ke.getKeyCode()==KeyEvent.VK_S && (gp.isVisible() || rp.isVisible())){
				gp.setVisible(false);
				rp.setVisible(false);
				co.panelChange();
				co.ovalSetInitialCoOrdinate();
				sp.setVisible(true);
			}
			else if(ke.getKeyCode()==KeyEvent.VK_ENTER && (sp.isVisible() || rp.isVisible())){
				sp.setVisible(false);
				rp.setVisible(false);
				co.panelChange();
				co.ovalSetInitialCoOrdinate();
				gp.setVisible(true);
			}
			else if(ke.getKeyCode()==KeyEvent.VK_R && (sp.isVisible() || gp.isVisible())){
				sp.setVisible(false);
				gp.setVisible(false);
				co.panelChange();
				co.ovalSetInitialCoOrdinate();
				rp.setVisible(true);
			}
			//===================================================================
	}
	@Override
	public void keyTyped(KeyEvent ke) {
		
	}	
	
	public void checkCircleRectCollision(){
		gp.repaint();
		
		fallingR1 = (new Rectangle(gp.obstacles[0].x, gp.obstacles[0].y, gp.getObstacleWidth()[0]-2, gp.getObstacleHeight()[0]-2));
		fallingL1 = (new Rectangle(gp.obstacles[1].x, gp.obstacles[1].y, gp.getObstacleWidth()[1]-2, gp.getObstacleHeight()[1]-2));
		fallingR2 = (new Rectangle(gp.obstacles[2].x, gp.obstacles[2].y, gp.getObstacleWidth()[2]-2, gp.getObstacleHeight()[2]-2));
		fallingL2 = (new Rectangle(gp.obstacles[3].x, gp.obstacles[3].y, gp.getObstacleWidth()[3]-2, gp.getObstacleHeight()[3]-2));
		fallingR3 = (new Rectangle(gp.obstacles[4].x, gp.obstacles[4].y, gp.getObstacleWidth()[4]-2, gp.getObstacleHeight()[4]-2));
		fallingL3 = (new Rectangle(gp.obstacles[5].x, gp.obstacles[5].y, gp.getObstacleWidth()[5]-2, gp.getObstacleHeight()[5]-2));
		
		redCircle = new Ellipse2D.Double((int)gp.getRedOvalX(),(int)gp.getRedOvalY(), gp.smallOvalDiameter, gp.smallOvalDiameter);
		blueCircle = new Ellipse2D.Double((int)gp.getBlueOvalX(),(int)gp.getBlueOvalY(), gp.smallOvalDiameter, gp.smallOvalDiameter);

		//R1
		if(fallingR1.getBounds2D().intersects(redCircle.getBounds2D())){
			collision=true;
		}
		else if(fallingR1.getBounds2D().intersects(blueCircle.getBounds2D())){
			collision=true;
		}
		//L1
		else if(fallingL1.getBounds2D().intersects(redCircle.getBounds2D())){
			collision=true;
		}
		else if(fallingL1.getBounds2D().intersects(blueCircle.getBounds2D())){
			collision=true;
		}
		//R2
		else if(fallingR2.getBounds2D().intersects(redCircle.getBounds2D())){
			collision=true;
		}
		else if(fallingR2.getBounds2D().intersects(blueCircle.getBounds2D())){
			collision=true;
		}
		//L2
		else if(fallingL2.getBounds2D().intersects(redCircle.getBounds2D())){
			collision=true;
		}
		else if(fallingL2.getBounds2D().intersects(blueCircle.getBounds2D())){
			collision=true;
		}
		//R3
		else if(fallingR3.getBounds2D().intersects(redCircle.getBounds2D())){
			collision=true;
		}
		else if(fallingR3.getBounds2D().intersects(blueCircle.getBounds2D())){
			collision=true;
		}
		//L3
		else if(fallingL3.getBounds2D().intersects(redCircle.getBounds2D())){
			collision=true;
		}
		else if(fallingL3.getBounds2D().intersects(blueCircle.getBounds2D())){
			collision=true;
		}
		else if(!collision){
			gp.repaint();
		}
	}
	
    public void run(){
        while(true){
            try{ 
                Thread.sleep(gp.getThreadSpeed()-threadSpeed);
                if(checkL) co.ovalRotateLeft(gp.getRotationSpeed());
                if(checkR) co.ovalRotateRight(gp.getRotationSpeed());
                
                if(!collision){
                	gp.repaint();
                }
                
                if(!gp.getIsPaused() && gp.isVisible()){
	                gp.obstacles[0].y +=gp.getObstacleSpeed();
	                gp.obstacles[1].y +=gp.getObstacleSpeed(); 
	                gp.obstacles[2].y +=gp.getObstacleSpeed(); 
	                gp.obstacles[3].y +=gp.getObstacleSpeed(); 
	                gp.obstacles[4].y +=gp.getObstacleSpeed();
	                gp.obstacles[5].y +=gp.getObstacleSpeed();
	                
	                checkCircleRectCollision();  ///////////////////////// checking collision
	//=============================================Change Level===============================================
		
	                if(gp.obstacles[5].y >= gp.getFrameHeight()){
	                	setLevel(getLevel() + 1);
	                	gp.setLevelNo(getLevel());
	                	gp.updateDatabase(getLevel());
	                	if( getLevel() == 1 ){
	                		gl.levelOne();
	                	}
	                	else if( getLevel() == 2 ){
	                		gl.levelTwo();
	                	}
	                	else if( getLevel() == 3 ){
	                		gl.levelThree();
	                	}
	                	else if( getLevel() == 4 ){
	                		gl.levelFour();
	                	}
	                	else if( getLevel() == 5 ){
	                		gl.levelFive();
	                	}
	                	else if( getLevel() == 6 ){
	                		gl.levelSix();
	                	}
	                	else if( getLevel() == 7 ){
	                		gl.levelSeven();
	                	}
	                	else if( getLevel() == 8 ){
	                		gl.levelEight();
	                	}
	                	else if( getLevel() == 9 ){
	                		gl.levelNine();
	                	}
	                	else if( getLevel() == 10 ){
	                		setLevel(1);
	                		gp.setLevelNo(getLevel());
	                	}
	                	else {
	                		setLevel(1);
	                		gp.setLevelNo(getLevel());
	                	}
	                	
	                	for(int i = 0; i<26 ; i ++)
	                	{
	                		Thread.sleep(15);
	                		co.ovalRotateRight(15);
	                	}
	                	co.ovalSetInitialCoOrdinate();
	
	                }
	 //=============================================Change Level===============================================
	                if(collision){
	                	m.play();
	                	
	                	co.changeObstacleY();
	                	for(int i = 0; i<26 ; i ++)
	                	{
	                		Thread.sleep(15);
	                		co.ovalAfterColision(15);
	                	}
	                	co.ovalSetInitialCoOrdinate();
	                	collision = false;
	                	m.stop();
	                }
                }  
 
            }catch(InterruptedException ex){ex.printStackTrace();}
        	}
 
    }

	public static int getLevel() {
		return level;
	}

	public static void setLevel(int level) {
		KeySensor.level = level;
	}

	public StartPanel getSp() {
		return sp;
	}

	public void setSp(StartPanel sp) {
		this.sp = sp;
	}

}
