
public class Rank {
	private int Level;
	private String Name;
	
	public Rank(){
		
	}
	public Rank(String n, int l){
		Level = l;
		Name = n;
	}
	public int getLevel() {
		return Level;
	}
	public void setLevel(int level) {
		this.Level = level;
	}
	public String getName() {
		return Name;
	}
	public void setName(String name) {
		this.Name = name;
	}
	public static void sort(Rank[] rankList, int size){
		Rank temp;
        for (int i = 1; i < size; i++) {
            for(int j = i ; j > 0 ; j--){
                if(rankList[j].getLevel() > rankList[j-1].getLevel()){
                    temp = rankList[j];
                    rankList[j] = rankList[j-1];
                    rankList[j-1] = temp;
                }
            }
        }
	}
}
