
public class CoOrdinateChange {
	public GamePanel gp;
	CoOrdinateChange(GamePanel p){
		gp = p; 
	}

	public void ovalRotateLeft(int th) {
		
		gp.theta-=th;
		double radian=Math.toRadians(gp.theta);
		
		gp.setRedOvalX(gp.ovalPathCenterX + gp.radius*Math.cos(radian));
		gp.setBlueOvalX(gp.ovalPathCenterX - gp.radius*Math.cos(radian));
		gp.setRedOvalY(gp.ovalPathCenterY + gp.radius*Math.sin(radian));
		gp.setBlueOvalY(gp.ovalPathCenterY - gp.radius*Math.sin(radian));
		gp.repaint();
		
	}

	public void ovalRotateRight(int th) {
		
		gp.theta+=th;
		double radian=Math.toRadians(gp.theta);
		
		gp.setRedOvalX(gp.ovalPathCenterX + gp.radius*Math.cos(radian));
		gp.setBlueOvalX(gp.ovalPathCenterX - gp.radius*Math.cos(radian));
		gp.setRedOvalY(gp.ovalPathCenterY + gp.radius*Math.sin(radian));
		gp.setBlueOvalY(gp.ovalPathCenterY - gp.radius*Math.sin(radian));
		gp.repaint();
	}

	public void ovalAfterColision(int th) {

		gp.theta+=th;
		double radian=Math.toRadians(gp.theta);
		
		gp.setRedOvalX(gp.ovalPathCenterX + .8*gp.radius*Math.sin(radian));
		gp.setBlueOvalX(gp.ovalPathCenterX - .8*gp.radius*Math.sin(radian));
		gp.setRedOvalY(gp.ovalPathCenterY + .8*gp.radius*Math.cos(radian));
		gp.setBlueOvalY(gp.ovalPathCenterY - .8*gp.radius*Math.cos(radian));
		gp.repaint();
		
	}

	public void ovalSetInitialCoOrdinate() {
		
		gp.setBlueOvalX(gp.getFrameWidth()/2 - gp.rotationRadius - gp.smallOvalDiameter/2);
		gp.setBlueOvalY(gp.getFrameHeight() - gp.rotationRadius - gp.smallOvalDiameter*2);
		gp.setRedOvalX(gp.getFrameWidth()/2 + gp.rotationRadius - gp.smallOvalDiameter/2);
		gp.setRedOvalY(gp.getFrameHeight() - gp.rotationRadius - gp.smallOvalDiameter*2);
		gp.theta=0;
		
	}
	
	public void changeObstacleY() throws InterruptedException{
		
		int i;
		for(i = 0 ; i<gp.getObstacleNumber() ; i++){
			Thread.sleep(160);	
			gp.obstacles[i].y = gp.obstacleDistanceArray[i];
			gp.repaint();
		}
		
	}
	public void panelChange(){
		int i;
		for(i = 0 ; i<gp.getObstacleNumber() ; i++){
			gp.obstacles[i].y = gp.obstacleDistanceArray[i];
			gp.repaint();
		}
		gp.setIsPaused(false);
	}
	public void rotateObstacle(int index , int theta){
		
	}
	
	public void changeObstacleShapeSquare(int index , int height, int width){
		
	}
}
