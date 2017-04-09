package profilemanager.admob.tanvir.com.myautoprofilemanager;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.telephony.TelephonyManager;
import android.util.Log;

public class MyCallReciver extends BroadcastReceiver {
    public static int callCounter = 0;
    private static String oldphoneNumber = "";
    private static String lastState = "";
   /* DataBaseHelper myDb;
    public MyCallReciver() {
        super();

       // myDb = new DataBaseHelper(this);
    }*/

    @Override
    public void onReceive(Context context, Intent intent) {



        if (intent.getStringExtra(TelephonyManager.EXTRA_STATE).equals(TelephonyManager.EXTRA_STATE_RINGING)) {
            // This code will execute when the phone has an incoming call

            lastState = TelephonyManager.EXTRA_STATE_RINGING;

            // get the phone number
            String incomingNumber = intent.getStringExtra(TelephonyManager.EXTRA_INCOMING_NUMBER);
            Log.d("numrcv", incomingNumber + "  counter = " + callCounter);

            Log.d("numrcv", "new phn= "+incomingNumber + "  old phn = " + oldphoneNumber);

            if (oldphoneNumber.equals(incomingNumber)) callCounter++;
            else callCounter = 0;

            oldphoneNumber = incomingNumber;

            // Toast.makeText(context, "Call from:" +incomingNumber, Toast.LENGTH_LONG).show();

        }
        if (intent.getStringExtra(TelephonyManager.EXTRA_STATE).equals(TelephonyManager.EXTRA_STATE_OFFHOOK)) {
            lastState = TelephonyManager.EXTRA_STATE_OFFHOOK;
            callCounter = 0;
            Log.d("numrcv", "RECIVED CALL  ");
        }

        if ((lastState.equals(TelephonyManager.EXTRA_STATE_OFFHOOK)) && (TelephonyManager.EXTRA_STATE).equals(TelephonyManager.EXTRA_STATE_IDLE)) {
            callCounter = 0;
            Log.d("numrcv", "RECIVED CANCELED  ");
            lastState = "";
            oldphoneNumber = "";
        }


        Log.d("numrcv", "ACTION_PHONE_STATE_CHANGED called = " + TelephonyManager.ACTION_PHONE_STATE_CHANGED);

        Log.d("numrcv", "EXTRA_STATE=  " + intent.getStringExtra(TelephonyManager.EXTRA_STATE));
    }


}