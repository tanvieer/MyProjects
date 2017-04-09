package profilemanager.admob.tanvir.com.myautoprofilemanager;

import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.AdView;
import com.google.android.gms.ads.MobileAds;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    // Remove the below line after defining your own ad unit ID.
    //private static final String TOAST_TEXT = "Test ads are being shown. "
         //   + "To show live ads, replace the ad unit ID in res/values/strings.xml with your own ad unit ID.";
    private Intent myService;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        MobileAds.initialize(getApplicationContext(),"ca-app-pub-3488217849496330~4353609604");

        // Load an ad into the AdMob banner view.
        AdView adView = (AdView) findViewById(R.id.adView);
        AdRequest adRequest = new AdRequest.Builder()
                .setRequestAgent("android_studio:ad_template").build();
        adView.loadAd(adRequest);

        // Toasts the test ad message on the screen. Remove this after defining your own ad unit ID.
       // Toast.makeText(this, TOAST_TEXT, Toast.LENGTH_LONG).show();

        MobileAds.initialize(getApplicationContext(),"ca-app-pub-3488217849496330/5830342803");

        AdView adView1 = (AdView) findViewById(R.id.adView1);
        AdRequest adRequest1 = new AdRequest.Builder()
                .setRequestAgent("android_studio:ad_template").build();
        adView1.loadAd(adRequest1);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }




    @Override
    protected void onResume(){
        super.onResume();
        myService = new Intent(this, ProfileManager.class);  // ProfileManager
    }

    public void onStartClicked(View v){
        MyCallReciver.callCounter = 0;
        startService(myService);
        Toast.makeText(this, "Service Started", Toast.LENGTH_SHORT).show();
    }

    public void onStopClicked(View v){
        MyCallReciver.callCounter = 0;
        stopService(myService);
        Toast.makeText(this, "Service Stopped", Toast.LENGTH_SHORT).show();
    }
}

