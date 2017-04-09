package profilemanager.admob.tanvir.com.myautoprofilemanager;

import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.media.AudioManager;
import android.os.IBinder;
import android.support.annotation.Nullable;
import android.util.Log;

import java.util.Calendar;

/**
 * Created by Tanvir on 29-Mar-17.
 */

public class ProfileManager extends Service {
    private static final String TAG = "ProfileManager1";
    public static java.util.Date oldTime;

    public static double value_AccelarometerZ;
    private Sensor _AccelerometerSensor;
    public static Thread accelerometer_sensorThread;
    private SensorEventListener _AccelerometerListener;

    public static double value_lightLux;
    private Sensor lightSensor;
    public static Thread light_sensorThread;
    private SensorEventListener lightListener;

    private SensorManager sm;
    private AudioManager myAudioManager;
    public static boolean startthread = true;


    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        Log.d(TAG, "onBind Called");
        return null;
    }


    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        myAudioManager = (AudioManager) getSystemService(Context.AUDIO_SERVICE);
        sm = (SensorManager) this.getSystemService(Context.SENSOR_SERVICE);

        _AccelerometerSensor = sm.getSensorList(Sensor.TYPE_ACCELEROMETER).get(0);
        lightSensor = sm.getSensorList(Sensor.TYPE_LIGHT).get(0);

        Log.d(TAG, "onStartCommand Called");
        Log.d(TAG, "value_AccelarometerZ before =" + Double.toString(value_AccelarometerZ));
        Log.d(TAG, "value_lightLux before =" + Double.toString(value_lightLux));
        AccelerometerCheckingStart();
        LightCheckingStart();

        Thread thread = new Thread() {
            @Override
            public void run() {
                try {
                    while (startthread) {
                        sleep(10000);
                        sm.registerListener(_AccelerometerListener, _AccelerometerSensor, SensorManager.SENSOR_DELAY_NORMAL);
                        sleep(1000);
                        Log.d(TAG, "value_AccelarometerZ after =" + Double.toString(value_AccelarometerZ));
                        sm.unregisterListener(_AccelerometerListener);

                        sm.registerListener(lightListener, lightSensor, SensorManager.SENSOR_DELAY_NORMAL);
                        sleep(1000);
                        Log.d(TAG, "value_lightLux after =" + Double.toString(value_lightLux));
                        sm.unregisterListener(lightListener);

                        ChangeProfile();
                    }
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        };
        thread.start();
        return super.onStartCommand(intent, flags, startId);

    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        sm.unregisterListener(_AccelerometerListener);
        sm.unregisterListener(lightListener);
        startthread = false;
        Log.d(TAG, "On Destroy Called");
    }


    //==============================_Accelerometer=====================================
    private void AccelerometerCheckingStart() {

        accelerometer_sensorThread = new Thread() {
            public void run() {

                _AccelerometerListener = new SensorEventListener() {

                    @Override
                    public void onSensorChanged(SensorEvent event) {
                        // TODO Auto-generated method stub

                        value_AccelarometerZ = (int) event.values[2];

                        // Log.d(TAG, "value_AccelarometerZ inside function =" + Double.toString(value_AccelarometerZ));
                    }

                    @Override
                    public void onAccuracyChanged(Sensor sensor, int accuracy) {
                        // TODO Auto-generated method stub

                    }
                };

            }
        };
        accelerometer_sensorThread.start();
        sm.registerListener(_AccelerometerListener, _AccelerometerSensor, SensorManager.SENSOR_DELAY_NORMAL);

    }

    //==============================LIGHT=====================================
    private void LightCheckingStart() {
        light_sensorThread = new Thread() {
            public void run() {
                lightListener = new SensorEventListener() {
                    @Override
                    public void onSensorChanged(SensorEvent event) {
                        // TODO Auto-generated method stub
                        value_lightLux = (int) event.values[0];
                        // Log.d(TAG, "value_lightLux inside function =" + Double.toString(value_lightLux));
                    }

                    @Override
                    public void onAccuracyChanged(Sensor sensor, int accuracy) {
                        // TODO Auto-generated method stub
                    }
                };
            }
        };
        light_sensorThread.start();
        sm.registerListener(lightListener, lightSensor, SensorManager.SENSOR_DELAY_NORMAL);
    }



//=================================================pROFILE===========================================

    private void ChangeProfile(){
        Log.d(TAG,"ProfileChanger = "+myAudioManager.getRingerMode());
        if( MyCallReciver.callCounter < 5 && value_AccelarometerZ >-2 && value_lightLux<10 &&   myAudioManager.getRingerMode() != AudioManager.RINGER_MODE_VIBRATE) {
            Log.d("numrcv", "  PROFILE MANAGER night counter1  = " + MyCallReciver.callCounter);
            myAudioManager.setRingerMode(AudioManager.RINGER_MODE_VIBRATE);
        }
        else if( MyCallReciver.callCounter < 5 && value_AccelarometerZ <-7 && myAudioManager.getRingerMode() != AudioManager.RINGER_MODE_SILENT) {
            myAudioManager.setRingerMode(AudioManager.RINGER_MODE_SILENT);
            Log.d("numrcv", "  PROFILE MANAGER flipped counter2  = " + MyCallReciver.callCounter);
        }
        else if ( value_lightLux>500 && value_AccelarometerZ >-2 && myAudioManager.getRingerMode() != AudioManager.RINGER_MODE_NORMAL){
            myAudioManager.setRingerMode(AudioManager.RINGER_MODE_NORMAL);
            Log.d("numrcv", "  PROFILE MANAGER unflipped counter3  = " + MyCallReciver.callCounter);
        }
        if (MyCallReciver.callCounter > 4 && myAudioManager.getRingerMode() != AudioManager.RINGER_MODE_NORMAL){
            myAudioManager.setRingerMode(AudioManager.RINGER_MODE_NORMAL);

            Log.d("numrcv", "  PROFILE MANAGER emergency counter4  = " + MyCallReciver.callCounter);
        }

        Log.d("numrcv", "  PROFILE MANAGER counter DEFAULT = " + MyCallReciver.callCounter);




    }




    public boolean TimeCompare() {
        // TODO Auto-generated method stub
        Log.d("TEST_TAG", "Time Compare a dhukse");
        Calendar c = Calendar.getInstance();


        java.util.Date currentTime = c.getTime();
        if (oldTime.compareTo(currentTime) <= 0) {
            c.add(Calendar.MINUTE, 1);
            oldTime = c.getTime();
            return true; // time par hoye gese
        }
        return false;// time baki ase
    }

}
