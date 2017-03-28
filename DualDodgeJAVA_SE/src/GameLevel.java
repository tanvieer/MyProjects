

public class GameLevel {
	public GamePanel gp;
	GameLevel(GamePanel p){
		gp=p;
	}
//==============================================Shape=========================================================
	public void obstacleBox(int index){
		gp.getObstacleWidth()[index] = 75;
		gp.getObstacleHeight()[index] = 75;
	}
	public void obstacleI(int index){
		gp.getObstacleWidth()[index] = 35;
		gp.getObstacleHeight()[index] = 150;
	}
	public void obstacleRectangle(int index){
		gp.getObstacleWidth()[index] = 200;
		gp.getObstacleHeight()[index] = 35;
	}
//===============================================Level==========================================================
	public void levelOne (){
		for(int i = 0,y = gp.getObstacleStartY() ; i<gp.getObstacleNumber() ; y -= gp.getObstacleDistance(), i++){
			gp.setThreadSpeed(40);
			gp.setRotationSpeed(6);
			gp.setObstacleSpeed(5);
			obstacleRectangle(i);
			gp.obstacles[i].y = y;
			gp.obstacleDistanceArray[i] = y;
			if(i%2 == 0){
				gp.obstacles[i].x = 10;
			}
			else {
				gp.obstacles[i].x  = gp.getFrameWidth()-10-gp.getObstacleWidth()[i];
			}
		}
	}
	public void levelTwo (){
		levelOne();
		obstacleBox(3);
		obstacleBox(4);
		gp.obstacles[3].x = 200;
		gp.obstacles[4].y += 50;
		gp.obstacles[5].y += 100;
		gp.obstacles[4].x = 100;
	}
	public void levelThree (){
		levelTwo();
		levelOne();
		gp.setObstacleDistance(gp.getObstacleDistance());
		for(int i = 0,y = gp.getObstacleStartY() ; i<gp.getObstacleNumber() ; y -= gp.getObstacleDistance(), i++){
			obstacleRectangle(i);
			if(i == 5){
				gp.obstacles[i].x = 200;
				gp.obstacles[i].y = y;
				gp.obstacleDistanceArray[i] = y;
			}
			else
			{
				gp.obstacles[i].x = 10;
				gp.obstacles[i].y = y-20;
				gp.obstacleDistanceArray[i] = y-20;
			}
		}
		gp.setThreadSpeed(40);
		gp.setRotationSpeed(5);
		gp.setObstacleSpeed(5);
	}
	public void levelFour (){
		levelOne();
		obstacleBox(0);
		gp.obstacles[0].x = 250;
		gp.obstacleDistanceArray[1] += 50;
		gp.obstacles[1].y = gp.obstacleDistanceArray[1];
		gp.obstacles[1].x = 167;	
		gp.obstacles[2].x = 250;
		gp.obstacleDistanceArray[2] -= 50;
		gp.obstacles[2].y = gp.obstacleDistanceArray[2];
		gp.obstacles[3].x = 75;
		gp.obstacleDistanceArray[3] = gp.obstacleDistanceArray[2];
		gp.obstacles[3].y = gp.obstacleDistanceArray[3];
		obstacleI(2);
		obstacleI(3);
		gp.obstacleDistanceArray[4] += 100;
		gp.obstacles[4].y = gp.obstacleDistanceArray[4];
		gp.obstacleDistanceArray[5] += 130;
		gp.obstacles[5].y = gp.obstacleDistanceArray[5];
	}
	public void levelFive (){
		levelOne();
		obstacleBox(0);
		obstacleBox(1);
		gp.obstacles[0].x = 250;
		gp.obstacles[1].x = 100;
		gp.obstacles[1].y = gp.obstacles[0].y;
		gp.obstacleDistanceArray[1] = gp.obstacles[1].y;
		gp.obstacles[2].x = 190;
		obstacleRectangle(2);
		gp.obstacles[2].y = gp.obstacleDistanceArray[1] - 250;
		gp.obstacleDistanceArray[2] = gp.obstacles[2].y ;
		gp.obstacles[3].y = gp.obstacleDistanceArray[2] - 200;
		gp.obstacleDistanceArray[3] = gp.obstacles[3].y ;
		gp.obstacles[4].y = gp.obstacleDistanceArray[3] - 180;
		gp.obstacles[4].x = 190;
		gp.obstacles[3].x = 190;
		gp.obstacles[5].x = 150;
		gp.obstacleDistanceArray[4] = gp.obstacles[4].y ;
		gp.obstacles[5].y = gp.obstacleDistanceArray[4] - 290;
		gp.obstacleDistanceArray[5] = gp.obstacles[5].y ;
		obstacleBox(5);
	}
	public void levelSix (){
		levelOne();
		levelThree();
	}
	public void levelSeven (){
		levelOne();
		levelTwo();
	}
	public void levelEight (){
		levelOne();
	}
	public void levelNine (){
		levelOne();
		levelThree();
	}
	public void levelTen (){
		levelOne();
		KeySensor.setLevel(1);
	}
//===============================================Game Over==================================================
}
